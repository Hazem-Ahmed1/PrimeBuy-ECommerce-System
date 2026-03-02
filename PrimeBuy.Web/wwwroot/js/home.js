// ===== HOME PAGE JS =====

// --- Flash Sale Countdown Timer ---
function startCountdown() {
    const now = new Date();
    const endDate = new Date(now.getTime() + 3 * 24 * 60 * 60 * 1000 + 23 * 60 * 60 * 1000 + 19 * 60 * 1000 + 56 * 1000);

    function updateTimer() {
        const now = new Date();
        const diff = endDate - now;

        if (diff <= 0) {
            document.getElementById('days').textContent = '00';
            document.getElementById('hours').textContent = '00';
            document.getElementById('minutes').textContent = '00';
            document.getElementById('seconds').textContent = '00';
            return;
        }

        const days = Math.floor(diff / (1000 * 60 * 60 * 24));
        const hours = Math.floor((diff % (1000 * 60 * 60 * 24)) / (1000 * 60 * 60));
        const minutes = Math.floor((diff % (1000 * 60 * 60)) / (1000 * 60));
        const seconds = Math.floor((diff % (1000 * 60)) / 1000);

        document.getElementById('days').textContent = String(days).padStart(2, '0');
        document.getElementById('hours').textContent = String(hours).padStart(2, '0');
        document.getElementById('minutes').textContent = String(minutes).padStart(2, '0');
        document.getElementById('seconds').textContent = String(seconds).padStart(2, '0');
    }

    updateTimer();
    setInterval(updateTimer, 1000);
}

// --- Product Slider ---
function initSlider(sliderId, prevBtnId, nextBtnId) {
    const slider = document.getElementById(sliderId);
    if (!slider) return;

    const prevBtn = document.getElementById(prevBtnId);
    const nextBtn = document.getElementById(nextBtnId);
    let scrollAmount = 0;
    const cardWidth = 270;

    if (nextBtn) {
        nextBtn.addEventListener('click', () => {
            scrollAmount += cardWidth;
            const maxScroll = slider.scrollWidth - slider.parentElement.offsetWidth;
            if (scrollAmount > maxScroll) scrollAmount = maxScroll;
            slider.style.transform = `translateX(-${scrollAmount}px)`;
        });
    }

    if (prevBtn) {
        prevBtn.addEventListener('click', () => {
            scrollAmount -= cardWidth;
            if (scrollAmount < 0) scrollAmount = 0;
            slider.style.transform = `translateX(-${scrollAmount}px)`;
        });
    }
}

// --- Category Card Click ---
function initCategoryCards() {
    const categoryCards = document.querySelectorAll('.category-card');
    categoryCards.forEach(card => {
        card.addEventListener('click', () => {
            categoryCards.forEach(c => c.classList.remove('active'));
            card.classList.add('active');
        });
    });
}

// --- Add to Cart Animation ---
function initAddToCart() {
    const addToCartBtns = document.querySelectorAll('.add-to-cart-btn');
    addToCartBtns.forEach(btn => {
        btn.addEventListener('click', (e) => {
            e.preventDefault();
            const originalText = btn.textContent;
            btn.textContent = 'Added!';
            btn.style.background = '#00FF66';
            btn.style.color = '#000';

            setTimeout(() => {
                btn.textContent = originalText;
                btn.style.background = '';
                btn.style.color = '';
            }, 1500);
        });
    });
}

// --- Wishlist Toggle ---
function initWishlist() {
    const wishlistBtns = document.querySelectorAll('.product-actions .action-btn:first-child');
    wishlistBtns.forEach(btn => {
        btn.addEventListener('click', () => {
            const icon = btn.querySelector('i');
            if (icon.classList.contains('bi-heart')) {
                icon.classList.remove('bi-heart');
                icon.classList.add('bi-heart-fill');
                btn.style.background = '#DB4444';
                btn.style.color = '#fff';
            } else {
                icon.classList.remove('bi-heart-fill');
                icon.classList.add('bi-heart');
                btn.style.background = '#fff';
                btn.style.color = '#000';
            }
        });
    });
}

// --- Init Home Page ---
document.addEventListener('DOMContentLoaded', () => {
    startCountdown();
    initSlider('flashSlider', 'flashPrev', 'flashNext');
    initCategoryCards();
    initAddToCart();
    initWishlist();
});
