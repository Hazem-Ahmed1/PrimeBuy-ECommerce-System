// ===== CONTACT PAGE JS =====
document.addEventListener('DOMContentLoaded', () => {
    const form = document.getElementById('contactForm');
    if (!form) return;

    form.addEventListener('submit', (e) => {
        e.preventDefault();

        const inputs = form.querySelectorAll('.contact-input');
        let valid = true;

        inputs.forEach(input => {
            if (input.hasAttribute('required') && !input.value.trim()) {
                input.style.boxShadow = 'inset 0 0 0 1.5px var(--primary)';
                valid = false;
                setTimeout(() => { input.style.boxShadow = ''; }, 2000);
            }
        });

        if (!valid) return;

        const btn = form.querySelector('.btn-send-message');
        const original = btn.textContent;
        btn.textContent = 'Message Sent!';
        btn.style.background = 'var(--green)';
        btn.style.color = '#000';

        setTimeout(() => {
            btn.textContent = original;
            btn.style.background = '';
            btn.style.color = '';
            form.reset();
        }, 2000);
    });
});
