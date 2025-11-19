<?php
require_once __DIR__ . '/../includes/auth.php';
require_role('doctor');
$page_title = 'Doctor Dashboard';
require_once __DIR__ . '/../includes/header.php';

$doctor_id = $_SESSION['user_id'];

// **PDO Placeholder: Fetch Doctor Info**
$stmt_info = $pdo->prepare("SELECT docname FROM doctor WHERE docid = ?");
$stmt_info->execute([$doctor_id]);
$doctor_name = $stmt_info->fetchColumn() ?? 'Doctor';

// **PDO Placeholder: Count Today's Appointments**
$stmt_today = $pdo->prepare("SELECT COUNT(a.appoid) FROM appointment a JOIN schedule s ON a.scheduleid = s.scheduleid WHERE s.docid = ? AND s.scheduledate = CURDATE()");
$stmt_today->execute([$doctor_id]);
$today_appointments = $stmt_today->fetchColumn();

// **PDO Placeholder: Count All Scheduled Appointments**
$stmt_total = $pdo->prepare("SELECT COUNT(a.appoid) FROM appointment a JOIN schedule s ON a.scheduleid = s.scheduleid WHERE s.docid = ?");
$stmt_total->execute([$doctor_id]);
$total_appointments = $stmt_total->fetchColumn();

// **PDO Placeholder: Fetch Today's Appointments**
$stmt_today_list = $pdo->prepare("SELECT a.appoid, a.apponum, s.scheduletime, s.title, p.pname AS patient_name 
    FROM appointment a 
    JOIN patient p ON a.pid = p.pid 
    JOIN schedule s ON a.scheduleid = s.scheduleid 
    WHERE s.docid = ? AND a.appodate = CURDATE() 
    ORDER BY s.scheduletime");
$stmt_today_list->execute([$doctor_id]);
$today_list = $stmt_today_list->fetchAll();
?>

<h1 class="mb-4 text-success"><i class="bi bi-person-badge-fill me-2"></i> Dr. <?= sanitize_output($doctor_name) ?>'s Dashboard</h1>
<hr>

<div class="row">
    <div class="col-lg-4 col-md-6 mb-4">
        <div class="card border-0 shadow-sm h-100 bg-success text-white">
            <div class="card-body">
                <div class="row align-items-center">
                    <div class="col-auto">
                        <i class="bi bi-calendar-day display-4"></i>
                    </div>
                    <div class="col">
                        <div class="text-uppercase fw-bold small">Appointments Today</div>
                        <div class="h2 mb-0"><?= $today_appointments ?></div>
                    </div>
                </div>
            </div>
            <div class="card-footer bg-transparent border-0">
                <a href="appointment.php" class="text-white small stretched-link">View Today's List <i class="bi bi-arrow-right"></i></a>
            </div>
        </div>
    </div>
    <div class="col-lg-4 col-md-6 mb-4">
        <div class="card border-0 shadow-sm h-100 bg-info text-white">
            <div class="card-body">
                <div class="row align-items-center">
                    <div class="col-auto">
                        <i class="bi bi-clipboard-list display-4"></i>
                    </div>
                    <div class="col">
                        <div class="text-uppercase fw-bold small">Total Scheduled</div>
                        <div class="h2 mb-0"><?= $total_appointments ?></div>
                    </div>
                </div>
            </div>
            <div class="card-footer bg-transparent border-0">
                <a href="appointment.php" class="text-white small stretched-link">All Appointments <i class="bi bi-arrow-right"></i></a>
            </div>
        </div>
    </div>
    <div class="col-lg-4 col-md-6 mb-4">
        <div class="card border-0 shadow-sm h-100 bg-warning text-dark">
            <div class="card-body">
                <div class="row align-items-center">
                    <div class="col-auto">
                        <i class="bi bi-calendar-week display-4"></i>
                    </div>
                    <div class="col">
                        <div class="text-uppercase fw-bold small">Manage Time</div>
                        <div class="h2 mb-0">My Schedule</div>
                    </div>
                </div>
            </div>
            <div class="card-footer bg-transparent border-0">
                <a href="schedule.php" class="text-dark small stretched-link">Update Availability <i class="bi bi-arrow-right"></i></a>
            </div>
        </div>
    </div>
</div>

<div class="card shadow mb-4">
    <div class="card-header bg-success text-white">
        <h5 class="mb-0"><i class="bi bi-list-task me-2"></i> Today's Patient List (<?= date('Y-m-d') ?>)</h5>
    </div>
    <div class="card-body">
        <?php if (count($today_list) > 0): ?>
        <div class="table-responsive">
            <table class="table table-hover mb-0">
                <thead>
                    <tr>
                        <th>Time</th>
                        <th>Appt. Num</th>
                        <th>Patient Name</th>
                        <th>Description</th>
                        <th>Action</th>
                    </tr>
                </thead>
                <tbody>
                    <?php foreach ($today_list as $appt): ?>
                    <tr>
                        <td><?= date('h:i A', strtotime($appt['scheduletime'])) ?></td>
                        <td>#<?= sanitize_output($appt['apponum']) ?></td>
                        <td><?= sanitize_output($appt['patient_name']) ?></td>
                        <td><?= sanitize_output(substr($appt['title'], 0, 80)) ?>...</td>
                        <td><a href="appointment.php?id=<?= $appt['appoid'] ?>" class="btn btn-sm btn-outline-success">View</a></td>
                    </tr>
                    <?php endforeach; ?>
                </tbody>
            </table>
        </div>
        <?php else: ?>
        <div class="alert alert-light mb-0">No appointments scheduled for today.</div>
        <?php endif; ?>
    </div>
</div>

<?php require_once __DIR__ . '/../includes/footer.php'; ?>