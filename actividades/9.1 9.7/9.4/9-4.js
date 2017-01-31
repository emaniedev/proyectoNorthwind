function hola() {
    $("p:first").hide(1000);
}

function adios() {
    $("p:first").show(1000);
}

$("button").click(hola);
$("#mio").click(adios);