<?php
require_once __DIR__ . '/../includes/auth.php';
require_role('patient');
$page_title = 'My Appointments';
require_once __DIR__ . '/../includes/header.php';

$patient_id = $_SESSION['user_id'];
$message = '';

// Handle cancellation (still deletes the appointment record)
if ($_SERVER['REQUEST_METHOD'] === 'POST' && isset($_POST['cancel_id'])) {
    $cancel_id = (int)$_POST['cancel_id'];
    
    $stmt_cancel = $pdo->prepare("DELETE FROM appointment WHERE appoid=? AND pid=? AND appodate > CURDATE()");
    if ($stmt_cancel->execute([$cancel_id, $patient_id])) {
        $message = '<div class="alert alert-success">Appointment ID ' . $cancel_id . ' has been cancelled.</div>';
    } else {
        $message = '<div class="alert alert-danger">Cancellation failed or appointment date is in the past.</div>';
    }
}

// **PDO Placeholder: Fetch all Patient Appointments**
$stmt = $pdo->prepare("SELECT a.appoid, a.appodate, a.apponum, s.scheduletime, d.docname AS doctor_name, sp.sname AS specialty_name_display, s.title 
    FROM appointment a 
    JOIN schedule s ON a.scheduleid = s.scheduleid 
    JOIN doctor d ON s.docid = d.docid 
    JOIN specialties sp ON d.specialties = sp.id /* FIX: Join specialties table */
    WHERE a.pid = ? 
    ORDER BY a.appodate DESC, s.scheduletime DESC");
$stmt->execute([$patient_id]);
$appointments = $stmt->fetchAll();
?>

<h1 class="mb-4 text-primary"><i class="bi bi-calendar-event me-2"></i> My Appointments</h1>
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
                        <th>Date</th>
                        <th>Time</th>
                        <th>Doctor</th>
                        <th>Specialty</th>
                        <th>Description</th>
                        <th>Status</th>
                        <th>Action</th>
                    </tr>
                </thead>
                <tbody>
                    <?php foreach ($appointments as $appt): ?>
                    <?php 
                        $is_past = strtotime($appt['appodate']) < strtotime(date('Y-m-d'));
                        $status_text = $is_past ? 'Completed' : 'Scheduled';
                        $status_class = $is_past ? 'text-bg-success' : 'text-bg-info';
                    ?>
                    <tr>
                        <td><?= sanitize_output($appt['appoid']) ?></td>
                        <td>#<?= sanitize_output($appt['apponum']) ?></td>
                        <td><?= sanitize_output($appt['appodate']) ?></td>
                        <td><?= date('h:i A', strtotime($appt['scheduletime'])) ?></td>
                        <td>Dr. <?= sanitize_output($appt['doctor_name']) ?></td>
                        <td><?= sanitize_output($appt['specialty_name_display']) ?></td>
                        <td><?= sanitize_output(substr($appt['title'], 0, 50)) ?>...</td>
                        <td>
                            <span class="badge <?= $status_class ?>">
                                <?= $status_text ?>
                            </span>
                        </td>
                        <td>
                            <?php if (!$is_past): ?>
                                <form method="POST" onsubmit="return confirm('Are you sure you want to cancel this appointment?');">
                                    <input type="hidden" name="cancel_id" value="<?= $appt['appoid'] ?>">
                                    <button type="submit" class="btn btn-sm btn-outline-danger">Cancel</button>
                                </form>
                            <?php else: ?>
                                <button class="btn btn-sm btn-secondary" disabled>No Action</button>
                            <?php endif; ?>
                        </td>
                    </tr>
                    <?php endforeach; ?>
                </tbody>
            </table>
        </div>
        <?php else: ?>
        <div class="alert alert-info">You have no recorded appointments. <a href="booking.php">Book your first one!</a></div>
        <?php endif; ?>
    </div>
</div>

<?php require_once __DIR__ . '/../includes/footer.php'; ?>