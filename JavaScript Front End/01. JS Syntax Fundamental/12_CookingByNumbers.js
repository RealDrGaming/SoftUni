function solve(number, ...params) {
  for (let i = 0; i < params.length; i++) {
    let element = params[i];
    if (element === "chop") {
      number /= 2;
    } else if (element === "dice") {
      number = Math.sqrt(number);
    } else if (element === "spice") {
      number += 1;
    } else if (element === "bake") {
      number *= 3;
    } else if (element === "fillet") {
      number *= 0.8;
      console.log(number.toFixed(1));
      continue;
    }
    console.log(number);
  }
}