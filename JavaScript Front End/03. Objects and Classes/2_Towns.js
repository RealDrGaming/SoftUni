function towns(arr) 
{
  for (let city of arr) 
  {
    let obj = {};
    let [town, latitude, longitude] = city.split(" | ");

    obj["town"] = town;
    obj["latitude"] = Number(latitude).toFixed(2);
    obj["longitude"] = Number(longitude).toFixed(2);
    
    console.log(obj);
  }
}