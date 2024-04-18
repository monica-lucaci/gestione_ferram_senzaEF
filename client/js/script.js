let base_url = "https://localhost:7108/Prodotto/";

const stampaTabella = () => {
    $.ajax(
        {
            url: base_url + "nonfiltrati",
            type: "GET",
            success: function(risultato){
                if(risultato.status == "SUCCESS"){
                    let contenuto = "";
                    for(let [i,o] of risultato.data.entries()){
                        contenuto += `
                            <tr data-codice="${o.cod}">
                                <td>${o.nom}</td>
                                <td>${o.des}</td>
                                <td>${o.pre}</td>
                                <td>
                                    <div class="row">
                                        <div class="col-md-4">
                                            <button type="button" class="btn btn-primary btn-block" onclick="decrementa(this)">-</button>
                                        </div>
                                        <div class="col-md-4 text-center">
                                            <strong>${o.qua}</strong>
                                        </div>
                                        <div class="col-md-4">
                                            <button type="button" class="btn btn-primary btn-block" onclick="incrementa(this)">+</button>
                                        </div>
                                    </div>
                                </td>
                                <td>${o.cat}</td>
                                <td>
                                    <button type="button" class="btn btn-primary" onclick="elimina(this)">Elimina</button>
                                </td>
                            </tr>
                        `
                    }
                    $("#corpo-tabella").html(contenuto);
                }
                else
                    alert("ERRORE di reperimento dati");
            },
            error: function(errore){
                alert("ERRORE");
                console.log(risultato)
            }
        }
    );
}

const elimina = (varElemento) => {
    let codice = $(varElemento).parent().parent().data("codice");

    // let codice = $(varElemento).data("codice");

    $.ajax(
        {
            url: base_url + "elimina/" + codice,
            type: "DELETE",
            success: function(risultato){
                switch(risultato.status){
                    case "SUCCESS":
                        alert("Ok");
                        stampaTabella();
                        break;
                    case "ERROR":
                        alert(risultato.data);
                        break;
                }
            },
            error: function(errore){
                alert("ERRORE");
                console.log(errore)
            }
        }
    );
}


const modificaQuan = (varElemento,varModalita) => {
    let codice = $(varElemento).parent().parent().data("codice");
    $.ajax(
    {
        url:`${base_url} quantita/${cdice}/${varModalita ? 'incremento' : 'decremento'}`,
        type: "GET",
        success: function() {
            
        }
    })
}




$(document).ready(
    function(){
        stampaTabella();
    }
);