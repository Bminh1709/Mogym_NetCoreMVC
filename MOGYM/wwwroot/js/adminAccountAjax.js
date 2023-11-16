$(document).ready(function () {

    $('.account-btn').on('click', function () {
        var user_id = $(this).data('id');
        $('#userIdInput').val(user_id);
        $.ajax({
            url: '/Admin/Account/GetRole',
            type: 'Get',
            data: { userId: user_id },
            success: function (rs) {
                if (rs.success) {
                    var branchId = rs.branchId;
                    var roleId = rs.roleId;

                    if (branchId == 0) {
                        $('#branchSelectList').val('');
                    } else {
                        $('#branchSelectList').val(branchId);
                    }

                    if (roleId == 0) {
                        $('#roleSelectList').val('');
                    } else {
                        $('#roleSelectList').val(roleId);
                    }
                }
            }
        });
    });

});