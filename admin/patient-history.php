<?php
require_once __DIR__ . '/../includes/auth.php';
require_role('admin');
$page_title = 'Patient Update History (Audit)';
require_once __DIR__ . '/../includes/header.php';

// **PDO Placeholder: Fetch Patient Audit Logs**
// Query assumes patient_audit is linked to patient via patient_id = pid
$stmt_audit = $pdo->prepare("SELECT pa.*, p.pname AS patient_name 
    FROM patient_audit pa
    JOIN patient p ON pa.patient_id = p.pid 
    ORDER BY pa.changed_at DESC");
$stmt_audit->execute();
$audit_logs = $stmt_audit->fetchAll(); // This array is now the only data source
?>

<h1 class="mb-4 text-danger"><i class="bi bi-clock-history me-2"></i> Patient Update History (Audit)</h1>
<hr>

<div class="alert alert-info">
    This page displays logs from the **`patient_audit`** table, which should be populated by database triggers upon updating patient data.
</div>

<div class="card shadow-sm">
    <div class="card-header bg-warning text-dark">
        <h5 class="mb-0">Patient Profile Change Logs (<?= count($audit_logs) ?> entries)</h5>
    </div>
    <div class="card-body">
        <?php if (count($audit_logs) > 0): ?>
        <div class="table-responsive">
            <table class="table table-striped table-hover">
                <thead>
                    <tr>
                        <th>Log ID</th>
                        <th>Patient</th>
                        <th>Field Changed</th>
                        <th>Old Value</th>
                        <th>New Value</th>
                        <th>Changed At</th>
                        <th>Operation</th>
                    </tr>
                </thead>
                <tbody>
                    <?php foreach ($audit_logs as $log): ?>
                    <tr>
                        <td><?= sanitize_output($log['log_id']) ?></td>
                        <td><?= sanitize_output($log['patient_name']) ?> (ID: <?= sanitize_output($log['patient_id']) ?>)</td>
                        <td><?= sanitize_output($log['field_name']) ?></td>
                        <td><span class="text-danger"><?= sanitize_output($log['old_value']) ?></span></td>
                        <td><span class="text-success"><?= sanitize_output($log['new_value']) ?></span></td>
                        <td><?= sanitize_output($log['changed_at']) ?></td>
                        <td><span class="badge text-bg-secondary"><?= sanitize_output($log['operation']) ?></span></td>
                    </tr>
                    <?php endforeach; ?>
                </tbody>
            </table>
        </div>
        <?php else: ?>
        <div class="alert alert-light mb-0">No patient update history logs found in the database.</div>
        <?php endif; ?>
    </div>
</div>

<?php require_once __DIR__ . '/../includes/footer.php'; ?>