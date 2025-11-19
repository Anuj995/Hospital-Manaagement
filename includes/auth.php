<?php
session_start();
require_once 'db.php'; // Assuming db.php is in the same directory

// Define the project's base path on the server.
// This MUST match your folder structure inside htdocs.
$base_path = '/hms_project/'; 

// Function to sanitize output
function sanitize_output($data) {
    return htmlspecialchars($data, ENT_QUOTES, 'UTF-8');
}

// Function to check if user is logged in
function is_logged_in() {
    return isset($_SESSION['user_id']) && isset($_SESSION['user_type']);
}

// Function to redirect users based on user type
function redirect_user($user_type) {
    global $base_path; // Use the global base path variable

    switch ($user_type) {
        case 'admin':
            header('Location: ' . $base_path . 'admin/index.php');
            break;
        case 'doctor':
            header('Location: ' . $base_path . 'doctor/index.php');
            break;
        case 'patient':
            header('Location: ' . $base_path . 'patient/index.php');
            break;
        default:
            header('Location: ' . $base_path . 'public/login.php');
            break;
    }
    exit;
}

// Check access permission for specific pages
function require_role($required_role) {
    global $base_path; // Use the global base path variable

    if (!is_logged_in()) {
        header('Location: ' . $base_path . 'public/login.php');
        exit;
    }

    $current_role = $_SESSION['user_type'];

    if ($current_role !== $required_role) {
        redirect_user($current_role);
    }
}

// Global Redirect Check on Login/Signup
if (basename($_SERVER['PHP_SELF']) === 'login.php' || basename($_SERVER['PHP_SELF']) === 'signup.php') {
    if (is_logged_in()) {
        redirect_user($_SESSION['user_type']);
    }
}
?>