function Sorgula() {
    CheckFieldAlertHide();
    var plaka = $('#plaka').val();
    var tckn = $('#tckn').val();
    var ruhsatSeriKodu = $('#ruhsatSeriKodu').val();
    var ruhsatSeriNo = $('#ruhsatSeriNo').val();
    if (plaka === "") {
        $('#plakaalert').show();
        return false;
    }
    else if (tckn === "") {
        $('#tcknalert').show();
        return false;
    }
    else if (ruhsatSeriKodu === "") {
        $('#ruhsatSeriKodualert').show();
        return false;
    }
    else if (ruhsatSeriNo === "") {
        $('#ruhsatSeriNoalert').show();
        return false;
    }

    $.ajax({
        url: "/Bid/GetBidByCompany",
        type: "POST",
        data: {
            plaka: plaka,
            tckn: tckn,
            ruhsatSeriKodu: ruhsatSeriKodu,
            ruhsatSeriNo: ruhsatSeriNo
        },
        success: function (result) {
            debugger;
            FillTable(result.dataResult);
        },
        error: function (xhr, textStatus, error) {
        },
        complete: function () {
        }
    });
}

$('#tckn').change(function () {
    var plaka = $('#plaka').val();
    var tckn = $('#tckn').val();
    if (plaka.length == 8 && tckn.length == 11) {
        $.ajax({
            url: "/Bid/GetRuhsatInfo",
            type: "POST",
            data: {
                plaka: plaka,
                tckn: tckn
            },
            success: function (result) {
                debugger;
                if (result.state) {
                    $('#ruhsatSeriKodu').val(result.dataResult.ruhsatSeriKodu);
                    $('#ruhsatSeriNo').val(result.dataResult.ruhsatSeriNo);
                }
            },
            error: function (xhr, textStatus, error) {
            },
            complete: function () {
            }
        });
    }
});
//$("#tckn").keypress(function () {
//    debugger;
//    alert("The text has been changed.");
//});
function FillTable(result) {

    var $select = $('#detailTable');
    $select.html('');

    var tablecontent = '<table class="table table-bordered">';
    tablecontent += '<thead><tr><th scope="col"></th><th scope="col">Firma Adı</th><th scope="col">Açıklama</th><th scope="col">Tutar</th></tr></thead>';
    tablecontent += '<tbody>';

    $.each(result, function (key, value) {
        debugger;
        tablecontent += '<tr>';
        tablecontent += '<th scope="row" ><img src="data:image/gif;base64,' + value.firmaLogo + '" style="width:50px;"/></th>';
        tablecontent += '<td>' + value.firmaAdi + '</td><td>' + value.teklifAciklama + '</td><td>' + value.teklifTutari + '</td></tr>';

    });

    debugger;
    tablecontent += '</tbody></table>';
    $select.append(tablecontent);

}
function CheckFieldAlertHide() {
    $('#plakaalert').hide();
    $('#tcknalert').hide();
    $('#ruhsatSeriKodualert').hide();
    $('#ruhsatSeriNoalert').hide();
}