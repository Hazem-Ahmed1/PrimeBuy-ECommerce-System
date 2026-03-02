// ===== WISHLIST PAGE JS =====

document.addEventListener('DOMContentLoaded', () => {

    // --- Delete item from wishlist ---
    const wishlistGrid = document.getElementById('wishlistGrid');
    if (wishlistGrid) {
        wishlistGrid.addEventListener('click', (e) => {
            const deleteBtn = e.target.closest('.delete-btn');
            if (!deleteBtn) return;

            const card = deleteBtn.closest('.col-6, .col-md-4, .col-lg-3');
            if (card) {
                card.style.transition = 'opacity 0.3s, transform 0.3s';
                card.style.opacity = '0';
                card.style.transform = 'scale(0.9)';
                setTimeout(() => {
                    card.remove();
                    updateWishlistCount();
                }, 300);
            }
        });
    }

    // --- Update wishlist count ---
    function updateWishlistCount() {
        const countEl = document.getElementById('wishlistCount');
        const items = wishlistGrid ? wishlistGrid.querySelectorAll('.wishlist-card') : [];
        if (countEl) countEl.textContent = items.length;

        // Update badge in header
        const badge = document.querySelector('.icon-link .cart-badge');
        if (badge) badge.textContent = items.length;
    }

    // --- Add To Cart feedback ---
    const addCartBtns = document.querySelectorAll('.add-cart-bar');
    addCartBtns.forEach(btn => {
        btn.addEventListener('click', () => {
            const originalHTML = btn.innerHTML;
            btn.innerHTML = '<i class="bi bi-check-lg"></i> Added!';
            btn.style.background = '#00FF66';
            btn.style.color = '#000';

            setTimeout(() => {
                btn.innerHTML = originalHTML;
                btn.style.background = '';
                btn.style.color = '';
            }, 1500);
        });
    });

});
