function makeADictionary(arr)
{
  let dictionary = {};

  for (let el of arr)
  {
    let curenrtEl = JSON.parse(el);
    let key = Object.keys(curenrtEl)[0];
    let value = Object.values(curenrtEl)[0];

    dictionary[key] = value;
  }
  
  Object.entries(dictionary).sort((a,b)=>a[0].localeCompare(b[0])).forEach(x => console.log(`Term: ${x[0]} => Definition: ${x[1]}`));
}