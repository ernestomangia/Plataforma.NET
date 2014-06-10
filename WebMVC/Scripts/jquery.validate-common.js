jQuery.extend(jQuery.validator.messages, {
    required: "Este campo es obligatorio",
    email: "Por favor, ingrese un email válido.",
    date: "Por favor, ingrese una fecha válida.",
    number: "Por favor, ingrese un número válido.",
    digits: "Por favor, ingrese solo digitos.",
    maxlength: jQuery.validator.format("Por favor, no ingrese mas de {0} characters."),
    minlength: jQuery.validator.format("Por favor, ingrese al menos {0} characters.")
});
