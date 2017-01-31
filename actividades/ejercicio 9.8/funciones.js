function ver() {
    var boton = $(this);
    $("div").each(function () {
        $(this).find("p span").each(function () {
            $(this).toggle();
            if ($(this).css("display") == "none") {
                boton.text("Mostrar span interno");
            } else {
                boton.text("Ocultar span interno");
            }
        })
    })
    
};

//Añado evento onclick al boton

$("button").on("click", ver);
    