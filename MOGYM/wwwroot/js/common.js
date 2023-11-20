$('body').on('change', '#package-form__img', function () {
    const file = this.files[0];
    if (file) {
        let reader = new FileReader();
        reader.onload = function (event) {
            $('#service_img').attr('src', event.target.result);
        };
        reader.readAsDataURL(file);
    }
});