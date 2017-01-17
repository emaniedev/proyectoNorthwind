var apiURL="http://localhost:8080/rss/rss.php?";
/**
 * llamadaAJAXGet
 * string url: la cadena de datos por metodo get.
 * string type: puede ser "text" o "json".
 * function callback: La función que se ejecuta cuando se obtiene la respuesta.
 */
function llamadaAJAXGet(url, type, callback){
    var URL = apiURL+url;
    $.ajax({
        type: "GET",
        url: URL,
        data: "",
        dataType: type,
        success: callback
    });
}

/**
 * numRSS
 * Nos devuelve la cantidad de RSS que tenemos
 */

function numRSS(){
    
    llamadaAJAXGet("accion=numRSS", "text", function (response){
        $("#cantRSS").text(response)
    });
    


}

function recursosRSS(){
    llamadaAJAXGet("accion=recursosRSS", "json", function(response){
        var todas="";
        $.each(response, function (index, rss) { 
             var nueva="<tr><td>"+rss.id+"</td><td>"+rss.titulo+"</td><td><a href='"+rss.url+"'>"+rss.url+"</a></td><td><button class='btn btn-sm btn-block btn-info' onclick='cargar("+rss.id+");'>Info</button><button class='btn btn-sm btn-block btn-danger' onclick='borrar("+rss.id+");'>Eliminar</button></td></tr>"
             todas+=nueva;
        });
        $("#tablaRSS").find("tbody").html(todas);
    });
}

function cargar(id){
    llamadaAJAXGet("accion=cargar&id="+id, "json", function (response){
        var todas="";
        $.each(response, function (index, rss){
            
            var nueva="<tr><td><h3><a href='"+rss.url+"'>"+rss.titulo+"</a><small>"+rss.fecha+"</small></h3><p>"+rss.descripcion+"</p></td></tr>";
            todas+=nueva;
            
        });
        $("#tablaFEEDS").find("tbody").html(todas);
        $("#liVer").addClass("active");
        $("#liRSS").removeClass("active");
        $("#Ver").addClass("active");
        $("#RSS").removeClass("active");
        

    });
}

function nueva(){
    var titulo = $("#titulo").val();
    var rssUrl = $("#rssurl").val();
    llamadaAJAXGet("accion=nueva&titulo="+titulo+"&url="+rssUrl, "text", function(response){
        $("#nuevaRSS").html("Se ha añadido el registro"+response);
        numRSS();
        recursosRSS();
    });
}

function borrar(id){
    llamadaAJAXGet("accion=borrar&id="+id, "text", function(response){
        $("#borrado").html(response);
        numRSS();
        recursosRSS();
    });
}







