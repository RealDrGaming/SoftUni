function addItem()
{
  let textInput = document.querySelector("#newItemText");
  let valueInput = document.querySelector("#newItemValue");
  let option = document.createElement("option");

  option.textContent = textInput.value;
  option.setAttribute("value", valueInput.value);

  let select = document.querySelector("#menu");
  
  select.appendChild(option);
  textInput.value = "";
  valueInput.value = "";
}
