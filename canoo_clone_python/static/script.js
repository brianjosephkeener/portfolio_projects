let view = 0;

const lines = document.querySelectorAll("line");

function retractnav() {
    const hammenu = document.getElementById("hamburger");
    hammenu.style.display = "flex";
    const extendmenu = document.getElementById("extmenu");
    const actionmenu = document.getElementById("action-menu");
    extendmenu.remove()
    actionmenu.style.display = "none"
    console.log(extendmenu);
}

function extendnav() {
    const hammenu = document.getElementById("hamburger");
    hammenu.style.display = "none";

    const extendmenu = document.createElement("div");
    const parent = document.getElementById("m-body");
    const actionmenu = document.getElementById("action-menu");
    document.body.insertBefore(extendmenu, parent);
    setTimeout(function(){
        actionmenu.style.display = "flex";
        actionmenu.style.position = "fixed";
        actionmenu.style.left = "0";
    },750);
    console.log(extendmenu);
    extendmenu.id = "extmenu";
  }