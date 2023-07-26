function employees(arr)
{
    let listOfEmployees = {};

    for(let employee of arr)
    {
        listOfEmployees[employee] = employee.length;
    }
    
    for(let person in listOfEmployees)
    {
        console.log(`Name: ${person} -- Personal Number: ${listOfEmployees[person]}`)
    }
}