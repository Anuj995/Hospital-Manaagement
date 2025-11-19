<?php
require_once __DIR__ . '/../includes/auth.php';
require_role('admin');
$page_title = 'Admin Dashboard';
require_once __DIR__ . '/../includes/header.php';

// **PDO Placeholder: Count Total Doctors**
$stmt_doctors = $pdo->prepare("SELECT COUNT(*) FROM doctor");
$stmt_doctors->execute();
$total_doctors = $stmt_doctors->fetchColumn();

// **PDO Placeholder: Count Total Patients**
$stmt_patients = $pdo->prepare("SELECT COUNT(*) FROM patient");
$stmt_patients->execute();
$total_patients = $stmt_patients->fetchColumn();

// **PDO Placeholder: Count Today's Appointments**
$stmt_appointments = $pdo->prepare("SELECT COUNT(a.appoid) FROM appointment a JOIN schedule s ON a.scheduleid = s.scheduleid WHERE s.scheduledate = CURDATE()");
$stmt_appointments->execute();
$today_appointments = $stmt_appointments->fetchColumn();

// **PDO Placeholder: Count Patient Profile Updates (Audit)**
// --- FIX APPLIED HERE --- using the correct table name 'patient_audit'
$stmt_audit = $pdo->prepare("SELECT COUNT(*) FROM patient_audit");
$stmt_audit->execute();
$patient_updates = $stmt_audit->fetchColumn();

// **PDO Placeholder: Fetch Latest 5 Appointments**
$stmt_latest = $pdo->prepare("SELECT a.appoid, a.apponum, s.scheduledate, p.pname AS patient_name, d.docname AS doctor_name
    FROM appointment a 
    JOIN patient p ON a.pid = p.pid 
    JOIN schedule s ON a.scheduleid = s.scheduleid 
    JOIN doctor d ON s.docid = d.docid 
    ORDER BY a.appoid DESC 
    LIMIT 5");
$stmt_latest->execute();
$latest_appointments = $stmt_latest->fetchAll();
?>

<h1 class="mb-4 text-danger"><i class="bi bi-speedometer2 me-2"></i> Admin Dashboard</h1>
<hr>

<div class="row">
    <div class="col-lg-3 col-md-6 mb-4">
        <div class="card border-0 shadow-sm h-100 bg-primary text-white">
            <div class="card-body">
                <div class="row align-items-center">
                    <div class="col-auto"><i class="bi bi-person-badge-fill display-4"></i></div>
                    <div class="col">
                        <div class="text-uppercase fw-bold small">Total Doctors</div>
                        <div class="h2 mb-0"><?= $total_doctors ?></div>
                    </div>
                </div>
            </div>
            <div class="card-footer bg-transparent border-0">
                <a href="doctors.php" class="text-white small stretched-link">Manage Doctors <i class="bi bi-arrow-right"></i></a>
            </div>
        </div>
    </div>
    <div class="col-lg-3 col-md-6 mb-4">
        <div class="card border-0 shadow-sm h-100 bg-success text-white">
            <div class="card-body">
                <div class="row align-items-center">
                    <div class="col-auto"><i class="bi bi-people-fill display-4"></i></div>
                    <div class="col">
                        <div class="text-uppercase fw-bold small">Total Patients</div>
                        <div class="h2 mb-0"><?= $total_patients ?></div>
                    </div>
                </div>
            </div>
            <div class="card-footer bg-transparent border-0">
                <a href="patients.php" class="text-white small stretched-link">Manage Patients <i class="bi bi-arrow-right"></i></a>
            </div>
        </div>
    </div>
    <div class="col-lg-3 col-md-6 mb-4">
        <div class="card border-0 shadow-sm h-100 bg-info text-white">
            <div class="card-body">
                <div class="row align-items-center">
                    <div class="col-auto"><i class="bi bi-calendar-day display-4"></i></div>
                    <div class="col">
                        <div class="text-uppercase fw-bold small">Appointments Today</div>
                        <div class="h2 mb-0"><?= $today_appointments ?></div>
                    </div>
                </div>
            </div>
            <div class="card-footer bg-transparent border-0">
                <a href="appointments.php" class="text-white small stretched-link">View Today <i class="bi bi-arrow-right"></i></a>
            </div>
        </div>
    </div>
    <div class="col-lg-3 col-md-6 mb-4">
        <div class="card border-0 shadow-sm h-100 bg-warning text-dark">
            <div class="card-body">
                <div class="row align-items-center">
                    <div class="col-auto"><i class="bi bi-clock-history display-4"></i></div>
                    <div class="col">
                        <div class="text-uppercase fw-bold small">Patient Updates</div>
                        <div class="h2 mb-0"><?= $patient_updates ?></div>
                    </div>
                </div>
            </div>
            <div class="card-footer bg-transparent border-0">
                <a href="patient-history.php" class="text-dark small stretched-link">View Audit Logs <i class="bi bi-arrow-right"></i></a>
            </div>
        </div>
    </div>
</div>

<div class="card shadow mb-4">
    <div class="card-header bg-danger text-white">
        <h5 class="mb-0"><i class="bi bi-file-text me-2"></i> Latest Appointments</h5>
    </div>
    <div class="card-body">
        <?php if (count($latest_appointments) > 0): ?>
        <div class="table-responsive">
            <table class="table table-hover mb-0">
                <thead>
                    <tr>
                        <th>ID</th>
                        <th>Appt. Num</th>
                        <th>Date</th>
                        <th>Patient</th>
                        <th>Doctor</th>
                        <th>Status</th>
                    </tr>
                </thead>
                <tbody>
                    <?php foreach ($latest_appointments as $appt): ?>
                    <?php 
                        $is_past = strtotime($appt['scheduledate']) < strtotime(date('Y-m-d'));
                        $status_class = $is_past ? 'text-bg-success' : 'text-bg-info';
                        $status_text = $is_past ? 'Completed (Aprox.)' : 'Scheduled';
                    ?>
                    <tr>
                        <td><?= sanitize_output($appt['appoid']) ?></td>
                        <td>#<?= sanitize_output($appt['apponum']) ?></td>
                        <td><?= sanitize_output($appt['scheduledate']) ?></td>
                        <td><?= sanitize_output($appt['patient_name']) ?></td>
                        <td>Dr. <?= sanitize_output($appt['doctor_name']) ?></td>
                        <td>
                            <span class="badge <?= $status_class ?>">
                                <?= $status_text ?>
                            </span>
                        </td>
                    </tr>
                    <?php endforeach; ?>
                </tbody>
            </table>
        </div>
        <?php else: ?>
        <div class="alert alert-light mb-0">No appointments found.</div>
        <?php endif; ?>
    </div>
</div>

<?php require_once __DIR__ . '/../includes/footer.php'; ?>