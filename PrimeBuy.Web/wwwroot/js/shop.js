// ===== SHOP PAGE JS =====
document.addEventListener('DOMContentLoaded', () => {

    // --- Mobile Filter Sidebar ---
    const filterToggle = document.getElementById('filterToggle');
    const filterSidebar = document.getElementById('filterSidebar');
    const filterOverlay = document.getElementById('filterOverlay');
    const filterClose = document.getElementById('filterClose');

    function openFilter() {
        filterSidebar.classList.add('open');
        filterOverlay.classList.add('show');
        document.body.style.overflow = 'hidden';
    }

    function closeFilter() {
        filterSidebar.classList.remove('open');
        filterOverlay.classList.remove('show');
        document.body.style.overflow = '';
    }

    if (filterToggle) filterToggle.addEventListener('click', openFilter);
    if (filterClose) filterClose.addEventListener('click', closeFilter);
    if (filterOverlay) filterOverlay.addEventListener('click', closeFilter);

    // --- Collapsible Filter Groups ---
    document.querySelectorAll('.filter-group-title[data-toggle="filter"]').forEach(title => {
        title.addEventListener('click', () => {
            title.classList.toggle('collapsed');
            const body = title.nextElementSibling;
            if (body) {
                if (title.classList.contains('collapsed')) {
                    body.style.maxHeight = '0';
                    body.style.overflow = 'hidden';
                    body.style.opacity = '0';
                    body.style.marginTop = '0';
                } else {
                    body.style.maxHeight = '';
                    body.style.overflow = '';
                    body.style.opacity = '';
                    body.style.marginTop = '';
                }
            }
        });
    });

    // --- Price Range Slider ---
    const priceRange = document.getElementById('priceRange');
    const priceValue = document.getElementById('priceValue');
    if (priceRange && priceValue) {
        priceRange.addEventListener('input', () => {
            priceValue.textContent = '$' + priceRange.value;
        });
    }

    // --- Color Swatches ---
    document.querySelectorAll('.color-swatch').forEach(swatch => {
        swatch.addEventListener('click', () => {
            swatch.classList.toggle('active');
        });
    });

    // --- Category Filter Active ---
    document.querySelectorAll('.filter-list a').forEach(link => {
        link.addEventListener('click', (e) => {
            e.preventDefault();
            document.querySelectorAll('.filter-list a').forEach(l => l.classList.remove('active'));
            link.classList.add('active');
        });
    });

    // --- Grid / List View Toggle ---
    const viewBtns = document.querySelectorAll('.view-btn');
    const productsGrid = document.getElementById('productsGrid');

    viewBtns.forEach(btn => {
        btn.addEventListener('click', () => {
            viewBtns.forEach(b => b.classList.remove('active'));
            btn.classList.add('active');
            const view = btn.getAttribute('data-view');
            if (view === 'list') {
                productsGrid.classList.add('list-view');
            } else {
                productsGrid.classList.remove('list-view');
            }
        });
    });

    // --- Add to Cart Feedback ---
    document.querySelectorAll('.shop-add-cart').forEach(btn => {
        btn.addEventListener('click', () => {
            const original = btn.textContent;
            btn.textContent = 'Added!';
            btn.style.background = 'var(--green)';
            btn.style.color = '#000';
            setTimeout(() => {
                btn.textContent = original;
                btn.style.background = '';
                btn.style.color = '';
            }, 1500);
        });
    });

    // --- Wishlist Toggle ---
    document.querySelectorAll('.wish-btn').forEach(btn => {
        btn.addEventListener('click', () => {
            const icon = btn.querySelector('i');
            icon.classList.toggle('bi-heart');
            icon.classList.toggle('bi-heart-fill');
            if (icon.classList.contains('bi-heart-fill')) {
                btn.style.background = 'var(--primary)';
                btn.style.color = 'var(--white)';
            } else {
                btn.style.background = '';
                btn.style.color = '';
            }
        });
    });

    // --- Pagination Active ---
    document.querySelectorAll('.page-btn:not(.disabled)').forEach(btn => {
        btn.addEventListener('click', () => {
            document.querySelectorAll('.page-btn').forEach(b => b.classList.remove('active'));
            btn.classList.add('active');
        });
    });

    // --- Apply Filter Feedback ---
    const applyBtn = document.getElementById('applyFilterBtn');
    if (applyBtn) {
        applyBtn.addEventListener('click', () => {
            const original = applyBtn.textContent;
            applyBtn.textContent = 'Filters Applied!';
            applyBtn.style.background = 'var(--green)';
            applyBtn.style.color = '#000';
            // Close mobile sidebar if open
            closeFilter();
            setTimeout(() => {
                applyBtn.textContent = original;
                applyBtn.style.background = '';
                applyBtn.style.color = '';
            }, 1500);
        });
    }
});
