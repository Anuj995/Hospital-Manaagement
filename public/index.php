<?php
require_once __DIR__ . '/../includes/auth.php';
$page_title = 'Welcome';
require_once __DIR__ . '/../includes/header.php';
?>

<div class="container text-center py-5">
    <h1 class="display-4 fw-bold text-primary mb-3">
        <i class="bi bi-heart-pulse-fill"></i> Hospital Management System
    </h1>
    <p class="lead mb-4">A complete solution for managing patient, doctor, and administrative records.</p>
    
    <div class="row justify-content-center">
        <div class="col-md-4 mb-3">
            <div class="card shadow-sm h-100">
                <div class="card-body">
                    <h5 class="card-title"><i class="bi bi-person-fill me-2"></i> Patient Portal</h5>
                    <p class="card-text">View appointments, update profile, and book new slots.</p>
                    <a href="signup.php" class="btn btn-outline-success me-2">Sign Up</a>
                    <a href="login.php" class="btn btn-success">Login</a>
                </div>
            </div>
        </div>
        <div class="col-md-4 mb-3">
            <div class="card shadow-sm h-100">
                <div class="card-body">
                    <h5 class="card-title"><i class="bi bi-person-badge-fill me-2"></i> Doctor/Admin Login</h5>
                    <p class="card-text">Access tools for scheduling, patient management, and admin controls.</p>
                    <a href="login.php" class="btn btn-primary">Login</a>
                </div>
            </div>
        </div>
    </div>

    <hr class="my-5">
    
    <h2 class="h3 mb-4">Our Services</h2>
    <div class="row">
        <div class="col-md-3">
            <i class="bi bi-calendar-check display-6 text-info mb-2"></i>
            <p>Online Appointments</p>
        </div>
        <div class="col-md-3">
            <i class="bi bi-file-earmark-medical display-6 text-info mb-2"></i>
            <p>Digital Health Records</p>
        </div>
        <div class="col-md-3">
            <i class="bi bi-person-lines-fill display-6 text-info mb-2"></i>
            <p>Doctor Profiles</p>
        </div>
        <div class="col-md-3">
            <i class="bi bi-shield-lock display-6 text-info mb-2"></i>
            <p>Secure Management</p>
        </div>
    </div>
</div>

<?php require_once __DIR__ . '/../includes/footer.php'; ?>