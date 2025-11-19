<?php
require_once __DIR__ . '/../includes/auth.php';
require_role('doctor');
$page_title = 'Doctor Schedule';
require_once __DIR__ . '/../includes/header.php';

$doctor_id = $_SESSION['user_id'];
$message = '';

// **PDO Placeholder: Fetch Doctor's Current Schedule**
$stmt_schedule = $pdo->prepare("SELECT scheduleid, title, scheduledate, scheduletime, nop FROM schedule WHERE docid = ? ORDER BY scheduledate, scheduletime");
$stmt_schedule->execute([$doctor_id]);
$current_schedule = $stmt_schedule->fetchAll();

if ($_SERVER['REQUEST_METHOD'] === 'POST') {
    $title = trim($_POST['title']);
    $date = trim($_POST['date']);
    $time = trim($_POST['time']);
    $nop = (int)$_POST['nop'];

    // **PDO Placeholder: Insert New Schedule Slot**
    $stmt_insert = $pdo->prepare("INSERT INTO schedule (docid, title, scheduledate, scheduletime, nop) 
        VALUES (?, ?, ?, ?, ?)");
    $stmt_insert->execute([$doctor_id, $title, $date, $time, $nop]);

    $message = '<div class="alert alert-success">Schedule slot added successfully!</div>';
    
    // Refresh schedule data
    header('Location: schedule.php');
    exit;
}
?>

<h1 class="mb-4 text-success"><i class="bi bi-calendar-week me-2"></i> My Available Schedule</h1>
<hr>

<div class="row">
    <div class="col-md-6">
        <div class="card shadow-sm mb-4">
            <div class="card-header bg-success text-white">
                <h5 class="mb-0">Create New Schedule Slot</h5>
            </div>
            <div class="card-body">
                <?= $message ?>
                <form action="schedule.php" method="POST">
                    <div class="mb-3">
                        <label for="title" class="form-label">Description/Title</label>
                        <input type="text" class="form-control" id="title" name="title" required placeholder="e.g., Morning Clinic">
                    </div>
                    <div class="row mb-3">
                        <div class="col-md-6">
                            <label for="date" class="form-label">Date</label>
                            <input type="date" class="form-control" id="date" name="date" required min="<?= date('Y-m-d') ?>">
                        </div>
                        <div class="col-md-6">
                            <label for="time" class="form-label">Time</label>
                            <input type="time" class="form-control" id="time" name="time" required>
                        </div>
                    </div>
                    <div class="mb-3">
                        <label for="nop" class="form-label">Max Patients (NOP)</label>
                        <input type="number" class="form-control" id="nop" name="nop" required min="1" value="10">
                    </div>
                    <button type="submit" class="btn btn-success mt-3">Save Schedule</button>
                </form>
            </div>
        </div>
    </div>
    
    <div class="col-md-6">
        <div class="card shadow-sm h-100">
            <div class="card-header bg-info text-white">
                <h5 class="mb-0">Current Schedule Slots</h5>
            </div>
            <div class="card-body">
                <?php if (count($current_schedule) > 0): ?>
                <div class="table-responsive">
                    <table class="table table-striped mb-0">
                        <thead>
                            <tr>
                                <th>Date</th>
                                <th>Time</th>
                                <th>Title</th>
                                <th>Max Pat.</th>
                            </tr>
                        </thead>
                        <tbody>
                            <?php foreach ($current_schedule as $slot): ?>
                            <tr>
                                <td><?= sanitize_output($slot['scheduledate']) ?></td>
                                <td><?= date('h:i A', strtotime($slot['scheduletime'])) ?></td>
                                <td><?= sanitize_output($slot['title']) ?></td>
                                <td><?= sanitize_output($slot['nop']) ?></td>
                            </tr>
                            <?php endforeach; ?>
                        </tbody>
                    </table>
                </div>
                <?php else: ?>
                <div class="alert alert-warning mb-0">No schedule defined yet.</div>
                <?php endif; ?>
            </div>
        </div>
    </div>
</div>

<?php require_once __DIR__ . '/../includes/footer.php'; ?>