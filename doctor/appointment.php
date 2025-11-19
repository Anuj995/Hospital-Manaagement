<?php
require_once __DIR__ . '/../includes/auth.php';
require_role('doctor');
$page_title = 'Doctor Appointments';
require_once __DIR__ . '/../includes/header.php';

$doctor_id = $_SESSION['user_id'];
$message = '';

// Handle status update (simulated based on deletion for this schema)
if ($_SERVER['REQUEST_METHOD'] === 'POST' && isset($_POST['appt_id']) && isset($_POST['action'])) {
    $appt_id = (int)$_POST['appt_id'];
    $action = trim($_POST['action']);

    if ($action === 'complete' || $action === 'cancel') {
        // **PDO Placeholder: Delete/Complete Appointment**
        $stmt_update = $pdo->prepare("DELETE FROM appointment WHERE appoid=?");
        
        if ($stmt_update->execute([$appt_id])) {
            $status_text = ($action === 'complete') ? 'Completed' : 'Cancelled';
            $message = '<div class="alert alert-success">Appointment ID ' . $appt_id . ' marked as ' . $status_text . ' (Record deleted).</div>';
        } else {
            $message = '<div class="alert alert-danger">Action failed.</div>';
        }
    }
}

// **PDO Placeholder: Fetch all Doctor Appointments**
$stmt = $pdo->prepare("SELECT a.appoid, a.apponum, s.scheduledate, s.scheduletime, s.title, 
    p.pname AS patient_name, p.ptel AS patient_phone
    FROM appointment a 
    JOIN patient p ON a.pid = p.pid 
    JOIN schedule s ON a.scheduleid = s.scheduleid 
    WHERE s.docid = ? /* Filter appointments by schedule linked to this doctor */
    ORDER BY s.scheduledate DESC, s.scheduletime DESC");
$stmt->execute([$doctor_id]);
$appointments = $stmt->fetchAll();
?>

<h1 class="mb-4 text-success"><i class="bi bi-clipboard-list me-2"></i> Patient Appointments</h1>
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
                        <th>Phone</th>
                        <th>Description</th>
                        <th>Status</th>
                        <th>Action</th>
                    </tr>
                </thead>
                <tbody>
                    <?php foreach ($appointments as $appt): ?>
                    <?php 
                        $is_past = strtotime($appt['scheduledate']) < strtotime(date('Y-m-d'));
                        $status_text = $is_past ? 'Pending Review' : 'Scheduled';
                        $status_class = $is_past ? 'text-bg-warning' : 'text-bg-info';
                    ?>
                    <tr>
                        <td><?= sanitize_output($appt['appoid']) ?></td>
                        <td>#<?= sanitize_output($appt['apponum']) ?></td>
                        <td><?= sanitize_output($appt['scheduledate']) ?> <br> <?= date('h:i A', strtotime($appt['scheduletime'])) ?></td>
                        <td><?= sanitize_output($appt['patient_name']) ?></td>
                        <td><?= sanitize_output($appt['patient_phone']) ?></td>
                        <td><?= sanitize_output(substr($appt['title'], 0, 50)) ?>...</td>
                        <td>
                            <span class="badge <?= $status_class ?>">
                                <?= $status_text ?>
                            </span>
                        </td>
                        <td>
                            <form method="POST" class="d-inline-flex">
                                <input type="hidden" name="appt_id" value="<?= $appt['appoid'] ?>">
                                <?php if (!$is_past): ?>
                                    <button type="submit" name="action" value="cancel" class="btn btn-sm btn-danger me-2" onclick="return confirm('Cancel this appointment? This removes the record.');">Cancel</button>
                                <?php endif; ?>
                                <button type="submit" name="action" value="complete" class="btn btn-sm btn-success" onclick="return confirm('Mark as Completed? This removes the record.');">Complete</button>
                            </form>
                        </td>
                    </tr>
                    <?php endforeach; ?>
                </tbody>
            </table>
        </div>
        <?php else: ?>
        <div class="alert alert-info">You have no appointments scheduled.</div>
        <?php endif; ?>
    </div>
</div>

<?php require_once __DIR__ . '/../includes/footer.php'; ?>