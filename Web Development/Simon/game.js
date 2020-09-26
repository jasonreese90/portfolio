var colorOrder = [];
var level = 0;
var gameOver = true;
var currenPosition = 0;

$(document).keypress(function(e) {
  if (gameOver) {
    gameOver = false;
    nextLevel();
  }
})


$(".btn").click(function() {
  var color = $(this).attr("id");

  clicked(color);

  if (colorOrder[currenPosition] === color) {
    if (currenPosition === level - 1) {
      currenPosition = 0;
      setTimeout(function() {
        nextLevel();
      }, 1000);

    } else {
      currenPosition++;
    }
    playSound(color);
  } else {
    $("#level-title").text("Game Over, Press Any Key to Restart");
    $("body").addClass("game-over");
    setTimeout(function() {
      $("body").removeClass("game-over");
    }, 100);

    var sound = new Audio("sounds/wrong.mp3");
    sound.play();
newGame();
  }

});

$("button").click(function() {
gameOver = false;
newGame();
nextLevel();
});

function newGame(){
  gameOver = true;
  colorOrder = [];
  level = 0;
  currenPosition = 0;
}
function nextLevel() {
  var color = pickRandomColor();
  clicked(color);
  playSound(color);
  colorOrder.push(color);
  level++;
  $("#level-title").text("Level " + level);
}

function clicked(color) {
  $("#" + color).addClass("pressed");
  setTimeout(function() {
    $("#" + color).removeClass("pressed");
  }, 50);
}

function playSound(color) {
  var sound = new Audio("sounds/" + color + ".mp3");
  sound.play();
}

function pickRandomColor() {
  var colors = ["red", "blue", "yellow", "green"];
  var colorIndex = Math.floor(Math.random() * colors.length);
  return colors[colorIndex];
}
