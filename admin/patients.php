<?php
require_once __DIR__ . '/../includes/auth.php';
require_role('admin');
$page_title = 'Manage Patients';
require_once __DIR__ . '/../includes/header.php';

$message = '';

// Handle Delete Patient
if ($_SERVER['REQUEST_METHOD'] === 'POST' && isset($_POST['delete_pid'])) {
    $delete_pid = (int)$_POST['delete_pid'];
    // **PDO Placeholder: Delete Patient**
    $stmt_delete = $pdo->prepare("DELETE FROM patient WHERE pid=?");
    $stmt_delete->execute([$delete_pid]);
    $message = '<div class="alert alert-success">Patient ID ' . $delete_pid . ' removed.</div>';
}

// **PDO Placeholder: Fetch all Patients**
$stmt_patients = $pdo->prepare("SELECT pid, pname, pemail, ptel, paddress, pdob FROM patient ORDER BY pname");
$stmt_patients->execute();
$patients = $stmt_patients->fetchAll();
?>

<h1 class="mb-4 text-danger"><i class="bi bi-people-fill me-2"></i> Manage Patients</h1>
<hr>

<div class="card shadow-sm">
    <div class="card-header bg-danger text-white">
        <h5 class="mb-0">Registered Patients (<?= count($patients) ?>)</h5>
    </div>
    <div class="card-body">
        <?= $message ?>
        <?php if (count($patients) > 0): ?>
        <div class="table-responsive">
            <table class="table table-striped table-hover">
                <thead>
                    <tr>
                        <th>ID</th>
                        <th>Name</th>
                        <th>Email</th>
                        <th>Phone</th>
                        <th>Address</th>
                        <th>Action</th>
                    </tr>
                </thead>
                <tbody>
                    <?php foreach ($patients as $patient): ?>
                    <tr>
                        <td><?= sanitize_output($patient['pid']) ?></td>
                        <td><?= sanitize_output($patient['pname']) ?></td>
                        <td><?= sanitize_output($patient['pemail']) ?></td>
                        <td><?= sanitize_output($patient['ptel']) ?></td>
                        <td><?= sanitize_output(substr($patient['paddress'] ?? 'N/A', 0, 40)) ?></td>
                        <td>
                            <a href="patient-history.php?pid=<?= $patient['pid'] ?>" class="btn btn-sm btn-outline-warning">History</a>
                            <form method="POST" class="d-inline" onsubmit="return confirm('Are you sure you want to delete patient <?= sanitize_output($patient['pname']) ?>? This action is irreversible.');">
                                <input type="hidden" name="delete_pid" value="<?= $patient['pid'] ?>">
                                <button type="submit" class="btn btn-sm btn-danger">Delete</button>
                            </form>
                        </td>
                    </tr>
                    <?php endforeach; ?>
                </tbody>
            </table>
        </div>
        <?php else: ?>
        <div class="alert alert-info">No patients registered yet.</div>
        <?php endif; ?>
    </div>
</div>

<?php require_once __DIR__ . '/../includes/footer.php'; ?>