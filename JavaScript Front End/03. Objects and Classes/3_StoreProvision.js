function store(arr1, arr2)
{
  let store = {};

  for (let i = 0; i < arr1.length; i += 2)
  {
    store[arr1[i]] = Number(arr1[i + 1]);
  }

  for (let i = 0; i < arr2.length; i += 2)
  {
    if (store.hasOwnProperty(arr2[i]))
    {
      store[arr2[i]] += Number(arr2[i + 1]);
    }
    else
    {
      store[arr2[i]] = Number(arr2[i + 1]);
    }
  }

  for(let prod in store)
  {
      console.log(`${prod} -> ${store[prod]}`);
  }
}