<?php
require_once __DIR__ . '/../includes/auth.php';
require_role('admin');
$page_title = 'System Settings';
require_once __DIR__ . '/../includes/header.php';

$message = '';

// Handle specialty addition
if ($_SERVER['REQUEST_METHOD'] === 'POST' && isset($_POST['add_specialty'])) {
    $sname = trim($_POST['new_specialty'] ?? '');
    
    // **PDO Placeholder: Insert Specialty**
    $stmt_insert = $pdo->prepare("INSERT INTO specialties (sname) VALUES (?)");
    $stmt_insert->execute([$sname]);
    $message = '<div class="alert alert-success">Specialty added successfully.</div>';
}

// **PDO Placeholder: Fetch all Specialties**
$stmt_specs = $pdo->prepare("SELECT id, sname FROM specialties ORDER BY sname");
$stmt_specs->execute();
$specialties = $stmt_specs->fetchAll();
?>

<h1 class="mb-4 text-danger"><i class="bi bi-gear-fill me-2"></i> System Settings</h1>
<hr>

<div class="card shadow-sm">
    <div class="card-header bg-primary text-white">
        <h5 class="mb-0">Manage Specialties</h5>
    </div>
    <div class="card-body">
        <?= $message ?>
        <form action="settings.php" method="POST">
            <h5 class="mt-4">Add New Specialty</h5>
            <div class="row mb-3">
                <div class="col-md-8">
                    <input type="text" class="form-control" name="new_specialty" placeholder="New Specialty Name (e.g., Cardiology)" required>
                </div>
                <div class="col-md-4 d-grid">
                    <button type="submit" name="add_specialty" class="btn btn-outline-primary">Add Specialty</button>
                </div>
            </div>
        </