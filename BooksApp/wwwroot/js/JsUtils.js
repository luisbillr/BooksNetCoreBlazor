window.ShowModal = function (selector) {
    let options = { backdrop: 'static' };
    $(selector).modal(options);
}
window.SweetMessageBox = function (message, icon, redirectTo = "", delayMilliSeconds, Reload = false) {
    Swal.fire({
        icon: icon,
        title: message,
        allowOutsideClick: false,
        showConfirmButton: false,
        showCloseButton: true,
        timer: delayMilliSeconds
        //text: 'Something went wrong!',
        //footer: '<a href>Why do I have this issue?</a>'
    }).then(function () {
        if (redirectTo != "") {
            window.location = redirectTo;
        }
        else if (Reload = true) {
            location.reload();
        }

    });
    return true;
}
window.BlockPage = function () {
    $.blockUI({
       // fadeIn: 1000,
        //baseZ: 1000,
        message: 'Procesando Solicitud...',
        css: {
            border: 'none',
            padding: '15px',
            backgroundColor: '#000',
            '-webkit-border-radius': '10px',
            '-moz-border-radius': '10px',
            opacity: .5,
            color: '#fff'
        }
    });
    return true;
}
window.UnBlockPage = function () {
    $.unblockUI({ fadeOut: 200 });
    return true;
}