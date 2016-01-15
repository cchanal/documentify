function openModal(){
    $('#myModal').modal('show');
}

function openSuccess() {
    $('#success-message').show();
    setTimeout(closeSuccess, 4000);
}

function closeSuccess() {
    $('#success-message').hide();
}