/* =========================================================
   Scroll Animations — Intersection Observer
   Global usage across all pages (storefront + admin)
   ========================================================= */

document.addEventListener('DOMContentLoaded', () => {
    const animatedElements = document.querySelectorAll('[data-animate]');
    if (!animatedElements.length) return;

    const observer = new IntersectionObserver((entries) => {
        entries.forEach(entry => {
            if (entry.isIntersecting) {
                const el = entry.target;
                const delay = el.getAttribute('data-animate-delay');
                if (delay) {
                    el.style.transitionDelay = delay;
                }
                el.classList.add('animated');
                observer.unobserve(el);
            }
        });
    }, {
        threshold: 0.15,
        rootMargin: '0px 0px -50px 0px'
    });

    animatedElements.forEach(el => observer.observe(el));
});
