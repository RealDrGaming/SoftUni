function solve(fruit, weightInGrams, pricePerKilograms)
{
    let weightInKilograms = weightInGrams / 1000;
    let money = weightInKilograms * pricePerKilograms;

    console.log(`I need $${money.toFixed(2)} to buy ${weightInKilograms.toFixed(2)} kilograms ${fruit}.`);
}