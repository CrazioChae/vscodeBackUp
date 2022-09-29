// ==== numbers ====
let userNum = 0;
let randomNum = 0;
let userChance = 0;

// ==== areas ====
let resultArea = document.getElementById("result-area");
let chanceArea = document.getElementById("chance-area");
let inpArea = document.getElementById("input-area");

// ==== buttons ====
let checkBtn = document.getElementById("check-btn");
let resetBtn = document.getElementById("reset-btn");

// ==== events ====
checkBtn.addEventListener("click", checkRes);
resetBtn.addEventListener("click", resetRes);

resetRes();

function resetRes() {
  randomNum = Math.floor(Math.random() * 50 + 1);
  userChance = 0;
  alert(randomNum);
  resultArea.innerText = "업일까 다운일까";
  chanceArea.innerText = "남은기회는 " + (5 - userChance) + "회";
  checkBtn.disabled = false;
}

function checkRes() {
  userNum = inpArea.value;
  userChance += 1;
  if (userChance <= 5) {
    if (userNum == randomNum) {
      resultArea.innerText = "정답!";
      checkBtn.disabled = true;
    } else if (userNum > randomNum) {
      resultArea.innerText = "다운👎";
    } else {
      resultArea.innerText = "업👍";
    }
    chanceArea.innerText = "남은기회는 " + (5 - userChance) + "회";
    inpArea.value = 0;
  } else {
    checkBtn.disabled = true;
    chanceArea.innerText = "탈락입니다!";
  }
}
