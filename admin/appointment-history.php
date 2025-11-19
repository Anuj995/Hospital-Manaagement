<?php
require_once __DIR__ . '/../includes/auth.php';
require_role('admin');
$page_title = 'Appointment Update History (Audit)';
require_once __DIR__ . '/../includes/header.php';

// **PDO Placeholder: Fetch Appointment Audit Logs**
// Query relies on linking appointment_audit (aa) -> appointment (a) -> patient (p) & doctor (d)
$stmt_audit = $pdo->prepare("SELECT aa.*, p.pname AS patient_name, d.docname AS doctor_name 
    FROM appointment_audit aa
    LEFT JOIN appointment a ON aa.appointment_id = a.appoid
    LEFT JOIN patient p ON aa.patient_id = p.pid
    LEFT JOIN doctor d ON aa.doctor_id = d.docid
    ORDER BY aa.changed_at DESC");

// Note: Using LEFT JOIN because the appointment might be deleted, but we still want the audit trail (aa).
$stmt_audit->execute();
$audit_logs = $stmt_audit->fetchAll();
?>

<h1 class="mb-4 text-danger"><i class="bi bi-journal-medical me-2"></i> Appointment Change Log (Audit)</h1>
<hr>

<div class="alert alert-info">
    This page displays logs from the **`appointment_audit`** table, which should be populated by database triggers upon changes (e.g., deletion/completion) to appointment data.
</div>

<div class="card shadow-sm">
    <div class="card-header bg-warning text-dark">
        <h5 class="mb-0">Appointment Status and Data Change Logs (<?= count($audit_logs) ?> entries)</h5>
    </div>
    <div class="card-body">
        <?php if (count($audit_logs) > 0): ?>
        <div class="table-responsive">
            <table class="table table-striped table-hover">
                <thead>
                    <tr>
                        <th>Log ID</th>
                        <th>Appt ID</th>
                        <th>Patient</th>
                        <th>Doctor</th>
                        <th>Action Performed</th>
                        <th>Changed At</th>
                        <th>Changed By (User Type)</th>
                    </tr>
                </thead>
                <tbody>
                    <?php foreach ($audit_logs as $log): ?>
                    <tr>
                        <td><?= sanitize_output($log['log_id']) ?></td>
                        <td><?= sanitize_output($log['appointment_id']) ?></td>
                        <td><?= sanitize_output($log['patient_name'] ?? 'N/A') ?></td>
                        <td>Dr. <?= sanitize_output($log['doctor_name'] ?? 'N/A') ?></td>
                        <td><span class="badge text-bg-dark"><?= sanitize_output($log['action_performed']) ?></span></td>
                        <td><?= sanitize_output($log['changed_at']) ?></td>
                        <td><span class="badge text-bg-secondary"><?= sanitize_output($log['changed_by_user_type']) ?></span></td>
                    </tr>
                    <?php endforeach; ?>
                </tbody>
            </table>
        </div>
        <?php else: ?>
        <div class="alert alert-light mb-0">No appointment change logs found in the database.</div>
        <?php endif; ?>
    </div>
</div>

<?php require_once __DIR__ . '/../includes/footer.php'; ?>