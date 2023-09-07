function showSuccessPrompt() {
  alert(
    "Your message has been reched to us!! We will reach out to you with the reply very soon."
  );
}
document.addEventListener("DOMContentLoaded", function () {
  const form = document.querySelector("form");

  if (form) {
    form.addEventListener("submit", function (event) {
      event.preventDefault();
      form.reset();
      showSuccessPrompt();
    });
  }
});
