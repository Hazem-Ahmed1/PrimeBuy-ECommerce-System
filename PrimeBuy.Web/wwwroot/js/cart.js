// ===== CART PAGE JS =====
document.addEventListener('DOMContentLoaded', () => {

    // --- Recalculate row subtotals & cart total ---
    function recalculate() {
        let grandTotal = 0;
        document.querySelectorAll('.cart-table tbody tr[data-price]').forEach(row => {
            const price = parseInt(row.getAttribute('data-price'));
            const qty = parseInt(row.querySelector('.qty-spinner').value) || 1;
            const subtotal = price * qty;
            row.querySelector('.row-subtotal').textContent = '$' + subtotal;
            grandTotal += subtotal;
        });
        document.getElementById('cartSubtotal').textContent = '$' + grandTotal;
        document.getElementById('cartTotal').textContent = '$' + grandTotal;
    }

    // --- Quantity change ---
    document.querySelectorAll('.qty-spinner').forEach(input => {
        input.addEventListener('change', recalculate);
        input.addEventListener('input', recalculate);
    });

    // --- Remove item ---
    document.querySelectorAll('.remove-btn').forEach(btn => {
        btn.addEventListener('click', () => {
            const row = btn.closest('tr[data-price]');
            // Also remove the spacer row if present
            const next = row.nextElementSibling;
            row.style.transition = 'opacity 0.3s';
            row.style.opacity = '0';
            setTimeout(() => {
                if (next && next.classList.contains('spacer-row')) {
                    next.remove();
                }
                row.remove();
                recalculate();
                // Update badge
                const badge = document.querySelector('.cart-badge');
                if (badge) {
                    const remaining = document.querySelectorAll('.cart-table tbody tr[data-price]').length;
                    badge.textContent = remaining;
                }
            }, 300);
        });
    });

    // --- Update Cart Button ---
    const updateBtn = document.getElementById('updateCartBtn');
    if (updateBtn) {
        updateBtn.addEventListener('click', () => {
            recalculate();
            const originalText = updateBtn.textContent;
            updateBtn.textContent = 'Cart Updated!';
            updateBtn.style.background = 'var(--text-main)';
            updateBtn.style.color = 'var(--white)';
            updateBtn.style.borderColor = 'var(--text-main)';
            setTimeout(() => {
                updateBtn.textContent = originalText;
                updateBtn.style.background = '';
                updateBtn.style.color = '';
                updateBtn.style.borderColor = '';
            }, 1500);
        });
    }

    // --- Apply Coupon ---
    const couponBtn = document.getElementById('applyCouponBtn');
    if (couponBtn) {
        couponBtn.addEventListener('click', () => {
            const input = document.querySelector('.coupon-input');
            if (!input.value.trim()) {
                input.style.borderColor = 'var(--primary)';
                input.setAttribute('placeholder', 'Enter a coupon code');
                setTimeout(() => {
                    input.style.borderColor = '';
                    input.setAttribute('placeholder', 'Coupon Code');
                }, 2000);
                return;
            }
            const originalText = couponBtn.textContent;
            couponBtn.textContent = 'Applied!';
            couponBtn.style.background = 'var(--green)';
            couponBtn.style.color = '#000';
            setTimeout(() => {
                couponBtn.textContent = originalText;
                couponBtn.style.background = '';
                couponBtn.style.color = '';
            }, 2000);
        });
    }
});
