// Script for CnttLayoutProduct
const helloWorld = () => {
    console.log("Hello, World! CNTT - Session 07 Layout");
};

helloWorld();

// Active link highlighting for navigation
document.addEventListener("DOMContentLoaded", () => {
    const currentPath = window.location.pathname.toLowerCase();
    const navLinks = document.querySelectorAll(".product-nav ul li a");

    navLinks.forEach(link => {
        const href = link.getAttribute("href") ? link.getAttribute("href").toLowerCase() : "";
        if (href && (currentPath === href || (href !== "/" && currentPath.startsWith(href)))) {
            link.classList.add("active");
        }

        link.addEventListener("click", function () {
            navLinks.forEach(l => l.classList.remove("active"));
            this.classList.add("active");
        });
    });
});
