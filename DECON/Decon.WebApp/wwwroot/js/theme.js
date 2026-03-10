window.ToggleDarkMode = () => {
    const html = document.documentElement;
    html.classList.toggle("dark");

    // grava preferência
    if (html.classList.contains("dark"))
        localStorage.setItem("theme", "dark");
    else
        localStorage.setItem("theme", "light");
};

// carregar tema
window.addEventListener("load", () => {
    const theme = localStorage.getItem("theme");
    if (theme === "dark") {
        document.documentElement.classList.add("dark");
    }
});