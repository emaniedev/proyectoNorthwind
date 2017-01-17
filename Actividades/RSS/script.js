var apiUrl="http://localhost/rssphp/rss.php?";
$(document).ready(function () {
    numRSS();
    recursosRSS();
});
function numRSS() {
    var Url=apiUrl+"accion=numRSS";
    $.ajax({
        type: "GET",
        url: Url,
        data: "",
        dataType: "text",
        success: function (response) {
            $("#listarss-nav").find("a").html("Recursos RSS:"+response);
        }
    });
}
function recursosRSS() {
    var Url=apiUrl+"accion=recursosRSS";
    var resultado="";
    $.ajax({
        type: "GET",
        url: Url,
        data: "",
        dataType: "json",
        success: function (response) {
            $.each(response, function (index, rss) { 
                var fila="<tr><td>"+rss.id+"</td><td>"+rss.titulo+"</td><td>"+rss.url+"</td><td><button class='btn btn-sm btn-block btn-info' onclick='cargar("+rss.id+");'>Info</button><button class='btn btn-sm btn-block btn-danger' onclick='borrar("+rss.id+");'>Eliminar</button></td></tr>";
                resultado+=fila; 
            });
            $("#tabla1").find("tbody").html(resultado);
        }
    });
}
function cargar(id) {
    var Url=apiUrl+"accion=cargar&id="+id;
    var resultado="";
    $.ajax({
        type: "GET",
        url: Url,
        data: "",
        dataType: "json",
        success: function (response) {
            $.each(response, function (index, rss) { 
                 var fila="<tr><td><h4><a href='"+rss.url+"'>"+rss.titulo+"</a><small>"+rss.fecha+"</small></h4><p>"+rss.descripcion+"</p></td></tr>";
                 resultado+=fila; 
            });
            $("#tabla2").find("tbody").html(resultado);
            $("#listarss-nav").removeClass("active");
            $("#noticiasrss-nav").addClass("active");
            $("#seccion1").removeClass("active");
            $("#seccion2").addClass("active");
        }
    });
}
function nueva() {
    var titulo=$("#titulo").val();
    var urlrss=$("#url").val();
    var Url=apiUrl+"accion=nueva&titulo="+titulo+"&url="+urlrss;
    $.ajax({
        type: "GET",
        url: Url,
        data: "",
        dataType: "text",
        success: function (response) {
            $("#nueva").html("Registro añadido "+response);
            numRSS();
            recursosRSS();
        }
    });
}
function borrar(id) {
    var Url=apiUrl+"accion=borrar&id="+id;
    $.ajax({
        type: "GET",
        url: Url,
        data: "",
        dataType: "text",
        success: function (response) {
            $("#borrar").html(response);
            numRSS();
            recursosRSS();
        }
    });
}