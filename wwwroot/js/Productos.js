$(document).ready(function () {
    loadData();
});

function loadData() {
    $.ajax({
        url: '@Url.Action("GetProductos","Productos")',
        type: 'GET',
        success: function (response) {
           /*var x = JSON.parse(response);*/
            },
            error: function (errormessage) {
                console.log('Hubo un error al listar los Productos.');
            }
    });
}


                