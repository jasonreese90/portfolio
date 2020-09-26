
var player1Die = pickRandomDie();
var player2Die = pickRandomDie();

document.querySelector(".img1").setAttribute("src","images/dice" + player1Die + ".png");
document.querySelector(".img2").setAttribute("src","images/dice" + player2Die + ".png");

if(player1Die > player2Die){
   document.querySelector("h1").textContent = "🚩 Player 1 Wins!";
}
else if (player1Die < player2Die) {
   document.querySelector("h1").textContent = "Player 2 Wins! 🚩";
}
else {
  document.querySelector("h1").textContent = "Draw";
}

function pickRandomDie(){
  return Math.floor(Math.random() * 6 ) + 1;
}
