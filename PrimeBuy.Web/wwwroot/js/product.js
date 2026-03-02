// ===== PRODUCT DETAIL PAGE JS =====
document.addEventListener('DOMContentLoaded', () => {

    // --- Gallery Thumbnail Click ---
    const thumbs = document.querySelectorAll('.thumb-item');
    const mainImg = document.getElementById('mainImage');

    thumbs.forEach(thumb => {
        thumb.addEventListener('click', () => {
            thumbs.forEach(t => t.classList.remove('active'));
            thumb.classList.add('active');
            if (mainImg) {
                mainImg.src = thumb.getAttribute('data-img');
            }
        });
    });

    // --- Color Select ---
    const colorCircles = document.querySelectorAll('.color-circle');
    colorCircles.forEach(circle => {
        circle.addEventListener('click', () => {
            colorCircles.forEach(c => c.classList.remove('active'));
            circle.classList.add('active');
        });
    });

    // --- Size Select ---
    const sizeBtns = document.querySelectorAll('.size-btn');
    sizeBtns.forEach(btn => {
        btn.addEventListener('click', () => {
            sizeBtns.forEach(b => b.classList.remove('active'));
            btn.classList.add('active');
        });
    });

    // --- Quantity +/- ---
    const qtyValue = document.querySelector('.qty-value');
    const minusBtn = document.querySelector('.qty-btn.minus');
    const plusBtn = document.querySelector('.qty-btn.plus');

    if (minusBtn && plusBtn && qtyValue) {
        minusBtn.addEventListener('click', () => {
            let val = parseInt(qtyValue.value) || 1;
            if (val > 1) qtyValue.value = val - 1;
        });

        plusBtn.addEventListener('click', () => {
            let val = parseInt(qtyValue.value) || 1;
            if (val < 99) qtyValue.value = val + 1;
        });
    }

    // --- Buy Now Feedback ---
    const buyBtn = document.querySelector('.btn-buy-now');
    if (buyBtn) {
        buyBtn.addEventListener('click', () => {
            const original = buyBtn.textContent;
            buyBtn.textContent = 'Added!';
            buyBtn.style.background = 'var(--green)';
            buyBtn.style.color = '#000';
            setTimeout(() => {
                buyBtn.textContent = original;
                buyBtn.style.background = '';
                buyBtn.style.color = '';
            }, 1500);
        });
    }

    // --- Wishlist Toggle ---
    const wishBtn = document.querySelector('.btn-wish-detail');
    if (wishBtn) {
        wishBtn.addEventListener('click', () => {
            const icon = wishBtn.querySelector('i');
            icon.classList.toggle('bi-heart');
            icon.classList.toggle('bi-heart-fill');
            if (icon.classList.contains('bi-heart-fill')) {
                wishBtn.style.background = 'var(--primary)';
                wishBtn.style.color = 'var(--white)';
                wishBtn.style.borderColor = 'var(--primary)';
            } else {
                wishBtn.style.background = '';
                wishBtn.style.color = '';
                wishBtn.style.borderColor = '';
            }
        });
    }

    // --- Related Items Add to Cart ---
    document.querySelectorAll('.pd-add-cart').forEach(btn => {
        btn.addEventListener('click', () => {
            const original = btn.textContent;
            btn.textContent = 'Added!';
            btn.style.background = 'var(--green)';
            setTimeout(() => {
                btn.textContent = original;
                btn.style.background = '';
            }, 1500);
        });
    });
});
