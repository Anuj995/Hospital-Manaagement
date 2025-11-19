// Custom JavaScript for Hospital Management System

document.addEventListener('DOMContentLoaded', function() {
    // Check if the sidebar toggle button exists and attach the event listener
    const sidebarToggle = document.getElementById('sidebarToggle');
    const wrapper = document.getElementById('wrapper');

    if (sidebarToggle && wrapper) {
        sidebarToggle.addEventListener('click', function() {
            // This is handled in includes/footer.php for simplicity and ensuring it works
            // wrapper.classList.toggle('toggled');
        });
    }

    // Example of simple form validation using Bootstrap's built-in validation feedback
    const forms = document.querySelectorAll('.needs-validation');

    Array.prototype.slice.call(forms)
        .forEach(function (form) {
            form.addEventListener('submit', function (event) {
                if (!form.checkValidity()) {
                    event.preventDefault();
                    event.stopPropagation();
                }
                form.classList.add('was-validated');
            }, false);
        });
});