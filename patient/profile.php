<?php
require_once __DIR__ . '/../includes/auth.php';
require_role('patient');
$page_title = 'Patient Profile';
require_once __DIR__ . '/../includes/header.php';

$patient_id = $_SESSION['user_id'];
$message = '';

// **PDO Placeholder: Fetch Current Profile Data**
$stmt = $pdo->prepare("SELECT pname, pemail, ptel, paddress, pdob FROM patient WHERE pid = ?");
$stmt->execute([$patient_id]);
$current_data = $stmt->fetch();

if ($_SERVER['REQUEST_METHOD'] === 'POST') {
    $name = trim($_POST['name'] ?? $current_data['pname']);
    $phone = trim($_POST['phone'] ?? $current_data['ptel']);
    $address = trim($_POST['address'] ?? $current_data['paddress']);
    $dob = trim($_POST['dob'] ?? $current_data['pdob']);
    
    // **PDO Placeholder: Update Profile Data (patient_audit trigger placeholder)**
    $stmt_update = $pdo->prepare("UPDATE patient SET pname=?, ptel=?, paddress=?, pdob=? WHERE pid=?");
    $stmt_update->execute([$name, $phone, $address, $dob, $patient_id]);

    $message = '<div class="alert alert-success">Profile updated successfully! Check Admin -> Patient History for audit log (placeholder).</div>';
    
    // Re-fetch data for display
    $current_data['pname'] = $name;
    $current_data['ptel'] = $phone;
    $current_data['paddress'] = $address;
    $current_data['pdob'] = $dob;
    $_SESSION['username'] = $name; // Update session name
}
?>

<h1 class="mb-4 text-primary"><i class="bi bi-person-circle me-2"></i> My Profile</h1>
<hr>

<div class="card shadow-sm">
    <div class="card-body">
        <?= $message ?>
        <form action="profile.php" method="POST">
            <div class="row mb-3">
                <div class="col-md-6">
                    <label for="name" class="form-label">Full Name</label>
                    <input type="text" class="form-control" id="name" name="name" value="<?= sanitize_output($current_data['pname'] ?? '') ?>" required>
                </div>
                <div class="col-md-6">
                    <label for="email" class="form-label">Email Address (Read-Only)</label>
                    <input type="email" class="form-control" id="email" name="email" value="<?= sanitize_output($current_data['pemail'] ?? '') ?>" readonly>
                </div>
            </div>
            <div class="row mb-3">
                <div class="col-md-6">
                    <label for="phone" class="form-label">Phone Number</label>
                    <input type="tel" class="form-control" id="phone" name="phone" value="<?= sanitize_output($current_data['ptel'] ?? '') ?>" required>
                </div>
                <div class="col-md-6">
                    <label for="address" class="form-label">Address</label>
                    <input type="text" class="form-control" id="address" name="address" value="<?= sanitize_output($current_data['paddress'] ?? '') ?>">
                </div>
            </div>
            <div class="mb-3">
                <label for="dob" class="form-label">Date of Birth</label>
                <input type="date" class="form-control" id="dob" name="dob" value="<?= sanitize_output($current_data['pdob'] ?? '') ?>" required>
            </div>
            <button type="submit" class="btn btn-primary mt-3">Update Profile</button>
        </form>
    </div>
</div>

<?php require_once __DIR__ . '/../includes/footer.php'; ?>