// ===== SHARED JS — runs on all pages =====

// --- Scroll to Top ---
function initScrollTop() {
    const scrollTopBtn = document.getElementById('scrollTop');
    if (!scrollTopBtn) return;

    window.addEventListener('scroll', () => {
        if (window.scrollY > 400) {
            scrollTopBtn.classList.add('visible');
        } else {
            scrollTopBtn.classList.remove('visible');
        }
    });

    scrollTopBtn.addEventListener('click', () => {
        window.scrollTo({ top: 0, behavior: 'smooth' });
    });
}

// --- Navbar Active Highlight ---
function initNavbar() {
    const navLinks = document.querySelectorAll('.nav-link');
    navLinks.forEach(link => {
        link.addEventListener('click', () => {
            navLinks.forEach(l => l.classList.remove('active'));
            link.classList.add('active');
        });
    });
}

// --- Form Validation ---
function initFormValidation() {
    const forms = document.querySelectorAll('#signupForm, #loginForm');
    forms.forEach(form => {
        const inputs = form.querySelectorAll('.form-input');

        // Validate on submit
        form.addEventListener('submit', (e) => {
            let isValid = true;
            inputs.forEach(input => {
                if (!validateInput(input)) isValid = false;
            });
            if (!isValid) e.preventDefault();
        });

        // Clear error on input
        inputs.forEach(input => {
            input.addEventListener('input', () => {
                clearError(input);
            });
            // Show error on blur if empty
            input.addEventListener('blur', () => {
                validateInput(input);
            });
        });
    });
}

function validateInput(input) {
    const group = input.closest('.input-group-auth');
    if (!group) return true;
    const errorSpan = group.querySelector('.error-msg span');
    const label = input.dataset.label || 'This field';

    // Required check
    if (input.hasAttribute('required') && !input.value.trim()) {
        showError(group, errorSpan, `${label} is required`);
        return false;
    }

    // Email format (if the field looks like an email field and has @)
    if (label.toLowerCase().includes('email') && input.value.includes('@')) {
        const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
        if (!emailRegex.test(input.value.trim())) {
            showError(group, errorSpan, 'Please enter a valid email address');
            return false;
        }
    }

    // Password min length
    if (input.type === 'password' && input.minLength > 0 && input.value.length < input.minLength) {
        showError(group, errorSpan, `Password must be at least ${input.minLength} characters`);
        return false;
    }

    clearError(input);
    return true;
}

function showError(group, errorSpan, message) {
    group.classList.add('has-error');
    errorSpan.textContent = message;
}

function clearError(input) {
    const group = input.closest('.input-group-auth');
    if (group) group.classList.remove('has-error');
}

// --- User Account Dropdown ---
function initUserDropdown() {
    const btn = document.getElementById('userDropdownBtn');
    const dropdown = document.getElementById('userDropdown');
    if (!btn || !dropdown) return;

    btn.addEventListener('click', (e) => {
        e.stopPropagation();
        const isOpen = dropdown.classList.contains('show');
        dropdown.classList.toggle('show');
        btn.classList.toggle('active', !isOpen);
    });

    document.addEventListener('click', (e) => {
        if (!e.target.closest('.user-dropdown-wrapper')) {
            dropdown.classList.remove('show');
            btn.classList.remove('active');
        }
    });
}

// --- Init shared features ---
document.addEventListener('DOMContentLoaded', () => {
    initScrollTop();
    initNavbar();
    initFormValidation();
    initUserDropdown();
});
