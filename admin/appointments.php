<?php
require_once __DIR__ . '/../includes/auth.php';
require_role('admin');
$page_title = 'Manage Appointments';
require_once __DIR__ . '/../includes/header.php';

$message = '';

// Handle deletion (simulates status update/completion based on this schema)
if ($_SERVER['REQUEST_METHOD'] === 'POST' && isset($_POST['appt_id']) && isset($_POST['action'])) {
    $appt_id = (int)$_POST['appt_id'];
    $action = trim($_POST['action']);

    if ($action === 'delete') {
        // **PDO Placeholder: Delete Appointment**
        $stmt_delete = $pdo->prepare("DELETE FROM appointment WHERE appoid=?");
        
        if ($stmt_delete->execute([$appt_id])) {
            $message = '<div class="alert alert-success">Appointment ID ' . $appt_id . ' has been removed/completed.</div>';
        } else {
            $message = '<div class="alert alert-danger">Action failed.</div>';
        }
    }
}

// **PDO Placeholder: Fetch all Appointments**
$stmt = $pdo->prepare("SELECT a.appoid, a.apponum, s.scheduledate, s.scheduletime, s.title, 
    p.pname AS patient_name, d.docname AS doctor_name
    FROM appointment a 
    JOIN patient p ON a.pid = p.pid 
    JOIN schedule s ON a.scheduleid = s.scheduleid 
    JOIN doctor d ON s.docid = d.docid /* Link Doctor via Schedule */
    ORDER BY s.scheduledate DESC, s.scheduletime DESC");
$stmt->execute();
$appointments = $stmt->fetchAll();
?>

<h1 class="mb-4 text-danger"><i class="bi bi-clipboard-check-fill me-2"></i> All Appointments</h1>
<hr>

<div class="card shadow-sm">
    <div class="card-body">
        <?= $message ?>
        <?php if (count($appointments) > 0): ?>
        <div class="table-responsive">
            <table class="table table-striped table-hover">
                <thead>
                    <tr>
                        <th>ID</th>
                        <th>Appt. Num</th>
                        <th>Date & Time</th>
                        <th>Patient</th>
                        <th>Doctor</th>
                        <th>Description</th>
                        <th>Status</th>
                        <th>Action</th>
                    </tr>
                </thead>
                <tbody>
                    <?php foreach ($appointments as $appt): ?>
                    <?php 
                        $is_past = strtotime($appt['scheduledate']) < strtotime(date('Y-m-d'));
                        $status_text = $is_past ? 'Completed (Approx.)' : 'Scheduled';
                        $status_class = $is_past ? 'text-bg-success' : 'text-bg-info';
                    ?>
                    <tr>
                        <td><?= sanitize_output($appt['appoid']) ?></td>
                        <td>#<?= sanitize_output($appt['apponum']) ?></td>
                        <td><?= sanitize_output($appt['scheduledate']) ?> <br> <?= date('h:i A', strtotime($appt['scheduletime'])) ?></td>
                        <td><?= sanitize_output($appt['patient_name']) ?></td>
                        <td>Dr. <?= sanitize_output($appt['doctor_name']) ?></td>
                        <td><?= sanitize_output(substr($appt['title'], 0, 30)) ?>...</td>
                        <td>
                            <span class="badge <?= $status_class ?>">
                                <?= $status_text ?>
                            </span>
                        </td>
                        <td>
                            <form method="POST" class="d-inline-flex" onsubmit="return confirm('Permanently remove Appointment ID <?= $appt['appoid'] ?>?');">
                                <input type="hidden" name="appt_id" value="<?= $appt['appoid'] ?>">
                                <button type="submit" name="action" value="delete" class="btn btn-sm btn-danger me-2">Delete/Complete</button>
                            </form>
                            <a href="appointment-history.php?aid=<?= $appt['appoid'] ?>" class="btn btn-sm btn-outline-warning mt-1 mt-md-0">Audit</a>
                        </td>
                    </tr>
                    <?php endforeach; ?>
                </tbody>
            </table>
        </div>
        <?php else: ?>
        <div class="alert alert-info">No appointments found in the system.</div>
        <?php endif; ?>
    </div>
</div>

<?php require_once __DIR__ . '/../includes/footer.php'; ?>