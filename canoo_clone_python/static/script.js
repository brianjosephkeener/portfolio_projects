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
        actionmenu.style.zIndex = "10";
    },750);
    console.log(extendmenu);
    extendmenu.id = "extmenu";
  }

  let currslide = 1;

  function carouselmov(movamount) {
      if(movamount == 1 && currslide == 3)
      {
          currslide = 1;
      }
      else if(movamount == -1 && currslide == 1)
      {
          currslide = 3;
      }
      else {
        currslide++;
      }
      const currimage = document.getElementById("first-top-img");
      currimage.src =`static/home-${currslide}-canoo.png`
  }