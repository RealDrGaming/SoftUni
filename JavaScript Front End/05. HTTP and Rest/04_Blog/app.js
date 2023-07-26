function attachEvents() {
  let API_URL = "http://localhost:3030/jsonstore/blog/";
  let allPosts = [];
  let allComments = [];
  let selectEl = document.getElementById("posts");
  let ulEl = document.getElementById("post-comments");
  document
    .getElementById("btnLoadPosts")
    .addEventListener("click", async () => {
      let posts = await (await fetch(API_URL + "posts")).json();
      for (let post in posts) {
        let option = document.createElement("option");
        option.text = posts[post].title;
        selectEl.add(option);
        allPosts.push(posts[post]);
      }
      document.getElementById("btnLoadPosts").disabled = true;
    });
  document.getElementById("btnViewPost").addEventListener("click", getComments);

  async function getComments() {
    let comments = await (await fetch(API_URL + "comments")).json();
    for (let comment in comments) {
      allComments.push(comments[comment]);
    }
    ulEl.innerHTML = "";
    document.getElementById("post-title").textContent = document.querySelector(
      "#posts",
      "option"
    ).value;
    document.getElementById("post-body").textContent = allPosts.find(
      i => i.title === document.querySelector("#posts", "option").value
    ).body;
    let currentPostId = allPosts.find(
      i => i.title === document.querySelector("#posts", "option").value
    ).id;
    let currentPostComments = allComments.filter(
      c => c.postId === currentPostId
    );
    for (let el of currentPostComments) {
      let liEl = document.createElement("li");
      liEl.textContent = el["text"];
      ulEl.appendChild(liEl);
    }
    
    allComments = [];
  }
}

attachEvents();
