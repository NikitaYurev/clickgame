let connection = new signalR.HubConnectionBuilder().withUrl("/gameHub").build();

connection.on("UpdateClickCount", function(count) {
    document.getElementById("clickCount").innerText = count;
});

connection.start().then(function() {
    console.log("SignalR Connected.");
}).catch(function (err) {
    return console.error(err.toString());
});

function clickButton() {
    connection.invoke("Click").catch(function(err) {
        return console.error(err.toString());
    });
}

function resetGame() {
    connection.invoke("Reset").catch(function(err) {
        return console.error(err.toString());
    });
}