$(document).ready(function () {

    $('.account-btn').on('click', function () {
        var user_id = $(this).data('id');
        $('#userIdInput').val(user_id);
    });

});