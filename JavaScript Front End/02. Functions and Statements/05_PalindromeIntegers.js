function solve(params)
{
    for (let i = 0; i < params.length; i++)
    {
        const element = String(params[i]);

        if (element[0] === element[element.length - 1])
        {
            console.log(true);
        }
        else
        {
            console.log(false);
        }
    }
}