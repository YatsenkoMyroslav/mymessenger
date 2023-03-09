var windowHeight = window.innerHeight;
var containerHeight = windowHeight - document.getElementById('header').clientHeight;
let users = []

document.getElementById("bodyContainer").style.height = containerHeight + "px";
document.getElementById("ChatsList").style.height = containerHeight + "px";

const chatHeaderHeight = document.getElementById('ChatHeader').clientHeight;
const inputHeaderHeight = document.getElementById('MessageSendForm').clientHeight;
let result = (containerHeight - chatHeaderHeight - inputHeaderHeight);

document.getElementById("BlockForMessages").style.height = result + "px";


var input = document.getElementById("ChatSearchInput");

input.addEventListener("keyup", function(event) {
    if (event.keyCode === 13) {
        
        event.preventDefault();
        
        document.getElementById("SearchChatButton").click();
    }
});

const button = document.getElementById('sendMessage')
button.onclick(sendMessage());

function sendMessage() {
    
    const input = document.getElementById("messageInput");
    const inputValue = input.value;
    
    if(inputValue!=='' && inputValue!==null){
        $.post("chat/send_message", {
            message: inputValue,
        }).done(
            input.value = ''
        );
    }
}

function windowGetContactsForNewChat() {
    const smallWindow = document.getElementById('small-window');
    
    smallWindow.style.top = '50%';
    smallWindow.style.left = '50%';
    smallWindow.style.transform = 'translate(-50%, -50%)';
}

function addAnotherOneToChat(){
    const input = document.getElementById('InputEmail1')
    let email = input.value
    
    if(email!=='' && email!==null){
        users.push(email);
    }
    
    input.value = ''
}

function CreateChat(){
    let name = document.getElementById('chatName').value
    if(name === ''){
        alert('Please add name for chat')
    }
    else if(users.length === 0){
        alert('Please add users to chat')
    }
    else{
        let JsonUsers = JSON.stringify(users);
        $.post('/createChat', {
            name: name,
            users: JsonUsers
        })
        closeCreateNewChat()
    }
}

function closeCreateNewChat(){
    users = []
    let nameInput = document.getElementById('chatName')
    nameInput.value = ''
    const smallWindow = document.getElementById('small-window');
    smallWindow.style.top = '-9999px';
    smallWindow.style.left = '-9999px';
}

function windowChangePersonalInfo() {
    const smallWindow = document.getElementById('small-window');

    smallWindow.style.top = '50%';
    smallWindow.style.left = '50%';
    smallWindow.style.transform = 'translate(-50%, -50%)';
}

function SavePersonalInfo(){
    let name = document.getElementById('newName').value
    let lastname = document.getElementById('newLastName').value
    
    let JsonUsers = JSON.stringify(users);
    $.post('/createChat', {
        name: name,
        users: JsonUsers
    })

    closeChangePersonalInfo()
}

function closeChangePersonalInfo(){
    let nameInput = document.getElementById('newName')
    nameInput.value = ''
    let lastnameInput = document.getElementById('newLastName')
    lastnameInput.value = ''
    const smallWindow = document.getElementById('small-window');
    smallWindow.style.top = '-9999px';
    smallWindow.style.left = '-9999px';
}