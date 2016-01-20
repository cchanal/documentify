function openEditModal(){
    $('#myCreateModal').modal('show');
}

function openDeleteModal() {
    $('#myDeleteModal').modal('show');
}

function openSuccess(message) {
    $('#success-message').html(message);
    $('#success-message').show();
    setTimeout(closeSuccess, 4000);
}

function closeSuccess() {
    $('#success-message').hide();
}
