function CargaReportePdf (objParam) {
    var urlConfig = "_flowId=viewReportFlow&standAlone=true&decorate=no&";
     var urlHost = document.getElementById("rptUrlDes").value;
     var urlRender = "&j_username=sedem&j_password=123456789&output=pdf";
     urlReport = objParam.ruta;
    urlReport = "reportUnit=" + urlReport.replace(/['/']/gi, '%2F');

    var urlParam = '';
    var urlFinal = '';

    if (typeof (objParam) != "undefined" && typeof (objParam) == "object") {
        var vObj = Object.getOwnPropertyNames(objParam);
        for (var i = 0; i < vObj.length; i++) {
            urlParam = urlParam + '&' + vObj[i] + '=' + objParam[vObj[i]];
        }
    }

    urlFinal = urlHost + urlConfig + urlReport + urlParam + urlRender;
     window.open(urlFinal, "SedemReport", "location=no,width=900,height=750,scrollbars=yes,top=0,left=750,resizable = no");
}
function CargaReportePdf2(objParam) {
    var urlConfig = "_flowId=viewReportFlow&standAlone=true&decorate=no&";
    var urlHost = "http://sisub.subsidio.gob.bo:9090/jasperserver/flow.html?";
    var urlRender = "&j_username=sedem&j_password=123456789&output=pdf";
    urlReport = objParam.ruta;
    urlReport = "reportUnit=" + urlReport.replace(/['/']/gi, '%2F');
    var urlParam = '';
    var urlFinal = '';

    if (typeof (objParam) != "undefined" && typeof (objParam) == "object") {
        var vObj = Object.getOwnPropertyNames(objParam);
        for (var i = 0; i < vObj.length; i++) {
            urlParam = urlParam + '&' + vObj[i] + '=' + objParam[vObj[i]];
        }
    }

    urlFinal = urlHost + urlConfig + urlReport + urlParam + urlRender;
    window.open(urlFinal, "SedemReport", "location=no,width=900,height=750,scrollbars=yes,top=0,left=750,resizable = no");
}

function CargaReportePop(objParam) {

    var urlConfig = "_flowId=viewReportFlow&standAlone=true&decorate=no&";
    var urlHost = document.getElementById("rptUrlDes").value;
    var urlRender = "&j_username=sedem&j_password=123456789";
    urlReport = objParam.ruta;
    urlReport = "reportUnit=" + urlReport.replace(/['/']/gi, '%2F');

    var urlParam = '';
    var urlFinal = '';

    if (typeof (objParam) != "undefined" && typeof (objParam) == "object") {
        var vObj = Object.getOwnPropertyNames(objParam);
        for (var i = 1; i < vObj.length; i++) {
            urlParam = urlParam + '&' + vObj[i] + '=' + objParam[vObj[i]];
        }
    }

    urlFinal = urlHost + urlConfig + urlReport + urlParam + urlRender;
    window.open(urlFinal, "SedemReport", "location=no,width=900,height=750,scrollbars=yes,top=0,left=750,resizable = no");
}

function CargaReporteExcel(objParam) {
    var urlConfig = "_flowId=viewReportFlow&standAlone=true&decorate=no&";
    var urlHost = document.getElementById("rptUrlDes").value;
    var urlRender = "&j_username=sedem&j_password=123456789&output=xls";
    var urlReport = objParam.ruta;
    urlReport = "reportUnit=" + urlReport.replace(/['/']/gi, '%2F');

    var urlParam = '';
    var urlFinal = '';

    if (typeof (objParam) != "undefined" && typeof (objParam) == "object") {
        var vObj = Object.getOwnPropertyNames(objParam);
        for (var i = 0; i < vObj.length; i++) {
            urlParam = urlParam + '&' + vObj[i] + '=' + objParam[vObj[i]];
        }
    }

    urlFinal = urlHost + urlConfig + urlReport + urlParam + urlRender;
    window.open(urlFinal, "SedemExcel", "location=no,width=900,height=750,scrollbars=yes,top=0,left=750,resizable=no");
}


function cambiarTextoYAxis() {
    var textElements = document.querySelectorAll('.mud-charts-yaxis text');
    textElements.forEach((textElement) => {
        var numero = Number(textElement.textContent);
        if (numero >= 1000000) {
            textElement.textContent = (numero / 1000000).toFixed(2) + "M";
        } else if (numero >= 1000) {
            textElement.textContent = (numero / 1000).toFixed(2) + "K";
        }
    });
    console.log("ejecutando función cambiarTextoYAxis");
}

