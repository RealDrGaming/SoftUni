function attachEvents() {
  document.getElementById("btnLoad").addEventListener("click", loadContacts);
  document.getElementById("btnCreate").addEventListener("click", createContact);
  let list = document.getElementById("phonebook");
  async function loadContacts() {
    try {
      let data = await (
        await fetch("http://localhost:3030/jsonstore/phonebook")
      ).json();
      let contacts = Object.values(data);
      list.innerHTML = "";
      contacts.forEach((c) => {
        let liEl = document.createElement("li");
        let info = `${c.person}: ${c.phone}`;
        liEl.textContent = info;
        let btn = document.createElement("button");
        btn.textContent = "Delete";
        btn.setAttribute("id", c._id);
        liEl.appendChild(btn);
        list.appendChild(liEl);
        console.log(liEl)
      });
      deleteBtns();
    } catch (e) {
      console.log("Error loading");
    }
  }
  async function createContact() {
    let person = document.getElementById("person").value;
    let phone = document.getElementById("phone").value;
    try {
      await fetch("http://localhost:3030/jsonstore/phonebook", {
        method: "POST",
        body: JSON.stringify({ 'person': person, 'phone': phone }),
        headers: {
          "Content-type": "application/json; charset=UTF-8",
        },
      });
    } catch (e) {}

    loadContacts();
    deleteBtns();
    document.getElementById("person").value = "";
    document.getElementById("phone").value = "";
  }
  function deleteBtns() {
    let delBtns = document.querySelectorAll("ul#phonebook > li > button");
    delBtns.forEach((b) => {
      b.addEventListener("click", async (e) => {
        let currentEl = e.target.id;
        try {
          await fetch(
            `http://localhost:3030/jsonstore/phonebook/${currentEl}`,
            {
              method: "DELETE",
            }
          );
          loadContacts()
        } catch (e) {}
      });
    }); 
  }
}

attachEvents();
