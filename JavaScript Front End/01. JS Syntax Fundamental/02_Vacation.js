function solve(numberOfPeople, typeOfGroup, dayOfWeek) 
{
    let price = 0;
    let priceModifier = 1;
  
    if (typeOfGroup === "Students" && numberOfPeople >= 30) {
      priceModifier = 0.85;
    } else if (typeOfGroup === "Business" && numberOfPeople >= 100) {
      numberOfPeople -= 10;
    } else if (typeOfGroup === "Regular" && numberOfPeople >= 10 && numberOfPeople <= 20) {
      priceModifier = 0.95;
    }
  
    switch (typeOfGroup) {
      case "Students":
        switch (dayOfWeek) {
          case "Friday":
            price = priceModifier * numberOfPeople * 8.45;
            break;
          case "Saturday":
            price = priceModifier * numberOfPeople * 9.80;
            break;
          case "Sunday":
            price = priceModifier * numberOfPeople * 10.46;
            break;
        }
        break;
      case "Business":
        switch (dayOfWeek) {
          case "Friday":
            price = priceModifier * numberOfPeople * 10.90;
            break;
          case "Saturday":
            price = priceModifier * numberOfPeople * 15.60;
            break;
          case "Sunday":
            price = priceModifier * numberOfPeople * 16;
            break;
        }
        break;
      case "Regular":
        switch (dayOfWeek) {
          case "Friday":
            price = priceModifier * numberOfPeople * 15;
            break;
          case "Saturday":
            price = priceModifier * numberOfPeople * 20;
            break;
          case "Sunday":
            price = priceModifier * numberOfPeople * 22.50;
            break;
        }
        break;
    }
  
    console.log(`Total price: ${price.toFixed(2)}`);
}