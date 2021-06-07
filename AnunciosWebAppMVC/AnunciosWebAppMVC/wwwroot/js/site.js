function ReloadEvents(ptext, psel, pmin, pmax) {
    alert("Parametros" + ptext + ' ' + pmin + ' ' + pmax + ' ' + psel);
    //this.preventDefault();
    //this.stopPropagation();
    $.ajax({
        url: '/Anuncios/Buscar',
        type: "POST",
        data: {
            ptext: ptext,
            pmin: pmin,
            pmax: pmax,
            psel: psel
        }
    }).done(function (response) {
        console.log("Success");
        $("#listavista").replaceWith(response.html);
    }).fail(function () {
        console.log("Error");
    });

}