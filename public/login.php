<?php
require_once __DIR__ . '/../includes/auth.php';
$page_title = 'Login';
require_once __DIR__ . '/../includes/header.php';

$message = '';

if ($_SERVER['REQUEST_METHOD'] === 'POST') {
    $email = trim($_POST['email'] ?? '');
    $password = $_POST['password'] ?? '';
    $user_type = $_POST['user_type'] ?? '';

    if (empty($email) || empty($password) || empty($user_type)) {
        $message = '<div class="alert alert-danger">Please fill in all fields.</div>';
    } else {
        // --- FIX: Updated Admin Column Mapping to use minimal schema ---
        $user_map = match ($user_type) {
            // Admin: Uses 'aemail' for ID and Name, as 'adid' and 'adname' are missing.
            'admin' => ['table' => 'admin', 'email_col' => 'aemail', 'id_col' => 'aemail', 'pass_col' => 'apassword', 'name_col' => 'aemail'], 
            'doctor' => ['table' => 'doctor', 'email_col' => 'docemail', 'id_col' => 'docid', 'pass_col' => 'docpassword', 'name_col' => 'docname'],
            'patient' => ['table' => 'patient', 'email_col' => 'pemail', 'id_col' => 'pid', 'pass_col' => 'ppassword', 'name_col' => 'pname'],
            default => null
        };

        if ($user_map === null) {
            $message = '<div class="alert alert-danger">Invalid user type selected.</div>';
        } else {
            // The SELECT query still works by targeting the correct email column (aemail, docemail, or pemail)
            $sql = "SELECT * FROM {$user_map['table']} WHERE {$user_map['email_col']} = ?";
            $stmt = $pdo->prepare($sql);
            $stmt->execute([$email]);
            $user = $stmt->fetch();

            // 🔥 BASIC/INSECURE LOGIN CHECK: Comparing raw password from POST with DB password
            if ($user && $password === $user[$user_map['pass_col']]) {
                
                // --- FIX: Session variables use 'aemail' for ID/Username ---
                if ($user_type === 'admin') {
                    $_SESSION['user_id'] = $user['aemail']; // Use email as unique identifier
                    $_SESSION['username'] = $user['aemail']; // Display email as username
                } else {
                    $_SESSION['user_id'] = $user[$user_map['id_col']]; 
                    $_SESSION['username'] = $user[$user_map['name_col']] ?? $email;
                }
                
                $_SESSION['user_type'] = $user_type;
                redirect_user($user_type);
            } else {
                $message = '<div class="alert alert-danger">Invalid credentials or user type.</div>';
            }
        }
    }
}
?>

<div class="container my-5">
    <div class="row justify-content-center">
        <div class="col-md-5">
            <div class="card shadow-lg border-0 rounded-lg">
                <div class="card-header bg-primary text-white text-center">
                    <h3 class="fw-light my-2">Login to HMS</h3>
                </div>
                <div class="card-body">
                    <?= $message ?>
                    <form action="login.php" method="POST">
                        <div class="mb-3">
                            <label for="user_type" class="form-label">User Type</label>
                            <select class="form-select" id="user_type" name="user_type" required>
                                <option value="" disabled selected>Select your role</option>
                                <option value="patient">Patient</option>
                                <option value="doctor">Doctor</option>
                                <option value="admin">Admin</option>
                            </select>
                        </div>
                        <div class="mb-3">
                            <label for="email" class="form-label">Email address</label>
                            <input type="email" class="form-control" id="email" name="email" required>
                        </div>
                        <div class="mb-3">
                            <label for="password" class="form-label">Password</label>
                            <input type="password" class="form-control" id="password" name="password" required>
                        </div>
                        <div class="d-grid">
                            <button type="submit" class="btn btn-primary btn-block mt-3">Login</button>
                        </div>
                    </form>
                </div>
                <div class="card-footer text-center py-3">
                    <div class="small"><a href="signup.php">Need an account? Sign up!</a></div>
                </div>
            </div>
        </div>
    </div>
</div>

<?php require_once __DIR__ . '/../includes/footer.php'; ?>