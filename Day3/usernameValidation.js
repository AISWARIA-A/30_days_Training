function validateUsername(username) {
  const usernamePattern = /^(?=.*[A-Z])(?=.*[!@#$%^&*])[A-Za-z!@#$%^&*]{5,}$/;
  return usernamePattern.test(username);
}

document.addEventListener("DOMContentLoaded", function () {
  const usernameInput = document.getElementById("username");
  const signupForm = document.querySelector("form");

  signupForm.addEventListener("submit", function (event) {
    const usernameValue = usernameInput.value.trim();

    if (!validateUsername(usernameValue)) {
      event.preventDefault(); 
      alert(
        "Invalid username format. Username must contain at least 5 letters, a capital letter, and one special character."
      );
    }
  });
});
