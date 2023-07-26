function solve() {
  let infoEl = document.querySelector(".info");
  let departBtn = document.getElementById("depart");
  let arrivalBtn = document.getElementById("arrive");
  let busStop = {
    next: "depot",
  };
  function depart() {
    departBtn.disabled = true;
    let url = `http://localhost:3030/jsonstore/bus/schedule/${busStop.next}`;
    fetch(url)
      .then((response) => response.json())
      .catch((error) => console.log(error))
      .then((data) => {
        busStop = JSON.parse(JSON.stringify(data));
        infoEl.textContent = `Next stop ${busStop.name}`;
      })
      .catch((error) => console.log(error));
    arrivalBtn.disabled = false;
  }

  function arrive() {
    infoEl.textContent = `Arriving at ${busStop.name}`;
    departBtn.disabled = false;
    arrivalBtn.disabled = true;
  }

  return {
    depart,
    arrive,
  };
}

let result = solve();
