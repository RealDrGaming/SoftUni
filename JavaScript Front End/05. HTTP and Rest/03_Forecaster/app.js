async function attachEvents() {
  let url = "http://localhost:3030/jsonstore/forecaster/locations";
  let conditions = "http://localhost:3030/jsonstore/forecaster/today/";
  let upcoming = "http://localhost:3030/jsonstore/forecaster/upcoming/";

  let submitBtn = document.getElementById("submit");
  let location = document.getElementById("location");
  let currentData = document.getElementById("current");
  let upcomingData = document.getElementById("upcoming");

  let locName = null;
  let locCode = null;

  let symbols = {
    Sunny: "&#x2600",
    "Partly sunny": "&#x26C5",
    Overcast: "&#x2601",
    Rain: "&#x2614",
    Degrees: "&#176",
  };

  submitBtn.addEventListener("click", async () => {
    let searchedLocation = location.value;

    try {
      let response = await fetch(`${url}`);
      let data = await response.json();
      for (let { code, name } of data) {
        if (name === searchedLocation) {
          locCode = code;
          locName = name;
        }
      }
      if (locName !== null) {
        try {
          currentData.parentElement.style.display = "block";
          let currentWeather = await fetch(`${conditions}${locCode}`);
          let currentDataWeather = await currentWeather.json();
          let weatherIconCode = currentDataWeather.forecast.condition;
          let iconCode = symbols[weatherIconCode];
          currentData.innerHTML = `
                  <div id="forecast" style="display:block">
                    <div id="current">
                        <div class="label">Current conditions</div>
                    </div>
                      <span class="condition symbol">${iconCode}</span>
                      <span class="condition">
                          <span class="forecast-data">${currentDataWeather.name}</span>
                          <span class="forecast-data">${currentDataWeather.forecast.low}&#176/${currentDataWeather.forecast.high}&#176</span>
                          <span class="forecast-data">${weatherIconCode}</span>
                      </span>
                  </div>
                  `;
          let upcomingWeather = await fetch(`${upcoming}${locCode}`);
          let upcomingDataWeather = await upcomingWeather.json();
          let forecastInfoDiv = document.createElement("div");
          forecastInfoDiv.classList.add("forecast-info");
          for (let data of upcomingDataWeather.forecast) {
            let weatherIcon = symbols[data.condition];
            forecastInfoDiv.innerHTML += `
                      <span class="upcoming">
                          <span class="symbol">${weatherIcon}</span>
                          <span class="forecast-data">${data.low}&#176/${data.high}&#176</span>
                          <span class="forecast-data">${data.condition}</span>
                      </span>
                  `;
            upcomingData.appendChild(forecastInfoDiv);
          }
        } catch (e) {}
      }
    } catch (e) {}
  });
}

attachEvents();
