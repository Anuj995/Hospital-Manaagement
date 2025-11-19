<?php
if (session_status() == PHP_SESSION_NONE) {
    session_start();
}
// Assume $page_title is set in the calling script
$page_title = $page_title ?? 'HMS Dashboard';
$user_type = $_SESSION['user_type'] ?? 'guest';
$base_path = '/hms_project/'; // MUST BE CORRECT

$nav_links = [
    'admin' => [
        ['url' => $base_path . 'admin/index.php', 'icon' => 'house-fill', 'text' => 'Dashboard'],
        ['url' => $base_path . 'admin/doctors.php', 'icon' => 'person-badge-fill', 'text' => 'Doctors'],
        ['url' => $base_path . 'admin/patients.php', 'icon' => 'people-fill', 'text' => 'Patients'],
        ['url' => $base_path . 'admin/schedule.php', 'icon' => 'calendar-check-fill', 'text' => 'Schedule'],
        ['url' => $base_path . 'admin/appointments.php', 'icon' => 'clipboard-check-fill', 'text' => 'Appointments'],
        ['url' => $base_path . 'admin/patient-history.php', 'icon' => 'clock-history', 'text' => 'Patient History'],
        ['url' => $base_path . 'admin/appointment-history.php', 'icon' => 'journal-medical', 'text' => 'Appointment Audit'],
        ['url' => $base_path . 'admin/settings.php', 'icon' => 'gear-fill', 'text' => 'Settings']
    ],
    'doctor' => [
        ['url' => $base_path . 'doctor/index.php', 'icon' => 'house-fill', 'text' => 'Dashboard'],
        ['url' => $base_path . 'doctor/profile.php', 'icon' => 'person-circle', 'text' => 'Profile'],
        ['url' => $base_path . 'doctor/schedule.php', 'icon' => 'calendar-week', 'text' => 'My Schedule'],
        ['url' => $base_path . 'doctor/appointment.php', 'icon' => 'calendar2-check', 'text' => 'Appointments']
    ],
    'patient' => [
        ['url' => $base_path . 'patient/index.php', 'icon' => 'house-fill', 'text' => 'Dashboard'],
        ['url' => $base_path . 'patient/profile.php', 'icon' => 'person-circle', 'text' => 'My Profile'],
        ['url' => $base_path . 'patient/booking.php', 'icon' => 'calendar-plus', 'text' => 'Book Appointment'],
        ['url' => $base_path . 'patient/appointment.php', 'icon' => 'calendar-event', 'text' => 'My Appointments']
    ]
];
?>
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title><?= sanitize_output($page_title) ?> | HMS</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet">
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.11.3/font/bootstrap-icons.min.css">
    <link rel="stylesheet" href="<?= $base_path ?>assets/css/style.css">
</head>
<body>
<?php if ($user_type !== 'guest'): ?>
<div class="d-flex" id="wrapper">
    <div class="bg-dark border-end" id="sidebar-wrapper">
        <div class="sidebar-heading text-white p-3 border-bottom border-secondary">
            <i class="bi bi-hospital me-2"></i> **HMS Portal**
        </div>
        <div class="list-group list-group-flush">
            <?php foreach ($nav_links[$user_type] ?? [] as $link): ?>
                <a href="<?= $link['url'] ?>" class="list-group-item list-group-item-action list-group-item-dark p-3 
                    <?= (basename($_SERVER['PHP_SELF']) == basename($link['url'])) ? 'active' : '' ?>">
                    <i class="bi bi-<?= $link['icon'] ?> me-2"></i>
                    <?= $link['text'] ?>
                </a>
            <?php endforeach; ?>
        </div>
    </div>
    <div id="page-content-wrapper">
        <nav class="navbar navbar-expand-lg navbar-light bg-light border-bottom">
            <div class="container-fluid">
                <button class="btn btn-primary" id="sidebarToggle"><i class="bi bi-list"></i></button>
                <div class="collapse navbar-collapse" id="navbarSupportedContent">
                    <ul class="navbar-nav ms-auto mt-2 mt-lg-0">
                        <li class="nav-item dropdown">
                            <a class="nav-link dropdown-toggle" href="#" id="navbarDropdown" role="button" data-bs-toggle="dropdown" aria-expanded="false">
                                <i class="bi bi-person-circle me-1"></i>
                                <?= sanitize_output($_SESSION['username'] ?? 'User') ?> (<?= ucfirst($user_type) ?>)
                            </a>
                            <ul class="dropdown-menu dropdown-menu-end" aria-labelledby="navbarDropdown">
                                <?php if ($user_type !== 'admin'): ?>
                                <li><a class="dropdown-item" href="<?= $base_path . $user_type ?>/profile.php">Profile</a></li>
                                <li><hr class="dropdown-divider"></li>
                                <?php endif; ?>
                                <li><a class="dropdown-item text-danger" href="<?= $base_path ?>logout.php"><i class="bi bi-box-arrow-right"></i> Logout</a></li>
                            </ul>
                        </li>
                    </ul>
                </div>
            </div>
        </nav>
        <div class="container-fluid py-4">
<?php else: ?>
    <?php endif; ?>