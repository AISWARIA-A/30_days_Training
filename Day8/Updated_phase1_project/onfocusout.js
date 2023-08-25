document.addEventListener("DOMContentLoaded", function () {
  const inputTypes = [
    "firstname",
    "dob",
    "phone",
    "username",
    "password",
    "confirm-password",
    "password",
    "email",
    "name",
    "lastname",
    "address",
    "city",
    "state",
    "message",
    "gender",
    "age"
  ];

  inputTypes.forEach((inputType) => {
    const input = document.getElementById(inputType);

    if (input) {
      input.addEventListener("focus", function () {
        input.style.backgroundColor = "#faaf69";
        input.style.borderColor = "#ff8c1a";
      });

      input.addEventListener("blur", function () {
        input.style.backgroundColor = "#fff";
      });
    }
  });
});
