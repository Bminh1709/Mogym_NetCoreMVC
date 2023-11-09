window.addEventListener("scroll", function () {
    var header = document.querySelector(".header");
    var scrollPosition = window.scrollY;

    if (scrollPosition >= 300) {
        header.classList.add("scrolled");
    } else {
        header.classList.remove("scrolled");
    }
});


// CHANGE TYPE PASSWORD
$('#togglePassword').click(function () {
    var passwordInput = $('#passwordInput');
    var currentType = passwordInput.attr('type');

    if (currentType === 'password') {
        passwordInput.attr('type', 'text');
    } else {
        passwordInput.attr('type', 'password');
    }
});


// FEEDBACK SHIFTER
const feedbackSections = document.querySelectorAll('.feedback-item');
let currentSectionIndex = 0;

function showFeedbackSection(index) {
    feedbackSections.forEach((section, i) => {
        if (i === index) {
            section.classList.add('active');
        } else {
            section.classList.remove('active');
        }
    });
}

function nextFeedback() {
    currentSectionIndex = (currentSectionIndex + 1) % feedbackSections.length;
    showFeedbackSection(currentSectionIndex);
}

function prevFeedback() {
    currentSectionIndex = (currentSectionIndex - 1 + feedbackSections.length) % feedbackSections.length;
    showFeedbackSection(currentSectionIndex);
}

const nextFeedbackButton = document.querySelector('.next-feedback');
const prevFeedbackButton = document.querySelector('.prev-feedback');

if (nextFeedbackButton && prevFeedbackButton) {
    nextFeedbackButton.addEventListener('click', nextFeedback);
    prevFeedbackButton.addEventListener('click', prevFeedback);
}