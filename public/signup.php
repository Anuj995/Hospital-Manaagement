<?php
require_once __DIR__ . '/../includes/auth.php';
$page_title = 'Patient Sign Up';
require_once __DIR__ . '/../includes/header.php';

$message = '';

if ($_SERVER['REQUEST_METHOD'] === 'POST') {
    $name = trim($_POST['name'] ?? '');
    $email = trim($_POST['email'] ?? '');
    $password = $_POST['password'] ?? '';
    $phone = trim($_POST['phone'] ?? '');
    $address = trim($_POST['address'] ?? '');
    $dob = trim($_POST['dob'] ?? '');

    if (empty($name) || empty($email) || empty($password) || empty($phone) || empty($address) || empty($dob)) {
        $message = '<div class="alert alert-danger">Please fill in all required fields.</div>';
    } else {
        // 🔥 BASIC/INSECURE: Using raw password for insertion
        
        try {
            // **PDO Placeholder Query to check for existing patient**
            $stmt = $pdo->prepare("SELECT COUNT(*) FROM patient WHERE pemail = ?");
            $stmt->execute([$email]);
            $count = $stmt->fetchColumn();

            if ($count > 0) {
                $message = '<div class="alert alert-warning">Email already registered. Please log in.</div>';
            } else {
                // **PDO Placeholder Query for Patient Registration**
                $stmt = $pdo->prepare("INSERT INTO patient (pname, paddress, pdob, pemail, ppassword, ptel) VALUES (?, ?, ?, ?, ?, ?)");
                $stmt->execute([$name, $address, $dob, $email, $password, $phone]); // Inserting $password directly

                $message = '<div class="alert alert-success">Registration successful! Redirecting to login...</div>';
                header('Refresh: 3; URL=login.php');
            }
        } catch (PDOException $e) {
            error_log("Patient sign up error: " . $e->getMessage());
            $message = '<div class="alert alert-danger">An error occurred during registration.</div>';
        }
    }
}
?>

<div class="container my-5">
    <div class="row justify-content-center">
        <div class="col-md-6">
            <div class="card shadow-lg border-0 rounded-lg">
                <div class="card-header bg-success text-white text-center">
                    <h3 class="fw-light my-2">Patient Sign Up</h3>
                </div>
                <div class="card-body">
                    <?= $message ?>
                    <form action="signup.php" method="POST">
                        <div class="mb-3">
                            <label for="name" class="form-label">Full Name</label>
                            <input type="text" class="form-control" id="name" name="name" required value="<?= sanitize_output($_POST['name'] ?? '') ?>">
                        </div>
                        <div class="mb-3">
                            <label for="email" class="form-label">Email address</label>
                            <input type="email" class="form-control" id="email" name="email" required value="<?= sanitize_output($_POST['email'] ?? '') ?>">
                        </div>
                        <div class="mb-3">
                            <label for="phone" class="form-label">Phone Number</label>
                            <input type="tel" class="form-control" id="phone" name="phone" required value="<?= sanitize_output($_POST['phone'] ?? '') ?>">
                        </div>
                        <div class="mb-3">
                            <label for="address" class="form-label">Address</label>
                            <input type="text" class="form-control" id="address" name="address" required value="<?= sanitize_output($_POST['address'] ?? '') ?>">
                        </div>
                        <div class="mb-3">
                            <label for="dob" class="form-label">Date of Birth</label>
                            <input type="date" class="form-control" id="dob" name="dob" required value="<?= sanitize_output($_POST['dob'] ?? '') ?>">
                        </div>
                        <div class="mb-3">
                            <label for="password" class="form-label">Password</label>
                            <input type="password" class="form-control" id="password" name="password" required>
                        </div>
                        <div class="d-grid">
                            <button type="submit" class="btn btn-success btn-block mt-3">Register</button>
                        </div>
                    </form>
                </div>
                <div class="card-footer text-center py-3">
                    <div class="small"><a href="login.php">Already have an account? Login!</a></div>
                </div>
            </div>
        </div>
    </div>
</div>

<?php require_once __DIR__ . '/../includes/footer.php'; ?>