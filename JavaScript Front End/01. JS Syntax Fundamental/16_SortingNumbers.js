function solve(arr)
{
    arr.sort((a, b) => a - b);
  
    const result = [];
    let left = 0;
    let right = arr.length - 1;
  
    while (left <= right)
    {
      result.push(arr[left]);
  
      if (left === right)
      {
        break;
      }

      result.push(arr[right]);
      
      left++;
      right--;
    }
    return result;
}