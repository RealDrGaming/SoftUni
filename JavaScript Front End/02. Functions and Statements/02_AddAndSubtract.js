function addAndSubtract(firstNumber, secondNumber, thirdNumber)
{
    const sum = (firstNumber, secondNumber) => firstNumber + secondNumber;
    const subtract = (result, thirdNumber) => result - thirdNumber;
    
    let sumResult = sum(firstNumber, secondNumber);
    let finalResult = subtract(sumResult, thirdNumber);

    console.log(finalResult);
}