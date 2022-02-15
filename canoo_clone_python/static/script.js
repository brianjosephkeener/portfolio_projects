let hampos = 0;
const lines = document.querySelectorAll("line");

function test() {
    console.log("test retract")
    const hammenu = document.getElementById("hamburger");
    hammenu.style.display = "flex";
    lines.forEach(element => {
        element.createElement('div');
        element.classList = "line";
    });
}

function extendnav() {
    console.log("test extend")
    const hammenu = document.getElementById("hamburger");
    hammenu.style.display = "none";
  }