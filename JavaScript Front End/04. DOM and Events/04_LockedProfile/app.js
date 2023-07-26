function lockedProfile()
{
  let btns = Array.from(document.querySelectorAll("button"));

  btns.forEach((button) => {
    button.addEventListener("click", (e) => {
      let locked = e.currentTarget.parentElement.querySelector('input[type="radio"]');
      
      if (locked.checked)
      {
        return;
      }

      let isHidden = e.currentTarget.textContent === "Show more";
      let hiddenInfo = e.currentTarget.parentElement.querySelector("div");

      hiddenInfo.style.display = isHidden ? "block" : "none";
      e.currentTarget.textContent = isHidden ? "Hide it" : "Show more";
    });
  });
}