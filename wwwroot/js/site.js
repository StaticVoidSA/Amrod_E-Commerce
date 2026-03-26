document.addEventListener("DOMContentLoaded", () => {
    const sidebar = document.getElementById("sidebar");
    const toggleBtn = document.getElementById("sidebarToggle");
    const themeBtn = document.getElementById("themeToggle");
    const body = document.getElementById("body");

    const savedTheme = localStorage.getItem("theme");

    if (savedTheme) {
        body.classList.remove("light-theme", "dark-theme"); 
        body.classList.add(savedTheme);
    }

    toggleBtn?.addEventListener("click", () => {
        sidebar.classList.toggle("collapsed");
    });

    themeBtn?.addEventListener("click", () => {
        if (body.classList.contains("dark-theme")) {
            body.classList.replace("dark-theme", "light-theme");
            localStorage.setItem("theme", "light-theme");
        } else {
            body.classList.replace("light-theme", "dark-theme");
            localStorage.setItem("theme", "dark-theme");
        }
    });
});