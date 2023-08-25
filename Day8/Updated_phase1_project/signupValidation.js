const stateDropdown = document.getElementById("state");
const cityDropdown = document.getElementById("city");

const citiesByState = {
  AP: ["Visakhapatnam", "Vijayawada", "Guntur"],
  KA: ["Bengaluru", "Mysuru", "Hubballi"],
  KL: ["Kochi", "Thiruvananthapuram", "Kozhikode"],
  MH: ["Mumbai", "Pune", "Nagpur"],
  TN: ["Chennai", "Coimbatore", "Madurai"],
  TS: ["Hyderabad", "Warangal", "Karimnagar"],
};

stateDropdown.addEventListener("change", function () {
  const selectedState = stateDropdown.value;
  const cities = citiesByState[selectedState];

  cityDropdown.innerHTML =
    '<option value="none" selected disabled>Select a City</option>';
  cityDropdown.disabled = false;

  if (cities) {
    cities.forEach((city) => {
      const option = document.createElement("option");
      option.value = city.toLowerCase().replace(" ", "-");
      option.textContent = city;
      cityDropdown.appendChild(option);
    });
  } else {
    cityDropdown.innerHTML =
      '<option value="none" selected disabled>No Cities Available</option>';
    cityDropdown.disabled = true;
  }
});

function validateForm() {
  var password = document.getElementById("password").value;
  var confirmPassword = document.getElementById("confirm-password").value;

  if (password !== confirmPassword) {
    alert("Error: Passwords do not match!");
    return false;
  }

  return true;
}

document.addEventListener("DOMContentLoaded", function () {
  const firstNameInput = document.getElementById("firstname");
  const lastNameInput = document.getElementById("lastname");
  const confirmPasswordInput = document.getElementById("confirm-password");
  const dobInput = document.getElementById("dob");
  const passwordInput = document.getElementById("password");
  const usernameInput = document.getElementById("username");

  const firstNameError = document.getElementById("first-name-error");
  const lastNameError = document.getElementById("last-name-error");
  const usernameError = document.getElementById("username-error");
  const passwordError = document.getElementById("password-error");
  const dobError = document.getElementById("dob-error");
  const confirmPasswordError = document.getElementById(
    "confirm-password-error"
  );

  usernameInput.addEventListener("blur", function () {
    const usernameValue = usernameInput.value;

    const hasWhitespace = /\s/.test(usernameValue);
    const startsWithNumber = /^\d/.test(usernameValue);

    if (hasWhitespace || startsWithNumber) {
      usernameError.textContent =
        "Username cannot contain whitespaces and cannot start with a number.";
    } else {
      usernameError.textContent = "";
    }
  });

  passwordInput.addEventListener("blur", function () {
    const passwordValue = passwordInput.value;

    const hasUpperCase = /[A-Z]/.test(passwordValue);
    const hasSpecialChar = /[!@#$%^&*()_+{}\[\]:;<>,.?~\\/-]/.test(
      passwordValue
    );
    const hasNumber = /\d/.test(passwordValue);
    const isLengthValid = passwordValue.length >= 5;

    if (!hasUpperCase || !hasSpecialChar || !hasNumber || !isLengthValid) {
      passwordError.textContent =
        "Password must contain at least 5 characters, an uppercase letter, a special character, and a number.";
    } else {
      passwordError.textContent = "";
    }
  });

  firstNameInput.addEventListener("blur", function () {
    const inputValue = firstNameInput.value;
    if (/[^a-zA-Z]/.test(inputValue)) {
      firstNameError.textContent = "First name must contain only letters.";
    } else {
      firstNameError.textContent = "";
    }
  });

  lastNameInput.addEventListener("blur", function () {
    const inputValue = lastNameInput.value;
    if (/[^a-zA-Z]/.test(inputValue)) {
      lastNameError.textContent = "Last name must contain only letters.";
    } else {
      lastNameError.textContent = "";
    }
  });

  dobInput.addEventListener("blur", function () {
    const selectedDate = new Date(dobInput.value);
    const currentDate = new Date();

    if (selectedDate > currentDate) {
      dobError.textContent = "Date of Birth cannot be in the future.";
    } else {
      dobError.textContent = "";
      const age = calculateAge(selectedDate);
      const ageInput = document.getElementById("age");
      ageInput.value = age;
    }
  });

  confirmPasswordInput.addEventListener("blur", function () {
    const passwordInputValue = passwordInput.value;
    const confirmPasswordValue = confirmPasswordInput.value;

    if (passwordInputValue !== confirmPasswordValue) {
      confirmPasswordError.textContent =
        "Confirm Password does not match Password.";
    } else {
      confirmPasswordError.textContent = "";
    }
  });
});

function calculateAge(birthDate) {
  const today = new Date();
  const birthDateObject = new Date(birthDate);
  let age = today.getFullYear() - birthDateObject.getFullYear();
  const monthDiff = today.getMonth() - birthDateObject.getMonth();

  if (
    monthDiff < 0 ||
    (monthDiff === 0 && today.getDate() < birthDateObject.getDate())
  ) {
    age--;
  }

  return age;
}
