function solve(number)
{
    let result = "";

    if (number % 10 === 0)
    {
        if (number === 100)
        {
            console.log(`${number}% Complete!`);
            console.log(`[%%%%%%%%%%]`);
            return;
        }

        let count = number / 10;
        result += `${number}%`;
        result += " ["; 

        for (let i = 1; i <= count; i++)
        {
            result += "%";
        }   

        for (let i = count; i < 10; i++)
        {
            result += ".";
        }   

        result += "]";
        console.log(result);  

        if (number < 100)
        {
            console.log("Still loading...");
        }
    }
}