let view = 0;

function disableScroll() {
    // Get the current page scroll position
    scrollTop = window.pageYOffset || document.documentElement.scrollTop;
    scrollLeft = window.pageXOffset || document.documentElement.scrollLeft,
  
        // if any scroll is attempted, set this to the previous value
        window.onscroll = function() {
            window.scrollTo(scrollLeft, scrollTop);
        };
}
  
function enableScroll() {
    window.onscroll = function() {};
}

function retractnav() {
    const hammenu = document.getElementById("hamburger");
    hammenu.style.display = "flex";
    const extendmenu = document.getElementById("extmenu");
    const actionmenu = document.getElementById("action-menu");
    extendmenu.remove()
    actionmenu.style.display = "none"
    enableScroll();
}

function extendnav() {

    disableScroll();

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
            fp_text[1].style.marginTop = "0px";
            lines[0].className = "hp-line-sel";
            lines[1].className = "hp-line-unsel";
            lines[2].className = "hp-line-unsel";
              break;
        case 2:
            fp_text[0].innerHTML = "PICKUP";
            fp_text[1].innerHTML = "A PURPOSE-BUILT PICKUP TRUCK";
            fp_text[2].innerHTML = "Launching as early as 2023. U.S. Preorders Now Open";
            fp_text[1].style.marginTop = "0px";
            lines[1].className = "hp-line-sel";
            lines[0].className = "hp-line-unsel";
            lines[2].className = "hp-line-unsel";
            break;
        case 3:
            fp_text[0].innerHTML = "MPDV";
            fp_text[1].innerHTML = "MULTI-PURPOSE DELIVERY VEHICLE";
            fp_text[1].style.marginTop = "-20px";
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
    const fp_text = document.getElementsByName("fp-text");
    currimage.src =`static/home-${currslide}-canoo.png`;
    switch (currslide) {
        case 1:
            fp_text[0].innerHTML = "LIFESTYLE VEHICLE";
            fp_text[1].innerHTML = "A LOFT ON WHEELS";
            fp_text[2].innerHTML = "Launching late 2022. U.S. Starting at $34,750";
            fp_text[1].style.marginTop = "0px";
            lines[0].className = "hp-line-sel";
            lines[1].className = "hp-line-unsel";
            lines[2].className = "hp-line-unsel";
              break;
        case 2:
            fp_text[0].innerHTML = "PICKUP";
            fp_text[1].innerHTML = "A PURPOSE-BUILT PICKUP TRUCK";
            fp_text[2].innerHTML = "Launching as early as 2023. U.S. Preorders Now Open";
            fp_text[1].style.marginTop = "0px";
            lines[1].className = "hp-line-sel";
            lines[0].className = "hp-line-unsel";
            lines[2].className = "hp-line-unsel";
            break;
        case 3:
            fp_text[0].innerHTML = "MPDV";
            fp_text[1].innerHTML = "MULTI-PURPOSE DELIVERY VEHICLE";
            fp_text[1].style.marginTop = "-20px";
            fp_text[2].innerHTML = "";
            lines[2].className = "hp-line-sel";
            lines[1].className = "hp-line-unsel";
            lines[0].className = "hp-line-unsel";
      }
}

    function leadGen() {
    const lg = document.getElementById("sign-up-form");
    const formo = document.getElementById("sign-up-form-in");
    lg.children[0].remove();
    document.getElementById("right-arrow-lead").remove();
    lg.children[0].on
    lg.id = "sign-up-form-cli";

    const bBorder = [];
    for (let index = 0; index < 5; index++) {
        bBorder.push(document.createElement("div"));
        bBorder[index].className = "custom-input-border";
    }
    
    const fname = document.createElement("input");
    fname.type = "text"
    lg.children[0].children[0].append(fname);
    fname.placeholder = "FIRST NAME";
    fname.className = ".input-l";
    lg.children[0].children[0].append(bBorder[0]);

    const lname = document.createElement("input");
    lname.type = "text"
    lg.children[0].children[0].append(lname);
    lname.placeholder = "LAST NAME";
    lname.className = ".input-l";
    lg.children[0].children[0].append(bBorder[1]);

    const phone = document.createElement("input");
    phone.type = "number"
    lg.children[0].children[0].append(phone);
    phone.placeholder = "PHONE (Optional)";
    phone.className = ".input-l";
    lg.children[0].children[0].append(bBorder[2]);

    const postal = document.createElement("input");
    postal.type = "number"
    lg.children[0].children[0].append(postal);
    postal.placeholder = "POSTAL CODE";
    postal.className = ".input-l";
    lg.children[0].children[0].append(bBorder[3]);

    const pInterest = document.createElement("input");
    pInterest.type = "text"
    lg.children[0].children[0].append(pInterest);
    pInterest.placeholder = "Product Interest";
    pInterest.className = ".input-l";
    lg.children[0].children[0].append(bBorder[4]);

    const lgSubmitB = document.createElement("input");
    lgSubmitB.type="submit";
    lgSubmitB.value="SUBMIT";
    lgSubmitB.id="lgSubmitB";
    lg.children[0].children[0].append(lgSubmitB);
}