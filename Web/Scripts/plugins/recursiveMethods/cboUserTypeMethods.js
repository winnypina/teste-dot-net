if ($("#cboUserType").change(function ()
{
    CheckCboUserTypeValue()
}));


function CheckCboUserTypeValue()
{
    if ($("#cboUserType").val() == "2") {
        $('#iUserID').attr('placeholder', 'CNPJ');
        $('#iUserID').mask('999.99.999/9999-9');
    } else {
        $('#iUserID').attr('placeholder', 'Usuário SSO');
        $('#iUserID').unmask();
    }

    $('#iUserID').val('');


}