function Validate()
{
    console.log('validando !!');
    $("#createProductForm").validate({
        rules: {
            descripcion: {
                required: true,
                minlength: 3
            },
            precioVenta: {
                required: true,
                number: true,
                min: 0
            },
            stockMinimo: {
                required: true,
                number: true,
                min: 0
            },
            stockActual: {
                required: true,
                number: true,
                min: 0
            },
            fechaVenta: {
                required: true,
                date: true
            },
            categoria: {
                required: true
            }
        },
        messages: {
            descripcion: "Por favor, ingrese una descripción válida.",
            precioVenta: "El precio de venta debe ser un número positivo.",
            stockMinimo: "El stock mínimo debe ser un número positivo.",
            stockActual: "El stock actual debe ser un número positivo.",
            fechaVenta: "Por favor, seleccione una fecha válida.",
            categoria: "Debe seleccionar una categoría."
        }
    });
}