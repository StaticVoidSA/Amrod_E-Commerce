document.addEventListener("DOMContentLoaded", () => {
    const sidebar = document.getElementById("sidebar");
    const toggleBtn = document.getElementById("sidebarToggle");
    const themeBtn = document.getElementById("themeToggle");
    const body = document.getElementById("body");

    // Theme
    const savedTheme = localStorage.getItem("theme") || "dark-theme";
    body.classList.remove("light-theme", "dark-theme");
    body.classList.add(savedTheme);

    themeBtn.checked = savedTheme === 'light-theme';

    // Toggle logic
    toggleBtn.addEventListener("click", (e) => {
        e.stopPropagation();

        if (window.innerWidth <= 768) {
            sidebar.classList.toggle("expanded");
        } else {
            sidebar.classList.toggle("collapsed");
        }
    });

    // Theme toggle
    themeBtn.addEventListener("click", () => {
        if (body.classList.contains("dark-theme")) {
            body.classList.replace("dark-theme", "light-theme");
            localStorage.setItem("theme", "light-theme");
        } else {
            body.classList.replace("light-theme", "dark-theme");
            localStorage.setItem("theme", "dark-theme");
        }
    });

});