let view = 0;

const lines = document.querySelectorAll("line");

function test() {
    console.log("test retract")
    const hammenu = document.getElementById("hamburger");
    hammenu.style.display = "flex";
    const extendmenu = document.getElementById("extmenu");
    extendmenu.remove()
    console.log(extendmenu);
}

function extendnav() {
    console.log("test extend")
    const hammenu = document.getElementById("hamburger");
    hammenu.style.display = "none";

    const extendmenu = document.createElement("div");
    const parent = document.getElementById("m-body")
    document.body.insertBefore(extendmenu, parent)
    console.log(extendmenu);
    extendmenu.id = "extmenu"
  }