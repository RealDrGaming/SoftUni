function attachEvents() {
  document.getElementById("refresh").addEventListener("click", refresh);
  document.getElementById("submit").addEventListener("click", send);

  async function refresh() {
    try {
      let res = await (
        await fetch("http://localhost:3030/jsonstore/messenger")
      ).json();
      document.getElementById("messages").innerHTML = "";
      let messages = Object.values(res)
        .map((v) => `${v.author}: ${v.content}`)
        .join("\n");
      document.getElementById("messages").value = messages;
    } catch (e) {}
  }
  async function send() {
    try {
      let author = document.querySelector('input[name="author"]').value;
      let message = document.querySelector('input[name="content"]').value;
      await fetch("http://localhost:3030/jsonstore/messenger", {
        method: "POST",
        body: JSON.stringify({ author: author, content: message }),
        headers: {
          "Content-type": "application/json; charset=UTF-8",
        },
      });
    } catch (e) {}

    document.querySelector('input[name="author"]').value = "";
    document.querySelector('input[name="content"]').value = "";
  }
}

attachEvents();
