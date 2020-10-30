var button = document.getElementById("sidePanelButton");
var panel = document.getElementById("sidePanel");
var fa = document.getElementById("fa");
var isOpen = false;

document.getElementById("sidePanelButton").addEventListener("click", () => {
    if (isOpen) {
        panel.style.setProperty("display", "none");
        panel.classList.remove("open");
        fa.classList.replace("fa-times", "fa-bars");
    }
    else {
        panel.style.setProperty("display", "initial");
        panel.classList.add("open");
        fa.classList.replace("fa-bars", "fa-times");
    }
    isOpen = !isOpen;
});

window.addEventListener("resize", () => {
    fa.classList.replace("fa-times", "fa-bars");

    if (document.body.clientWidth < 720) {
        isOpen = false;
        panel.style.setProperty("display", "none");
        button.style.setProperty("display", "inherit");
        panel.classList.remove("open");
    }
    else {
        isOpen = true;
        panel.style.setProperty("display", "initial");
        button.style.setProperty("display", "none");
    }
});