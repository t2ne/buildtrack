/*
 * Tradução PT-PT para jQuery Validation Plugin
 */
jQuery.extend(jQuery.validator.messages, {
    required: "Este campo é obrigatório.",
    remote: "Por favor, corrija este campo.",
    email: "Por favor, introduza um endereço de email válido.",
    url: "Por favor, introduza um URL válido.",
    date: "Por favor, introduza uma data válida.",
    number: "Por favor, introduza um número válido.",
    digits: "Por favor, introduza apenas dígitos.",
    creditcard: "Por favor, introduza um número de cartão de crédito válido.",
    equalTo: "Por favor, introduza novamente o mesmo valor.",
    maxlength: jQuery.validator.format("Por favor, não introduza mais do que {0} caracteres."),
    minlength: jQuery.validator.format("Por favor, introduza pelo menos {0} caracteres."),
    rangelength: jQuery.validator.format("Por favor, introduza um valor entre {0} e {1} caracteres."),
    range: jQuery.validator.format("Por favor, introduza um valor entre {0} e {1}."),
    max: jQuery.validator.format("Por favor, introduza um valor menor ou igual a {0}."),
    min: jQuery.validator.format("Por favor, introduza um valor maior ou igual a {0}.")
});
