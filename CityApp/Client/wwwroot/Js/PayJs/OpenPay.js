export function openPayActions() {
    //OpenPay.setId('md7tjkzkt3t5hvivh4yj');
    //OpenPay.setApiKey('pk_bf57413907a94bf59f56e6dfd1e99c18');
    //OpenPay.setSandboxMode(true);


    //OpenPay.token.extractFormAndCreate(
    //    document.getElementById('#processCard'),
    //    successCard,
    //    errorCard,
    //    _customerId);

    //function SuccessCallback(response) {
    //    alert('Successful operation');
    //    var content = '', results = document.getElementById('resultDetail');
    //    content += 'Id card: ' + response.data.id + '<br />';
    //    content += 'Holder Name: ' + response.data.holder_name + '<br />';
    //    content += 'Card brand: ' + response.data.brand + '<br />';
    //    results.innerHTML = content;
    //}

    //function ErrorCallback(response) {
    //    alert('Fallo en la transacción');
    //    var content = '', results = document.getElementById('resultDetail');
    //    content += 'Estatus del error: ' + response.data.status + '<br />';
    //    content += 'Error: ' + response.message + '<br />';
    //    content += 'Descripción: ' + response.data.description + '<br />';
    //    content += 'ID de la petición: ' + response.data.request_id + '<br />';
    //    results.innerHTML = content;
    //}

    var device = "";

    $(document).ready(function () {
        OpenPay.setId('md7tjkzkt3t5hvivh4yj');
        OpenPay.setApiKey('pk_bf57413907a94bf59f56e6dfd1e99c18');
        OpenPay.setSandboxMode(true);
        device = OpenPay.deviceData.setup("payment-form", "deviceIdHiddenFieldName");
        $('#deviceIdFieldName').val(device);
    });

    $('#pay-button').on('click', function (event) {
        event.preventDefault();
        $("#pay-button").prop("disabled", true);
        OpenPay.token.extractFormAndCreate('payment-form', success_callbak, error_callbak);

    });

    var token_id = "";

    var success_callbak = function (response) {
        token_id = response.data.id;
        $('#token_id').val(token_id);
        alert('Successful operation');
        var content = '', results = document.getElementById('resultDetail');
        content += 'Id card: ' + response.data.id + '<br />';
        content += 'Holder Name: ' + response.data.holder_name + '<br />';
        content += 'Card brand: ' + response.data.brand + '<br />';
        results.innerHTML = content;
        envioOk();
        //document.getElementById('btn_refresh').click()
        /*$('#payment-form').submit();*/
    };

    var error_callbak = function (response) {
        var desc = response.data.description != undefined ?
            response.data.description : response.message;
        alert("ERROR [" + response.status + "] " + desc);
        $("#pay-button").prop("disabled", false);
    };

    function envioOk() {
        DotNet.invokeMethodAsync('CityApp.Client', 'GetDataPay', token_id, device);
    }
}