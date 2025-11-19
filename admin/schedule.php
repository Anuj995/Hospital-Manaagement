<?php
require_once __DIR__ . '/../includes/auth.php';
require_role('admin');
$page_title = 'Manage Doctor Schedule';
require_once __DIR__ . '/../includes/header.php';

$message = '';

// **PDO Placeholder: Fetch all Doctors**
$stmt_doctors = $pdo->prepare("SELECT docid, docname FROM doctor ORDER BY docname");
$stmt_doctors->execute();
$doctors = $stmt_doctors->fetchAll();

// **PDO Placeholder: Fetch all Schedule Slots**
$stmt_schedule = $pdo->prepare("SELECT s.scheduleid, d.docname AS doctor_name, s.title, s.scheduledate, s.scheduletime, s.nop 
    FROM schedule s 
    JOIN doctor d ON s.docid = d.docid 
    ORDER BY d.docname, s.scheduledate");
$stmt_schedule->execute();
$schedules = $stmt_schedule->fetchAll();

if ($_SERVER['REQUEST_METHOD'] === 'POST' && isset($_POST['action']) && $_POST['action'] === 'add_schedule') {
    $doctor_id = (int)$_POST['doctor_id'];
    $title = trim($_POST['title']);
    $date = trim($_POST['date']);
    $time = trim($_POST['time']);
    $nop = (int)$_POST['nop'];

    // **PDO Placeholder: Insert New Schedule Slot**
    $stmt_insert = $pdo->prepare("INSERT INTO schedule (docid, title, scheduledate, scheduletime, nop) 
        VALUES (?, ?, ?, ?, ?)");
    $stmt_insert->execute([$doctor_id, $title, $date, $time, $nop]);
    
    $message = '<div class="alert alert-success">Schedule slot added/updated.</div>';
    header("Location: schedule.php"); 
    exit;
}
?>

<h1 class="mb-4 text-danger"><i class="bi bi-calendar-check-fill me-2"></i> Manage Doctor Schedules</h1>
<hr>

<div class="card shadow-sm mb-4">
    <div class="card-header bg-primary text-white">
        <h5 class="mb-0">Add New Schedule Slot</h5>
    </div>
    <div class="card-body">
        <?= $message ?>
        <form action="schedule.php" method="POST">
            <input type="hidden" name="action" value="add_schedule">
            <div class="row g-3">
                <div class="col-md-3">
                    <select class="form-select" name="doctor_id" required>
                        <option value="" disabled selected>Select Doctor</option>
                        <?php foreach ($doctors as $doc): ?>
                            <option value="<?= $doc['docid'] ?>">Dr. <?= sanitize_output($doc['docname']) ?></option>
                        <?php endforeach; ?>
                    </select>
                </div>
                <div class="col-md-3">
                    <input type="text" class="form-control" name="title" placeholder="Schedule Title" required>
                </div>
                <div class="col-md-2">
                    <input type="date" class="form-control" name="date" required>
                </div>
                <div class="col-md-2">
                    <input type="time" class="form-control" name="time" required>
                </div>
                <div class="col-md-1">
                    <input type="number" class="form-control" name="nop" placeholder="NOP" required min="1">
                </div>
                <div class="col-md-1 d-grid">
                    <button type="submit" class="btn btn-primary">Save Slot</button>
                </div>
            </div>
        </form>
    </div>
</div>

<div class="card shadow-sm">
    <div class="card-header bg-danger text-white">
        <h5 class="mb-0">All Doctor Schedules (<?= count($schedules) ?>)</h5>
    </div>
    <div class="card-body">
        <?php if (count($schedules) > 0): ?>
        <div class="table-responsive">
            <table class="table table-striped table-hover">
                <thead>
                    <tr>
                        <th>ID</th>
                        <th>Doctor</th>
                        <th>Date</th>
                        <th>Time</th>
                        <th>Title</th>
                        <th>NOP</th>
                    </tr>
                </thead>
                <tbody>
                    <?php foreach ($schedules as $slot): ?>
                    <tr>
                        <td><?= sanitize_output($slot['scheduleid']) ?></td>
                        <td>Dr. <?= sanitize_output($slot['doctor_name']) ?></td>
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
        <div class="alert alert-info">No doctor schedules defined.</div>
        <?php endif; ?>
    </div>
</div>

<?php require_once __DIR__ . '/../includes/footer.php'; ?>