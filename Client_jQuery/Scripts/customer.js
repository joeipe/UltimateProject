$(document).ready(function () {
    $.getJSON("http://localhost:43075/api/Customer/GetAllCountries", function (Data) {
        $.each(Data, function (key, elem) {
            $('#dropDownCountry').append($('<option></option>').val(elem.Country).html(elem.Country));
        });
    });

    $.getJSON("http://localhost:43075/api/Customer/GetAllCustomers", function (Data) {
        $.each(Data, function (key, elem) {
            $('table#tbl TBODY').append('<tr><td>' + elem.ID + '</td><td>' + elem.CompanyName + '</td><td>' + elem.ContactName + '</td><td>' + elem.ContactTitle + '</td><td>' + elem.Address + '</td><td>' + elem.Country + '</td></tr>');
        });
    });

    $("#dropDownCountry").change(function () {
        $("#tbl TBODY").html("");

        var url = "http://localhost:43075/api/Customer/GetCustomersByCountry?country=" + $(this).val();

        $.getJSON(url, function (Data) {
            $.each(Data, function (key, elem) {
                $('table#tbl TBODY').append('<tr><td>' + elem.ID + '</td><td>' + elem.CompanyName + '</td><td>' + elem.ContactName + '</td><td>' + elem.ContactTitle + '</td><td>' + elem.Address + '</td><td>' + elem.Country + '</td></tr>');
            });
        });
    });
});