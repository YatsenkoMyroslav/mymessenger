var windowHeight = window.innerHeight;
var containerHeight = windowHeight - document.getElementById('header').clientHeight;

document.getElementById("bodyContainer").style.height = containerHeight + "px";


var input = document.getElementById("ChatSearchInput");

// Execute a function when the user releases a key on the keyboard
input.addEventListener("keyup", function(event) {
    // Number 13 is the "Enter" key on the keyboard
    if (event.keyCode === 13) {
        
        event.preventDefault();
        
        document.getElementById("SearchChatButton").click();
    }
});