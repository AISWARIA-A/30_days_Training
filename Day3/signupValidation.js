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
