<?php
require_once __DIR__ . '/../includes/auth.php';
require_role('doctor');
$page_title = 'Doctor Profile';
require_once __DIR__ . '/../includes/header.php';

$doctor_id = $_SESSION['user_id'];
$message = '';

// **PDO Placeholder: Fetch Current Profile Data**
$stmt = $pdo->prepare("SELECT docname, docemail, doctel, specialties FROM doctor WHERE docid = ?");
$stmt->execute([$doctor_id]);
$current_data = $stmt->fetch();

// **PDO Placeholder: Fetch all Specialties**
$stmt_specs = $pdo->prepare("SELECT id, sname FROM specialties ORDER BY sname");
$stmt_specs->execute();
$specialties = $stmt_specs->fetchAll();

if ($_SERVER['REQUEST_METHOD'] === 'POST') {
    $name = trim($_POST['name'] ?? $current_data['docname']);
    $phone = trim($_POST['phone'] ?? $current_data['doctel']);
    $specialty_name = trim($_POST['specialty_name'] ?? $current_data['specialties']);
    
    // **PDO Placeholder: Update Profile Data**
    $stmt_update = $pdo->prepare("UPDATE doctor SET docname=?, doctel=?, specialties=? WHERE docid=?");
    $stmt_update->execute([$name, $phone, $specialty_name, $doctor_id]);

    $message = '<div class="alert alert-success">Profile updated successfully!</div>';
    
    // Re-fetch data for display
    $current_data['docname'] = $name;
    $current_data['doctel'] = $phone;
    $current_data['specialties'] = $specialty_name;
    $_SESSION['username'] = $name; // Update session name
}
?>

<h1 class="mb-4 text-success"><i class="bi bi-person-circle me-2"></i> My Profile</h1>
<hr>

<div class="card shadow-sm">
    <div class="card-body">
        <?= $message ?>
        <form action="profile.php" method="POST">
            <div class="row mb-3">
                <div class="col-md-6">
                    <label for="name" class="form-label">Full Name</label>
                    <input type="text" class="form-control" id="name" name="name" value="<?= sanitize_output($current_data['docname'] ?? '') ?>" required>
                </div>
                <div class="col-md-6">
                    <label for="email" class="form-label">Email Address (Read-Only)</label>
                    <input type="email" class="form-control" id="email" name="email" value="<?= sanitize_output($current_data['docemail'] ?? '') ?>" readonly>
                </div>
            </div>
            <div class="row mb-3">
                <div class="col-md-6">
                    <label for="specialty_name" class="form-label">Specialty</label>
                    <select class="form-select" id="specialty_name" name="specialty_name" required>
                        <option value="" disabled>Select Specialty</option>
                        <?php foreach ($specialties as $spec): ?>
                            <option value="<?= $spec['sname'] ?>" 
                                <?= ($current_data['specialties'] == $spec['sname']) ? 'selected' : '' ?>>
                                <?= sanitize_output($spec['sname']) ?>
                            </option>
                        <?php endforeach; ?>
                    </select>
                </div>
                <div class="col-md-6">
                    <label for="phone" class="form-label">Phone Number</label>
                    <input type="tel" class="form-control" id="phone" name="phone" value="<?= sanitize_output($current_data['doctel'] ?? '') ?>">
                </div>
            </div>
            <button type="submit" class="btn btn-success mt-3">Update Profile</button>
        </form>
    </div>
</div>

<?php require_once __DIR__ . '/../includes/footer.php'; ?>