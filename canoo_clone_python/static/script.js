let view = 0;

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
    extendmenu.id = "extmenu";
  }

  let currslide = 1;
  const lines = document.getElementsByName("line");
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
        if(movamount == 1)
        {
            currslide++;
        }
        else if(movamount == -1)
        {
            currslide--;
        }
      }
      const currimage = document.getElementById("first-top-img");
      const lines = document.getElementsByName("line");
      const fp_text = document.getElementsByName("fp-text");
      currimage.src =`static/home-${currslide}-canoo.png`;
      switch (currslide) {
        case 1:
            fp_text[0].innerHTML = "LIFESTYLE VEHICLE";
            fp_text[1].innerHTML = "A LOFT ON WHEELS";
            fp_text[2].innerHTML = "Launching late 2022. U.S. Starting at $34,750";
            lines[0].className = "hp-line-sel";
            lines[1].className = "hp-line-unsel";
            lines[2].className = "hp-line-unsel";
              break;
        case 2:
            fp_text[0].innerHTML = "PICKUP";
            fp_text[1].innerHTML = "A PURPOSE-BUILT PICKUP TRUCK";
            fp_text[2].innerHTML = "Launching as early as 2023. U.S. Preorders Now Open";
            lines[1].className = "hp-line-sel";
            lines[0].className = "hp-line-unsel";
            lines[2].className = "hp-line-unsel";
            break;
        case 3:
            fp_text[0].innerHTML = "MPDV";
            fp_text[1].innerHTML = "MULTI-PURPOSE DELIVERY VEHICLE";
            fp_text[2].innerHTML = "";
            lines[2].className = "hp-line-sel";
            lines[1].className = "hp-line-unsel";
            lines[0].className = "hp-line-unsel";
      }
  }

  function carouselmovline(slidenumber) {
      currslide = slidenumber;
    const currimage = document.getElementById("first-top-img");
    const lines = document.getElementsByName("line");
    currimage.src =`static/home-${currslide}-canoo.png`;
    switch (currslide) {
      case 1:
          lines[0].className = "hp-line-sel";
          lines[1].className = "hp-line-unsel";
          lines[2].className = "hp-line-unsel";
            break;
      case 2:
          lines[1].className = "hp-line-sel";
          lines[0].className = "hp-line-unsel";
          lines[2].className = "hp-line-unsel";
          break;
      case 3:
          lines[2].className = "hp-line-sel";
          lines[1].className = "hp-line-unsel";
          lines[0].className = "hp-line-unsel";
    }
}