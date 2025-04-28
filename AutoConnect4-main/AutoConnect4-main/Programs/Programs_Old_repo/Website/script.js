// Define global variables outside the ready block
let picoConnected = false;
let myList = [0, 0, 0, 0, 0, 0, 0];
let gameMode = null;
let playOn = null;
let currentPlayer = 1;
let movePending = false;

$(document).ready(() => {
    // Show/hide computer options based on game mode
    $("#game-mode").change(function() {
        const mode = $(this).val();
        if (mode.startsWith("vs-computer")) {
            $("#computer-options").show();
        } else {
            $("#computer-options").hide();
        }
    });

    // Start game when button is clicked
    $("#start-game").click(function() {
        gameMode = $("#game-mode").val();
        playOn = $("#play-on").val();
        $("#menu").hide();
        $("#game-area").show();
        MakeBoard();
        lastModified();
        updateConnectionStatus();

        // Send game mode to Pico via ESP32
        fetch(`/set-mode?mode=${gameMode}&playOn=${playOn}`)
            .then(response => response.json())
            .then(data => {
                if (!data.success) {
                    alert("Failed to set game mode!");
                }
            })
            .catch(error => {
                console.error("Error setting game mode:", error);
            });
    });

    // Periodically check connection status
    setInterval(checkConnectionStatus, 1000);

    // Periodically check for game updates from Pico
    setInterval(checkGameUpdates, 500);

    $("#game").on("click", "button", (e) => {
        if (!picoConnected && playOn === "hardware") {
            alert("Pico not connected! Game is disabled.");
            return;
        }

        if (movePending) {
            alert("Waiting for the other player's move!");
            return;
        }

        let column = parseInt(e.target.id);
        if (myList[column] >= 6) {
            alert("Column is full!");
            return;
        }

        movePending = true;
        fetch(`/move?column=${column}&player=${currentPlayer}`)
            .then(response => response.json())
            .then(data => {
                if (!data.success) {
                    alert("Failed to process move!");
                    movePending = false;
                }
                // Move will be updated via checkGameUpdates
            })
            .catch(error => {
                console.error("Error sending move:", error);
                alert("Error communicating with ESP32!");
                movePending = false;
            });
    });
});

function play(player, column) {
    for (let row = 5; row >= 0; row--) {
        if ($(`#${row}${column}`).hasClass("Grey")) {
            $(`#${row}${column}`)
                .removeClass("Grey")
                .addClass(player === 1 ? "Yellow" : "Red");
            break;
        }
    }
    myList[column] += 1;
    currentPlayer = player === 1 ? 2 : 1;
}

function checkGameUpdates() {
    fetch('/game-update')
        .then(response => response.json())
        .then(data => {
            if (data.move) {
                play(data.move.player, data.move.column);
                movePending = false;
            }
            if (data.winner) {
                alert(`Player ${data.winner} wins!`);
                resetGame();
            }
            if (data.columnFull) {
                alert("Column is full!");
                movePending = false;
            }
        })
        .catch(error => {
            console.error("Error checking game updates:", error);
        });
}

function resetGame() {
    myList = [0, 0, 0, 0, 0, 0, 0];
    currentPlayer = 1;
    movePending = false;
    $("#game-area").hide();
    $("#menu").show();
    $("#game").empty();
}

function lastModified() {
    let string = "Last Modified: " + document.lastModified;
    $("#Modified").text(string);
}

function MakeBoard() {
    const rows = 7;
    const columns = 7;

    let table = document.getElementById("game");
    const headerRow = document.createElement("tr");
    for (let i = 0; i < columns; i++) {
        const th = document.createElement("th");
        const button = document.createElement("button");
        button.textContent = "Place Token";
        button.id = i.toString();
        th.appendChild(button);
        headerRow.appendChild(th);
    }
    table.appendChild(headerRow);

    for (let i = 0; i < rows - 1; i++) {
        const tr = document.createElement("tr");
        for (let j = 0; j < columns; j++) {
            const td = document.createElement("td");
            const div = document.createElement("div");
            div.classList.add("Grey");
            div.id = `${i}${j}`;
            td.appendChild(div);
            tr.appendChild(td);
        }
        table.appendChild(tr);
    }
}

function updateConnectionStatus() {
    const statusElement = $("#connection-status");
    if (statusElement.length) {
        statusElement.text(
            `Connection Status: ${picoConnected ? "Connected" : "Disconnected"}`
        ).css("color", picoConnected ? "#28a745" : "#dc3545");
    }
}

function checkConnectionStatus() {
    fetch('/status')
        .then(response => response.json())
        .then(data => {
            picoConnected = data.connected;
            updateConnectionStatus();
        })
        .catch(error => {
            console.error("Error checking status:", error);
            picoConnected = false;
            updateConnectionStatus();
        });
}