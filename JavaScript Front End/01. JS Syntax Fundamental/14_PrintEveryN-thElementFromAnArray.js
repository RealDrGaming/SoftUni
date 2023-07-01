function solve(params, step)
{
    let arr = [];

    for (let i = 0; i < params.length; i += step)
    {
      let element = params[i];
      arr.push(element);
    }
    
    return arr;
}