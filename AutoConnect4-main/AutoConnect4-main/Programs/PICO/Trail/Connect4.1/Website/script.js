$(document).ready(()=>
{
    console.log("working");
    lastModified();
})
function CallAjax(url, reqData, type, dataType, fxnSuccess, fxnError)
{
    let ajaxOptions={};
    ajaxOptions['url']= url;
    ajaxOptions['data']= JSON.stringify(reqData);
    ajaxOptions['type']= type;
    ajaxOptions['dataType']= dataType;
    ajaxOptions['contentType'] = "application/json"; // new for ASP part
    ajaxOptions['success'] = fxnSuccess;
    ajaxOptions['error'] = fxnError;

    $.ajax(ajaxOptions);
}
function Errors(ajaxReq, ajaxStatus, errorThrown)
{
    console.log(ajaxReq +" : "+ ajaxStatus +" : "+ errorThrown);
}
function lastModified()
{
    let string = 'Last Modified: ' + document.lastModified;
    console.log(string);
    $("#Modified").text(`${string}`);
}