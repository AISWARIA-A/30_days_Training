//first name validation
function Checkfirstname() {
    var isFname = /^[a-zA-Z]+$/;
    let fnameinput = document.getElementById("fname");

    if (fnameinput.value.trim() === "") {
        setError(fnameinput, "Empty first name");
    }
    else if (!isFname.test(fnameinput.value.trim())) {
        setError(fnameinput, 'Name cannot be a number or special characters');
    }
    else {
        setSuccess(fnameinput);
    }
}
//Name validation
function Checkname() {
    var isFname = /^[a-zA-Z]+$/;
    let fnameinput = document.getElementById("name");

    if (fnameinput.value.trim() === "") {
        setError(fnameinput, "Empty name");
    }
    else if (!isFname.test(fnameinput.value.trim())) {
        setError(fnameinput, 'Name cannot be a number or special characters');
    }
    else {
        setSuccess(fnameinput);
    }
}
//Lastname validation
function Checklastname() {
    var isLname = /^[a-zA-Z]+$/;
    let lnameinput = document.getElementById("lname");

    if (lnameinput.value.trim() === "") {
        setError(lnameinput, "Empty Last name");
    }
    else if (!isLname.test(lnameinput.value.trim())) {
        setError(lnameinput, 'Name cannot be a number or special characters');
    }
    else {
        setSuccess(lnameinput);
    }
}

//Gender validation
function Checkgender() {
    let fnameinput = document.getElementById("gender");

    if (fnameinput.value === "") {
        setError(fnameinput, "Empty Gender");
    }
    else {
        setSuccess(fnameinput);
    }
}

//Phone number validation
function Checkphone() {
    var isPhone = /^\d{10}$/;
    let phoneinput = document.getElementById("phone");

    if (phoneinput.value.trim() === "") {
        setError(phoneinput, "Empty phone number");
    }
    else if (!isPhone.test(phoneinput.value.trim())) {
        setError(phoneinput, 'Enter a valid number');
    }
    else {
        setSuccess(phoneinput);
    }
}

//Email validation
function Checkemail() {
    var isEmail = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/;
    let emailinput = document.getElementById("email");

    if (emailinput.value.trim() === "") {
        setError(emailinput, "Empty email");
    }
    else if (!isEmail.test(emailinput.value.trim())) {
        setError(emailinput, 'Enter valid email');
    }
    else {
        setSuccess(emailinput);
    }
}

//Address validation
function Checkaddress() {
    let addressinput = document.getElementById("address");

    if (addressinput.value.trim() === "") {
        setError(addressinput, "Empty Address");
    }
    else {
        setSuccess(addressinput);
    }
}
//City validation
function Checkcity() {
    var isCity = /^[a-zA-Z]+$/;
    let cityinput = document.getElementById("city");

    if (cityinput.value.trim() === "") {
        setError(cityinput, "Empty city");
    }
    else {
        setSuccess(cityinput);
    }
}
//State validation
function Checkstate() {
    var isName = /^[a-zA-Z]+$/;
    let nameinput = document.getElementById("state");

    if (nameinput.value.trim() === "") {
        setError(nameinput, "Empty state");
    }
    else {
        setSuccess(nameinput);
    }
}
//Old password validation
function Checkoldpassword() {
    var isOldPassword = /^\d{6}$/;
    let oldPasswordinput = document.getElementById("oldpassword");

    if (oldPasswordinput.value.trim() === "") {
        setError(oldPasswordinput, "Empty old password");
    }
    else {
        setSuccess(oldPasswordinput);
    }
}

//Username validation
function Checkusername() {
    var isName = /^[a-zA-Z]+$/;
    let nameinput = document.getElementById("username");

    if (nameinput.value.trim() === "") {
        setError(nameinput, "Empty username");
    }
    else {
        setSuccess(nameinput);
    }
}

//Password validation
function Checkpassword() {
    var isPwd = /^[A-Za-z@_!]\w{7,14}$/;
    let pwdinput = document.getElementById("password");
    if (pwdinput.value.trim() === "") {
        setError(pwdinput, "Empty password");
    }
    else if (!isPwd.test(pwdinput.value.trim())) {
        setError(pwdinput, 'Enter strong password');
    }
    else {
        setSuccess(pwdinput);
    }
}

//Confirm password validation
function Checkconfirmpassword() {
    let pwd2input = document.getElementById("confirmpassword");
    let pwdinput = document.getElementById("password");
    if (pwd2input.value.trim() === "") {
        setError(pwd2input, 'Empty password');
    }
    else if (pwd2input.value.trim() === pwdinput.value.trim()) {
        setSuccess(pwd2input);
    }
    else {
        setError(pwd2input, "Password didn't match");
    }
}

//Date validation
function Checkdob() {
    let dateinput = document.getElementById("dob");
    if (dateinput.value.trim() === "") {
        setError(dateinput, "Empty date of birth");
    }
    else if (!isDate.test(dateinput.value.trim())) {
        setError(dateinput, 'Enter valid date');
    }
    else {
        setSuccess(dateinput);
    }
}

//Future date disabled
var todayDate = new Date();
var maxDate = new Date();
maxDate.setFullYear(todayDate.getFullYear() - 18);

var month = maxDate.getMonth() + 1; // Add 1 to month to account for 0-based indexing
var day = maxDate.getDate();

if (month < 10) {
    month = "0" + month;
}

if (day < 10) {
    day = "0" + day;
}

var formattedMaxDate = maxDate.getFullYear() + "-" + month + "-" + day;

document.getElementById("dob").setAttribute("max", formattedMaxDate);
document.getElementById("dob").setAttribute("min", "1900-01-01");



//Submit button validation
function Checkvalidation() {
    Checkfirstname();
    Checklastname();
    Checkgender();
    Checkphone()
    Checkemail();
    Checkaddress();
    Checkcity();
    Checkstate()
    CheckoldPassword();
    Checkusername();
    Checkpassword();
    Checkconfirmpassword();
    Checkdob();
    Checkname();
}


//Functions for set errors
function setError(input, message) {
    let submitbutton = document.getElementById("button")
    const formControl = input.parentElement;
    const small = formControl.querySelector('small');
    small.className = "smallshown";
    small.innerText = message;
    submitbutton.disabled = true;
}

function setSuccess(input) {
    let submitbutton = document.getElementById("button")
    const formControl = input.parentElement;
    const small = formControl.querySelector('small');
    small.className = "smallhidden";
    small.innerHTML = "";
    submitbutton.disabled = false;
}