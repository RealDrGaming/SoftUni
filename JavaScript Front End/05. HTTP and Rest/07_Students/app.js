function attachEvents() {
  // JavaScript code to populate the table
  const url = "http://localhost:3030/jsonstore/collections/students";

  // Fetch data from the URL
  fetch(url)
    .then((response) => response.json())
    .then((data) => {
      // Get the table body element
      const tbody = document.querySelector("#results tbody");

      // Loop through the data and create table rows for each student object
      Object.values(data).forEach((student) => {
        const row = document.createElement("tr");

        // Create table cells for each student property
        const firstNameCell = document.createElement("td");
        firstNameCell.textContent = student.firstName;
        row.appendChild(firstNameCell);

        const lastNameCell = document.createElement("td");
        lastNameCell.textContent = student.lastName;
        row.appendChild(lastNameCell);

        const facultyNumberCell = document.createElement("td");
        facultyNumberCell.textContent = student.facultyNumber;
        row.appendChild(facultyNumberCell);

        const gradeCell = document.createElement("td");
        gradeCell.textContent = student.grade;
        row.appendChild(gradeCell);

        // Append the row to the table body
        tbody.appendChild(row);
      });
    })
    .catch((error) => console.error("Error fetching data:", error));

  class StudentForm {
    constructor(url) {
      this.url = url;
      this.form = document.getElementById("form");
      this.notification = document.querySelector(".notification");
      this.submitButton = document.getElementById("submit");

      this.submitButton.addEventListener("click", this.onSubmit.bind(this));
    }

    onSubmit(event) {
      event.preventDefault();

      // Get form input values
      const firstName = this.form
        .querySelector("input[name='firstName']")
        .value.trim();
      const lastName = this.form
        .querySelector("input[name='lastName']")
        .value.trim();
      const facultyNumber = this.form
        .querySelector("input[name='facultyNumber']")
        .value.trim();
      const grade = this.form.querySelector("input[name='grade']").value.trim();

      // Validate form data
      if (!firstName || !lastName || !facultyNumber || isNaN(grade)) {
        this.notification.textContent =
          "Please fill in all the fields correctly.";
        return;
      }

      // Prepare the data for the POST request
      const data = {
        firstName,
        lastName,
        facultyNumber,
        grade,
      };

      // Send the POST request
      fetch(this.url, {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify(data),
      })
        .then((response) => response.json())
        .then((responseData) => {
          this.notification.textContent = "Form submitted successfully!";
          this.resetForm();
        })
        .catch((error) => {
          this.notification.textContent =
            "An error occurred while submitting the form.";
          console.error("Error submitting the form:", error);
        });
    }

    resetForm() {
      this.form.innerHTML = "";
      this.notification.textContent = "";
    }
  }

  // Create an instance of the StudentForm class
  const formUrl = "http://localhost:3030/jsonstore/collections/students";
  const studentForm = new StudentForm(formUrl);
}

attachEvents();