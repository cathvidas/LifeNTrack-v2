
const checkbox = document.getElementById("inviteFriends");
const selectContainer = document.getElementById("selectFriends");

checkbox.addEventListener("change", function () {
    if (checkbox.checked) {
        selectContainer.style.display = "block";
    } else {
        selectContainer.style.display = "none";
    }
});
