


function formatTime(timeString) {
    const [hours, minutes, seconds] = timeString.split(':');

    const formattedTime = new Date();
    formattedTime.setHours(parseInt(hours));
    formattedTime.setMinutes(parseInt(minutes));
    formattedTime.setSeconds(parseInt(seconds));

    const formattedHours = formattedTime.getHours() % 12 || 12;
    const ampm = formattedTime.getHours() >= 12 ? 'PM' : 'AM';

    // Create the 12-hour time string
    const formattedTimeString = `${formattedHours}:${minutes} ${ampm}`;

    return formattedTimeString;
}


document.querySelectorAll('.event-button').forEach(function(button) {
    button.addEventListener('click', function() {
        // alert(this.getAttribute('data-event-id'))
        const eventID = this.getAttribute('data-event-id');
        const eventTitle = this.getAttribute('data-event-title');
        const eventDate = this.getAttribute('data-event-date');
        const eventTime = this.getAttribute('data-event-time');
        const eventLocation = this.getAttribute('data-event-location');
        const eventDescription = this.getAttribute('data-event-description');
        const eventOotd = this.getAttribute('data-event-ootd');

        document.querySelector('#display-activity-modal .modal-title').textContent = eventTitle;
        document.querySelector('#display-activity-modal .event-description').textContent = eventDescription;
        document.querySelector('#display-activity-modal .event-location').textContent = eventLocation;
        document.querySelector('#display-activity-modal .event-date').textContent = eventDate;
        document.querySelector('#display-activity-modal .event-time').textContent = formatTime(`${eventTime}`);
        document.querySelector('#display-activity-modal .event-ootd').textContent = eventOotd;


        document.querySelector('#edit-activity-modal input[name="title"]').value = eventTitle;
        document.querySelector('#edit-activity-modal input[name="date"]').value = eventDate;
        document.querySelector('#edit-activity-modal input[name="time"]').value = eventTime;
        document.querySelector('#edit-activity-modal input[name="address"]').value = eventLocation;
        document.querySelector('#edit-activity-modal textarea[name="description"]').value = eventDescription;
        document.querySelector('#edit-activity-modal input[name="ootd"]').value = eventOotd;

        // const newAction = '../../../server/controllers/updateEvent.php?event=' + eventID;
        const newACtion = `../../../server/controllers/updateEvent.php?event=${eventID}`;
        document.querySelector('#edit-activity-modal form').setAttribute('action', newACtion);

        const statusAction = `../../../server/controllers/setActivityStatus.php?event=${eventID}`;
        document.querySelector('#set-activity-modal form').setAttribute('action', statusAction);


        const deleteAction = `../../../server/controllers/deleteActivity.php?event=${eventID}`;
        document.querySelector('#delete-activity-modal form').setAttribute('action', deleteAction);

    });
});

const eventDetails = document.querySelectorAll('.service-item .event-details');
const textContainers = document.querySelectorAll('.service-item p.event-desc');
const toggleButtons = document.querySelectorAll('.service-item.event-cards');
toggleButtons.forEach((button, index) => {
    button.addEventListener('click', () => {
        // Toggle between hidden and block display and nowrap and normal white-space
        if (eventDetails[index].style.display === 'none') {
            eventDetails[index].style.display = 'block';
            textContainers[index].style.whiteSpace = 'normal';
        } else {
            eventDetails[index].style.display = 'none';
            textContainers[index].style.whiteSpace = 'nowrap';
        }
    });
});


const checkbox = document.getElementById("inviteFriends");
const selectContainer = document.getElementById("selectFriends");

checkbox.addEventListener("change", function () {
    if (checkbox.checked) {
        selectContainer.style.display = "block";
    } else {
        selectContainer.style.display = "none";
    }
});


// function changePassword(event) {
//     event.preventDefault(); // Prevent the form from submitting

//     const newPassword = document.querySelector('#changePassForm #newPassword').value;
//     const confirmPassword = document.querySelector('#changePassForm #renewPassword').value;

//     if (newPassword && confirmPassword) {
//         if (newPassword == confirmPassword) {
//             alert('Successfully changed password');
//         }
//         else {
//             alert('New Password and confirm password must match');
//         }
//     }
// }

// // Attach the function to the form's submit event
// document.getElementById('changePassForm').addEventListener('submit', verifyLogin);
    