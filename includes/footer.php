<?php
$base_path = '/hms_project/'; // MUST BE CORRECT
$user_type = $_SESSION['user_type'] ?? 'guest'; 
?>
<?php if ($user_type !== 'guest'): ?>
        </div></div></div><?php endif; ?>

<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js"></script>
<script src="<?= $base_path ?>assets/js/script.js"></script>

<script>
    // Sidebar toggle functionality for dashboard pages
    <?php if ($user_type !== 'guest'): ?>
    var sidebarToggle = document.getElementById('sidebarToggle');
    var wrapper = document.getElementById('wrapper');
    if (sidebarToggle && wrapper) {
        sidebarToggle.addEventListener('click', function () {
            wrapper.classList.toggle('toggled');
        });
    }
    <?php endif; ?>
</script>
</body>
</html>