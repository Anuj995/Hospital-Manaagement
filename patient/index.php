<?php
require_once __DIR__ . '/../includes/auth.php';
require_role('patient');
$page_title = 'Patient Dashboard';
require_once __DIR__ . '/../includes/header.php';

$patient_id = $_SESSION['user_id'];

// **PDO Placeholder: Fetch Patient Info**
$stmt_info = $pdo->prepare("SELECT pname, pemail FROM patient WHERE pid = ?");
$stmt_info->execute([$patient_id]);
$patient_info = $stmt_info->fetch();
$patient_name = $patient_info['pname'] ?? 'Patient';

// **PDO Placeholder: Count Total Appointments**
$stmt_count = $pdo->prepare("SELECT COUNT(*) FROM appointment WHERE pid = ?");
$stmt_count->execute([$patient_id]);
$total_appointments = $stmt_count->fetchColumn();

// **PDO Placeholder: Fetch Upcoming Appointments (Limit 5)**
$stmt_upcoming = $pdo->prepare("SELECT a.appoid, a.appodate, s.scheduletime, d.docname AS doctor_name, sp.sname AS specialty_name_display, s.title
    FROM appointment a 
    JOIN schedule s ON a.scheduleid = s.scheduleid 
    JOIN doctor d ON s.docid = d.docid 
    JOIN specialties sp ON d.specialties = sp.id /* FIX: Join specialties table */
    WHERE a.pid = ? AND s.scheduledate >= CURDATE() 
    ORDER BY s.scheduledate, s.scheduletime 
    LIMIT 5");
$stmt_upcoming->execute([$patient_id]);
$upcoming_appointments = $stmt_upcoming->fetchAll();
?>

<h1 class="mb-4 text-primary"><i class="bi bi-house-door-fill me-2"></i> Welcome Back, <?= sanitize_output($patient_name) ?>!</h1>
<hr>

<div class="row">
    <div class="col-lg-4 col-md-6 mb-4">
        <div class="card border-0 shadow-sm h-100 bg-info text-white">
            <div class="card-body">
                <div class="row align-items-center">
                    <div class="col-auto">
                        <i class="bi bi-clipboard-check display-4"></i>
                    </div>
                    <div class="col">
                        <div class="text-uppercase fw-bold small">Total Appointments</div>
                        <div class="h2 mb-0"><?= $total_appointments ?></div>
                    </div>
                </div>
            </div>
            <div class="card-footer bg-transparent border-0">
                <a href="appointment.php" class="text-white small stretched-link">View Details <i class="bi bi-arrow-right"></i></a>
            </div>
        </div>
    </div>
    <div class="col-lg-4 col-md-6 mb-4">
        <div class="card border-0 shadow-sm h-100 bg-success text-white">
            <div class="card-body">
                <div class="row align-items-center">
                    <div class="col-auto">
                        <i class="bi bi-calendar-plus display-4"></i>
                    </div>
                    <div class="col">
                        <div class="text-uppercase fw-bold small">Need a check-up?</div>
                        <div class="h2 mb-0">Book Now!</div>
                    </div>
                </div>
            </div>
            <div class="card-footer bg-transparent border-0">
                <a href="booking.php" class="text-white small stretched-link">Book Appointment <i class="bi bi-arrow-right"></i></a>
            </div>
        </div>
    </div>
    <div class="col-lg-4 col-md-6 mb-4">
        <div class="card border-0 shadow-sm h-100 bg-warning text-dark">
            <div class="card-body">
                <div class="row align-items-center">
                    <div class="col-auto">
                        <i class="bi bi-person-circle display-4"></i>
                    </div>
                    <div class="col">
                        <div class="text-uppercase fw-bold small">Your Account</div>
                        <div class="h2 mb-0">Profile</div>
                    </div>
                </div>
            </div>
            <div class="card-footer bg-transparent border-0">
                <a href="profile.php" class="text-dark small stretched-link">Update Info <i class="bi bi-arrow-right"></i></a>
            </div>
        </div>
    </div>
</div>

<div class="card shadow mb-4">
    <div class="card-header bg-primary text-white">
        <h5 class="mb-0"><i class="bi bi-calendar-event me-2"></i> Upcoming Appointments</h5>
    </div>
    <div class="card-body">
        <?php if (count($upcoming_appointments) > 0): ?>
        <div class="table-responsive">
            <table class="table table-hover mb-0">
                <thead>
                    <tr>
                        <th>Date</th>
                        <th>Time</th>
                        <th>Doctor</th>
                        <th>Specialty</th>
                        <th>Description</th>
                        <th>Action</th>
                    </tr>
                </thead>
                <tbody>
                    <?php foreach ($upcoming_appointments as $appt): ?>
                    <tr>
                        <td><?= sanitize_output($appt['appodate']) ?></td>
                        <td><?= sanitize_output(date('h:i A', strtotime($appt['scheduletime']))) ?></td>
                        <td><?= sanitize_output($appt['doctor_name']) ?></td>
                        <td><?= sanitize_output($appt['specialty_name_display']) ?></td>
                        <td><?= sanitize_output($appt['title']) ?></td>
                        <td><a href="appointment.php?id=<?= $appt['appoid'] ?? '1' ?>" class="btn btn-sm btn-outline-info">Details</a></td>
                    </tr>
                    <?php endforeach; ?>
                </tbody>
            </table>
        </div>
        <?php else: ?>
        <div class="alert alert-light mb-0">You have no upcoming appointments. <a href="booking.php">Book one now!</a></div>
        <?php endif; ?>
    </div>
</div>

<?php require_once __DIR__ . '/../includes/footer.php'; ?>