// ===== ACCOUNT PAGE JS =====
document.addEventListener('DOMContentLoaded', () => {

    // --- Profile Form Submit ---
    const profileForm = document.getElementById('profileForm');
    if (profileForm) {
        profileForm.addEventListener('submit', (e) => {
            e.preventDefault();

            const btn = profileForm.querySelector('.btn-primary-custom');
            const originalText = btn.textContent;
            btn.textContent = 'Saved!';
            btn.style.background = 'var(--green)';
            btn.style.color = '#000';

            setTimeout(() => {
                btn.textContent = originalText;
                btn.style.background = '';
                btn.style.color = '';
            }, 2000);
        });
    }

    // --- Cancel Button ---
    const cancelBtn = document.querySelector('.btn-cancel');
    if (cancelBtn) {
        cancelBtn.addEventListener('click', () => {
            profileForm.reset();
        });
    }

    // --- Sidebar Active Link ---
    const sidebarLinks = document.querySelectorAll('.sidebar-menu a');
    sidebarLinks.forEach(link => {
        link.addEventListener('click', (e) => {
            e.preventDefault();
            sidebarLinks.forEach(l => l.classList.remove('active'));
            link.classList.add('active');
        });
    });
});
