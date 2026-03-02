// ===== CHECKOUT PAGE JS =====

document.addEventListener('DOMContentLoaded', () => {

    const form = document.getElementById('checkoutForm');
    const placeOrderBtn = document.getElementById('placeOrderBtn');

    // --- Place Order: validate required billing fields ---
    if (placeOrderBtn && form) {
        placeOrderBtn.addEventListener('click', (e) => {
            const requiredFields = form.querySelectorAll('.form-field[required]');
            let isValid = true;

            requiredFields.forEach(field => {
                // Reset
                field.style.boxShadow = '';

                if (!field.value.trim()) {
                    field.style.boxShadow = '0 0 0 2px rgba(219, 68, 68, 0.5)';
                    isValid = false;
                }
            });

            // Email format
            const emailField = form.querySelector('input[type="email"]');
            if (emailField && emailField.value.trim()) {
                const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
                if (!emailRegex.test(emailField.value.trim())) {
                    emailField.style.boxShadow = '0 0 0 2px rgba(219, 68, 68, 0.5)';
                    isValid = false;
                }
            }

            if (!isValid) {
                e.preventDefault();
                // Scroll to first invalid field
                const firstError = form.querySelector('.form-field[style*="rgba(219"]');
                if (firstError) firstError.focus();
            } else {
                // Success feedback
                placeOrderBtn.textContent = 'Order Placed!';
                placeOrderBtn.style.background = '#00FF66';
                placeOrderBtn.style.color = '#000';
                placeOrderBtn.disabled = true;

                setTimeout(() => {
                    placeOrderBtn.textContent = 'Place Order';
                    placeOrderBtn.style.background = '';
                    placeOrderBtn.style.color = '';
                    placeOrderBtn.disabled = false;
                }, 2000);
            }
        });

        // Clear error on input
        form.querySelectorAll('.form-field').forEach(field => {
            field.addEventListener('input', () => {
                field.style.boxShadow = '';
            });
        });
    }

    // --- Apply Coupon feedback ---
    const couponBtn = document.querySelector('.btn-coupon');
    if (couponBtn) {
        couponBtn.addEventListener('click', () => {
            const input = document.querySelector('.coupon-row input');
            if (input && input.value.trim()) {
                const original = couponBtn.textContent;
                couponBtn.textContent = 'Applied!';
                couponBtn.style.background = '#00FF66';
                couponBtn.style.color = '#000';

                setTimeout(() => {
                    couponBtn.textContent = original;
                    couponBtn.style.background = '';
                    couponBtn.style.color = '';
                }, 1500);
            }
        });
    }
});
