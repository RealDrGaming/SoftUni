function getInfo() {
  const busStopId = document.querySelector("#stopId").value;
  const stops = document.querySelector('ul');

  stops.textContent = '';

  fetch(`http://localhost:3030/jsonstore/bus/businfo/${busStopId}`)
    .then((res) => res.json())
    .then(busStop => {
        document.querySelector('#stopName').textContent = busStop.name;

        Object.entries(busStop.buses).map(([busId, timeInMinutes]) => {
            const item = document.createElement('li');
            item.textContent = `Bus ${busId} arrives in ${timeInMinutes} minutes`;

            stops.appendChild(item);
        })
    })
    .catch(() => {
        document.querySelector('#stopName').textContent = 'Error';
    });
}
