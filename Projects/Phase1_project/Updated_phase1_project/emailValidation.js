function validateEmail(email) {
  const emailPattern = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
  return emailPattern.test(email);
}

document.addEventListener("DOMContentLoaded", function () {
  const emailInput = document.getElementById("email");
  const loginForm = document.querySelector("form");

  loginForm.addEventListener("submit", function (event) {
    const emailValue = emailInput.value.trim();

    if (!validateEmail(emailValue)) {
      event.preventDefault();
      alert("Invalid email address format. Please enter a valid email.");
    }
  });
});
