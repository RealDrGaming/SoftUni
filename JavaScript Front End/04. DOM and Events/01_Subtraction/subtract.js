function subtract() 
{
  let number1 = Number(document.getElementById("firstNumber").value);
  let number2 = Number(document.getElementById("secondNumber").value);

  document.getElementById("result").textContent = number1 - number2;
}