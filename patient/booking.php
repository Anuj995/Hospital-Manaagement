<?php
require_once __DIR__ . '/../includes/auth.php';
require_role('patient');
$page_title = 'Book Appointment';
require_once __DIR__ . '/../includes/header.php'; 

$patient_id = $_SESSION['user_id'];
$message = '';

// --- INITIALIZE VARIABLES ---
$selected_specialty_id = trim($_GET['specialty_id'] ?? ''); 

$doctor_id_url_present = isset($_GET['doctor_id']) && !empty($_GET['doctor_id']);

if (isset($_GET['specialty_id']) && !$doctor_id_url_present) {
    $doctor_id_selected = null;
} else {
    $doctor_id_selected = $doctor_id_url_present ? (int)$_GET['doctor_id'] : null;
}
// ----------------------------


// 1. Fetch all Specialties
$stmt_specs = $pdo->prepare("SELECT id, sname FROM specialties ORDER BY sname");
$stmt_specs->execute();
$specialties = $stmt_specs->fetchAll();

// 2. Filter Doctors based on selected Specialty ID
$doctors = [];
if (!empty($selected_specialty_id) && is_numeric($selected_specialty_id)) {
    // PDO Placeholder: Fetch doctors based on the specialty ID
    $stmt_doctors = $pdo->prepare("SELECT docid, docname FROM doctor WHERE specialties = ? ORDER BY docname");
    $stmt_doctors->execute([$selected_specialty_id]); 
    $doctors = $stmt_doctors->fetchAll();
}

// 3. Filter Schedules based on selected Doctor 
$schedules = [];
if ($doctor_id_selected) {
    // PDO Placeholder: Fetch available schedule slots
    $stmt_schedules = $pdo->prepare("
        SELECT s.scheduleid, s.title, s.scheduledate, s.scheduletime, s.nop, 
               (s.nop - COALESCE(COUNT(a.appoid), 0)) AS remaining_slots
        FROM schedule s
        LEFT JOIN appointment a ON s.scheduleid = a.scheduleid
        WHERE s.docid = ? AND s.scheduledate >= CURDATE()
        GROUP BY s.scheduleid
        HAVING remaining_slots > 0
        ORDER BY s.scheduledate, s.scheduletime
    ");
    $stmt_schedules->execute([$doctor_id_selected]);
    $schedules = $stmt_schedules->fetchAll();
}


// --- POST REQUEST HANDLER (FINAL BOOKING) ---

if ($_SERVER['REQUEST_METHOD'] === 'POST' && isset($_POST['schedule_id'])) {
    $schedule_id = (int)$_POST['schedule_id'];
    $appodate = trim($_POST['date']);
    
    // Check capacity and insert logic
    $stmt_capacity = $pdo->prepare("
        SELECT s.nop, COALESCE(COUNT(a.appoid), 0) AS booked_count
        FROM schedule s
        LEFT JOIN appointment a ON s.scheduleid = a.scheduleid
        WHERE s.scheduleid = ?
        GROUP BY s.scheduleid
    ");
    $stmt_capacity->execute([$schedule_id]);
    $capacity = $stmt_capacity->fetch();

    $remaining_slots = $capacity['nop'] - $capacity['booked_count'];
    $appo_num = $capacity['booked_count'] + 1;

    if ($remaining_slots <= 0) {
        $message = '<div class="alert alert-danger">Booking failed: The selected slot is now full.</div>';
    } else {
        // PDO Placeholder: Insert New Appointment
        $stmt_insert = $pdo->prepare("INSERT INTO appointment 
            (pid, apponum, scheduleid, appodate) 
            VALUES (?, ?, ?, ?)");
        
        if ($stmt_insert->execute([$patient_id, $appo_num, $schedule_id, $appodate])) {
            // SUCCESS MESSAGE ADDED HERE BEFORE REDIRECT
            $message = '<div class="alert alert-success">✅ Appointment successfully booked! You will be redirected to your appointments list in 3 seconds.</div>';
            
            header('Refresh: 3; URL=' . $base_path . 'patient/appointment.php');
            
        } else {
            $message = '<div class="alert alert-danger">An error occurred during booking insertion.</div>';
        }
    }
}
?>

<h1 class="mb-4 text-primary"><i class="bi bi-calendar-plus me-2"></i> Book New Appointment</h1>
<hr>

<div class="card shadow-sm">
    <div class="card-body">
        <?= $message ?>
        
        <form action="booking.php" method="GET" class="mb-4">
            <div class="row g-3">
                <div class="col-md-6">
                    <label for="specialty_id" class="form-label">1. Select Specialty</label>
                    <select class="form-select" id="specialty_id" name="specialty_id" required onchange="window.location.href='booking.php?specialty_id=' + this.value">
                        <option value="" disabled selected>Choose a medical field</option> 
                        <?php foreach ($specialties as $spec): ?>
                            <option value="<?= $spec['id'] ?>" 
                                <?= ($selected_specialty_id == $spec['id']) ? 'selected' : '' ?>>
                                <?= sanitize_output($spec['sname']) ?>
                            </option>
                        <?php endforeach; ?>
                    </select>
                </div>

                <div class="col-md-6">
                    <label for="doctor_id" class="form-label">2. Select Doctor</label>
                    <select class="form-select" id="doctor_id" name="doctor_id" 
                        <?= empty($doctors) ? 'disabled' : '' ?> onchange="this.form.submit()">
                        
                        <?php if (empty($doctors) && !empty($selected_specialty_id)): ?>
                            <option value="" disabled selected>No doctors available for this specialty</option>
                        <?php else: ?>
                            <option value="" disabled selected>Choose a doctor</option>
                            <?php foreach ($doctors as $doctor): ?>
                                <option value="<?= $doctor['docid'] ?>"
                                     <?= ($doctor_id_selected == $doctor['docid']) ? 'selected' : '' ?>>
                                    Dr. <?= sanitize_output($doctor['docname']) ?>
                                </option>
                            <?php endforeach; ?>
                        <?php endif; ?>
                        
                    </select>
                    <input type="hidden" name="specialty_id" value="<?= sanitize_output($selected_specialty_id) ?>">
                </div>
            </div>
        </form>

        <?php if ($doctor_id_selected): ?>
        <h5 class="mt-4">3. Available Slots & Booking</h5>
        
        <?php if (!empty($schedules)): ?>
        <form action="booking.php" method="POST">
            <div class="mb-3">
                <label for="schedule_id" class="form-label">Select Slot</label>
                <select class="form-select" id="schedule_id" name="schedule_id" required>
                    <option value="" disabled selected>Choose a date and time</option>
                    <?php foreach ($schedules as $slot): ?>
                        <option value="<?= $slot['scheduleid'] ?>" 
                                data-date="<?= $slot['scheduledate'] ?>">
                            <?= sanitize_output($slot['scheduledate']) ?> @ <?= date('h:i A', strtotime($slot['scheduletime'])) ?> - <?= sanitize_output($slot['title']) ?> (Remaining: <?= $slot['remaining_slots'] ?>)
                        </option>
                    <?php endforeach; ?>
                </select>
                <input type="hidden" name="date" id="hidden_date">
            </div>
            
            <button type="submit" class="btn btn-success mt-3">Confirm Booking</button>
        </form>
        
        <script>
            // JavaScript to grab the date from the selected slot and put it in the hidden field
            document.getElementById('schedule_id').addEventListener('change', function() {
                var selectedOption = this.options[this.selectedIndex];
                document.getElementById('hidden_date').value = selectedOption.getAttribute('data-date');
            });
        </script>

        <?php else: ?>
            <div class="alert alert-warning">The selected doctor has no available schedule slots.</div>
        <?php endif; ?>
        <?php endif; ?>
    </div>
</div>

<?php require_once __DIR__ . '/../includes/footer.php'; ?>