function piccolo(arr) 
{
    let parking = new Set();

    for (let car of arr)
    {
        let [action, number] = car.split(', ');

        if (action == 'IN')
        {
            parking.add(number);
        } 
        else
        {
            parking.delete(number);
        }
    }
    if (parking.size === 0)
    {
        console.log('Parking Lot is Empty')
    }
    else
    {
        let result = Array.from(parking).sort();

        for (let car of result)
        {
            console.log(car)
        }
    }
}