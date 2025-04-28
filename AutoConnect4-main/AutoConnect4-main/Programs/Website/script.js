$(document).ready(()=>
{
    let myList = [0,0,0,0,0,0,0];
    const board = [
        [0, 0, 0, 0, 0, 0, 0],
        [0, 0, 0, 0, 0, 0, 0],
        [0, 0, 0, 0, 0, 0, 0],
        [0, 0, 0, 0, 0, 0, 0],
        [0, 0, 0, 0, 0, 0, 0],
        [0, 0, 0, 0, 0, 0, 0]
    ];
    let player = 1;
    console.log("working");
    MakeBoard();
    lastModified();
    $("#game").on("click", 'Button', (e)=>
    {
        let s = e.target.id;      
        myList[s] += 1;
        console.log(myList);
        play(player, myList);
        player ^= 1;
        console.log(player);
    })
})

function play(play, place, board)
{
    if(play == 1)
    {
        
    }
    else
    {

    }
}

function lastModified()
{
    let string = 'Last Modified: ' + document.lastModified;
    console.log(string);
    $("#Modified").text(`${string}`);
}
function MakeBoard()
{
    console.log("working Make Board");
    const rows = 7;
    const columns = 7;

    let table = document.getElementById('game');
    const headerRow = document.createElement('tr');
    for (let i = 0; i < columns; i++) {
        const th = document.createElement('th');
        const button = document.createElement('button');
        button.textContent = 'Place Token';
        th.id = i;
        button.id = i;
        th.appendChild(button);
        headerRow.appendChild(th);
    }

    table.appendChild(headerRow);
    for (let i = 0; i < rows - 1; i++) 
    { 
        const tr = document.createElement('tr');
        for (let j = 0; j < columns; j++) 
        {
            const td = document.createElement('td');
            const div = document.createElement('div');
            div.classList.add('Grey');
            div.id = `${i}${j}`;
            td.appendChild(div);
            tr.appendChild(td);
        }
        table.appendChild(tr);
    }
    
}