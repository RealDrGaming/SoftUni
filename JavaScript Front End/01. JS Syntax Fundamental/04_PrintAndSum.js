function solve(num1, num2)
{
    let sum = 0;
    let string = " " + num1;

    for(let i = num1; i <= num2; i++)
    {
        sum += i;
        if(i !== num1)
        {
            string += " " + i;
        }
    }

    console.log(string);
    console.log("Sum: " + sum);
}