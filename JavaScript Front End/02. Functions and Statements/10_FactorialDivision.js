function solve(n1, n2)
{
    let result = printResult(n1, n2);

    console.log(`${result.toFixed(2)}`);

    function printResult(n1, n2)
    {
        let firstFactorial = n1;
        let secondFactorial = n2;

        for (let f = 1; f < n1; f++) 
        {
            firstFactorial *= f;
        }   

        for (let s = 1; s < n2; s++)
        {
            secondFactorial *= s;
        }   

        return firstFactorial / secondFactorial;
    }
}