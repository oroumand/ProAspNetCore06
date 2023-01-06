"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

document.getElementById("sendMessage").disabled = true;

connection.on("ReceiveMessage", function (userName, message) {
    var li = document.createElement("li");
    li.textContent = `${userName}: ${message}`;
    document.getElementById("messages").appendChild(li);
});

connection.start().then(function () {
    document.getElementById("sendMessage").disabled = false;

}).catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("sendMessage").addEventListener("click", function (event) {
    var userName = document.getElementById("userName").value;
    var message = document.getElementById("message").value;
    connection.invoke("SendMessage", userName, message).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});
