
$('#formService').validate({
    rules: {
        "Title": {
            required: true
        },
        "Description": {
            required: true,
            minlength: 10
        },
        "Price": {
            required: true,
            number: true
        },
        "StartDate": {
            required: true
        },
        "EndDate": {
            required: true
        }
    },
    messages: {
        "Title": {
            required: "Tiêu đề không được để trống"
        },
        "Description": {
            required: "Mô tả không được để trống",
            minlength: "Mô tả ít nhất 10 ký tự"
        },
        "Price": {
            required: "Giá không được để trống",
            number: "Giá phải là một số"
        },
        "StartDate": {
            required: "Ngày bắt đầu không được để trống"
        },
        "EndDate": {
            required: "Ngày kết thúc không được để trống"
        }
    },
    //submitHandler: function (form) {
    //    // Your form submission logic here
    //    form.submit();
    //}
});

$('#package-item__add').on('click', function () {
    $('#service_id').val("");
    $('#service_title').val("");
    $('#service_description').val("");
    $('#service_price').val("");
    $('#service_startDate').val("");
    $('#service_endDate').val("");
    $('#service_img').attr('src', '/Image/System/no-image.png');
    $('#formService').validate().resetForm();
});

$('.package-item__edit').on('click', function () {
    $('#loading-spinner').show();

    var service_id = $(this).data('id');
    $.ajax({
        url: '/Admin/Home/GetService',
        type: 'Get',
        data: { serviceId: service_id },
        success: function (rs) {
            if (rs.data != null) {
                console.log(rs.data)
                $('#service_id').val(rs.data.id);
                $('#service_title').val(rs.data.title);
                $('#service_description').val(rs.data.description);
                $('#service_price').val(rs.data.price);
                $('#service_startDate').val(rs.data.startDate.substr(0, 10));
                $('#service_endDate').val(rs.data.endDate.substr(0, 10));
                $('#service_img').attr('src', "/Image/Service/" + (rs.data.image ?? "no-image.png"));
            } else {
                alert("Error occurred: " + rs.error);
                location.reload(true);
            }
        },
        error: function () {
            window.location.href = '/Home/Error/404';
        },
        complete: function () {
            $('#loading-spinner').hide();
        }
    });
});

$('.package-item__remove').on('click', function () {

    var service_id = $(this).data('id');

    $('#serviceDelete_id').val(service_id);

});