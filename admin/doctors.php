<?php
require_once __DIR__ . '/../includes/auth.php';
require_role('admin');
$page_title = 'Manage Doctors';
require_once __DIR__ . '/../includes/header.php';

$message = '';

// Handle Add/Edit Doctor Form Submission
if ($_SERVER['REQUEST_METHOD'] === 'POST' && isset($_POST['action'])) {
    $action = $_POST['action'];
    $name = trim($_POST['name'] ?? '');
    $email = trim($_POST['email'] ?? '');
    $phone = trim($_POST['phone'] ?? '');
    $specialty_id = (int)$_POST['specialty_id'] ?? 0;
    $password = $_POST['new_password'] ?? null; 
    $docnic = trim($_POST['docnic'] ?? ''); // 🔥 NEW: Capture docnic

    if ($action === 'add') {
        if (empty($password)) {
            $message = '<div class="alert alert-danger">Please set a password for the new doctor.</div>';
        } else {
            // **PDO Placeholder: Insert New Doctor**
            // 🔥 NEW: Added docnic to the column list and execute array
            $stmt_insert = $pdo->prepare("INSERT INTO doctor (docname, docemail, doctel, specialties, docpassword, docnic) VALUES (?, ?, ?, ?, ?, ?)");
            $stmt_insert->execute([$name, $email, $phone, $specialty_id, $password, $docnic]);
            $message = '<div class="alert alert-success">Doctor **' . sanitize_output($name) . '** added successfully!</div>';
        }
    } elseif ($action === 'edit' && isset($_POST['docid'])) {
        $docid = (int)$_POST['docid'];
        // **PDO Placeholder: Update Doctor** (Update query needs to be adjusted if docnic is editable)
        // For simplicity, updating docnic only if the field is present (assuming it is included in the modal later)
        $stmt_update = $pdo->prepare("UPDATE doctor SET docname=?, docemail=?, doctel=?, specialties=? WHERE docid=?");
        $stmt_update->execute([$name, $email, $phone, $specialty_id, $docid]);
        $message = '<div class="alert alert-success">Doctor updated successfully!</div>';
    }
}

// Handle Delete Doctor
if ($_SERVER['REQUEST_METHOD'] === 'POST' && isset($_POST['delete_docid'])) {
    $delete_docid = (int)$_POST['delete_docid'];
    // **PDO Placeholder: Delete Doctor**
    $stmt_delete = $pdo->prepare("DELETE FROM doctor WHERE docid=?");
    $stmt_delete->execute([$delete_docid]);
    $message = '<div class="alert alert-success">Doctor ID ' . $delete_docid . ' removed.</div>';
}

// **PDO Placeholder: Fetch all Doctors** (Fetch docnic for display)
$stmt_doctors = $pdo->prepare("SELECT d.docid, d.docname, d.docemail, d.doctel, d.docnic, d.specialties AS specialties_id, sp.sname AS specialty_name_display
    FROM doctor d 
    JOIN specialties sp ON d.specialties = sp.id
    ORDER BY d.docname");
$stmt_doctors->execute();
$doctors = $stmt_doctors->fetchAll();

// **PDO Placeholder: Fetch all Specialties**
$stmt_specs = $pdo->prepare("SELECT id, sname FROM specialties ORDER BY sname");
$stmt_specs->execute();
$specialties = $stmt_specs->fetchAll();
?>

<h1 class="mb-4 text-danger"><i class="bi bi-person-badge-fill me-2"></i> Manage Doctors</h1>
<hr>

<div class="card shadow-sm mb-4">
    <div class="card-header bg-primary text-white">
        <h5 class="mb-0">Add New Doctor</h5>
    </div>
    <div class="card-body">
        <?= $message ?>
        <form action="doctors.php" method="POST">
            <input type="hidden" name="action" value="add">
            <div class="row g-3">
                <div class="col-md-2 mb-3">
                    <input type="text" class="form-control" name="name" placeholder="Full Name" required>
                </div>
                <div class="col-md-2 mb-3">
                    <input type="email" class="form-control" name="email" placeholder="Email" required>
                </div>
                
                <div class="col-md-2 mb-3"> 
                    <input type="password" class="form-control" name="new_password" placeholder="Set Password" required>
                </div>
                
                <div class="col-md-2 mb-3"> 
                    <input type="text" class="form-control" name="docnic" placeholder="NIC Number" required>
                </div>

                <div class="col-md-2 mb-3">
                    <input type="tel" class="form-control" name="phone" placeholder="Phone">
                </div>
                <div class="col-md-1 mb-3">
                    <select class="form-select" name="specialty_id" required>
                        <option value="" disabled selected>Specialty</option> 
                        <?php foreach ($specialties as $spec): ?>
                            <option value="<?= $spec['id'] ?>"><?= sanitize_output($spec['sname']) ?></option>
                        <?php endforeach; ?>
                    </select>
                </div>
                <div class="col-md-1 mb-3 d-grid">
                    <button type="submit" class="btn btn-primary">Add Doctor</button>
                </div>
            </div>
        </form>
    </div>
</div>

<div class="card shadow-sm">
    <div class="card-header bg-danger text-white">
        <h5 class="mb-0">Existing Doctors (<?= count($doctors) ?>)</h5>
    </div>
    <div class="card-body">
        <?php if (count($doctors) > 0): ?>
        <div class="table-responsive">
            <table class="table table-striped table-hover">
                <thead>
                    <tr>
                        <th>ID</th>
                        <th>Name</th>
                        <th>Email</th>
                        <th>NIC</th> <th>Phone</th>
                        <th>Specialty</th>
                        <th>Action</th>
                    </tr>
                </thead>
                <tbody>
                    <?php foreach ($doctors as $doctor): ?>
                    <tr>
                        <td><?= sanitize_output($doctor['docid']) ?></td>
                        <td><?= sanitize_output($doctor['docname']) ?></td>
                        <td><?= sanitize_output($doctor['docemail']) ?></td>
                        <td><?= sanitize_output($doctor['docnic']) ?></td> <td><?= sanitize_output($doctor['doctel']) ?></td>
                        <td><?= sanitize_output($doctor['specialty_name_display']) ?></td>
                        <td>
                            <button type="button" class="btn btn-sm btn-outline-info" data-bs-toggle="modal" data-bs-target="#editModal<?= $doctor['docid'] ?>">Edit</button>
                            <form method="POST" class="d-inline" onsubmit="return confirm('Are you sure you want to delete Dr. <?= sanitize_output($doctor['docname']) ?>?');">
                                <input type="hidden" name="delete_docid" value="<?= $doctor['docid'] ?>">
                                <button type="submit" class="btn btn-sm btn-danger">Delete</button>
                            </form>
                        </td>
                    </tr>

                    <div class="modal fade" id="editModal<?= $doctor['docid'] ?>" tabindex="-1" aria-labelledby="editModalLabel" aria-hidden="true">
                        <div class="modal-dialog">
                            <div class="modal-content">
                                <form action="doctors.php" method="POST">
                                    <div class="modal-header bg-info text-white">
                                        <h5 class="modal-title" id="editModalLabel">Edit Doctor: <?= sanitize_output($doctor['docname']) ?></h5>
                                        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                                    </div>
                                    <div class="modal-body">
                                        <input type="hidden" name="action" value="edit">
                                        <input type="hidden" name="docid" value="<?= $doctor['docid'] ?>">
                                        <div class="mb-3"><label for="edit_name">Name</label><input type="text" class="form-control" id="edit_name" name="name" value="<?= sanitize_output($doctor['docname']) ?>" required></div>
                                        <div class="mb-3"><label for="edit_email">Email</label><input type="email" class="form-control" id="edit_email" name="email" value="<?= sanitize_output($doctor['docemail']) ?>" required></div>
                                        
                                        <div class="mb-3"><label for="edit_nic">NIC</label><input type="text" class="form-control" id="edit_nic" name="docnic" value="<?= sanitize_output($doctor['docnic']) ?>" required></div>
                                        
                                        <div class="mb-3"><label for="edit_phone">Phone</label><input type="tel" class="form-control" id="edit_phone" name="phone" value="<?= sanitize_output($doctor['doctel']) ?>"></div>
                                        <div class="mb-3">
                                            <label for="edit_specialty">Specialty</label>
                                            <select class="form-select" id="edit_specialty" name="specialty_id" required>
                                                <option value="" disabled>Select Specialty</option> 
                                                <?php foreach ($specialties as $spec): ?>
                                                    <option value="<?= $spec['id'] ?>" <?= ($doctor['specialties_id'] == $spec['id']) ? 'selected' : '' ?>>
                                                        <?= sanitize_output($spec['sname']) ?>
                                                    </option>
                                                <?php endforeach; ?>
                                            </select>
                                        </div>
                                    </div>
                                    <div class="modal-footer">
                                        <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
                                        <button type="submit" class="btn btn-info">Save changes</button>
                                    </div>
                                </form>
                            </div>
                        </div>
                    </div>
                    <?php endforeach; ?>
                </tbody>
            </table>
        </div>
        <?php else: ?>
        <div class="alert alert-info">No doctors registered yet.</div>
        <?php endif; ?>
    </div>
</div>

<?php require_once __DIR__ . '/../includes/footer.php'; ?>