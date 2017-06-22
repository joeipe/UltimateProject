$(document).ready(function () {
    $('#AddStateDiv').hide();
    $('#EditStateDiv').hide();

    getStates();

    $('#btnAddState').click(function () {
        $('#txtStateName').val("");
        $('#AddStateDiv').fadeIn();
        $('#EditStateDiv').hide();
    });

    $('#btnCancel').click(function () {
        $('#AddStateDiv').fadeOut("slow");
    });

    $('#btnCancelEdit').click(function () {
        $('#EditStateDiv').fadeOut("slow");
    });

    $('#btnSubmit').click(function () {
        var data = {"ID":0,
            "Name": $('#txtStateName').val()
        };

        var json = JSON.stringify(data)

        $.ajax({
            url: 'http://localhost:43075/api/State/AddState',
            type: 'POST',
            contentType: 'application/json; charset=utf-8',
            data: json,
            success: function (results) {
                $('#AddStateDiv').fadeOut();

                $("#tblState TBODY").html("");
                getStates();
            }
        });
    });

    $('#btnSubmitEdit').click(function () {
        var stateID = $('#hdnEditStateID').val();
        var data = {
            "ID": 0,
            "Name": $('#txtStateNameEdit').val()
        };

        var json = JSON.stringify(data)

        $.ajax({
            url: 'http://localhost:43075/api/State/EditState?id=' + stateID,
            type: 'PUT',
            contentType: 'application/json; charset=utf-8',
            data: json,
            success: function (results) {
                $('#EditStateDiv').fadeOut();

                $("#tblState TBODY").html("");
                getStates();
            }
        });
    });
});

function getStates() {
    $.getJSON("http://localhost:43075/api/State/GetStates", function (Data) {
        $.each(Data, function (key, elem) {
            $('table#tblState TBODY').append('<tr><td><a href="#" onclick="editRow(' + elem.ID + ',\'' + elem.Name + '\');">Edit</a>&nbsp;<a href="#" onclick="delRow(' + elem.ID + ');">Delete</a></td></td><td>' + elem.Name + '</td></tr>');
        });
    });
}

function delRow(stateID) {
    var wantToDel = confirm("Are you sure you want to delete?");
    if (wantToDel)
        $.ajax({
            url: 'http://localhost:43075/api/State/DeleteState?id=' + stateID.toString(),
            type: 'DELETE',
            success: function (results) {
                $("#tblState TBODY").html("");
                getStates();
            }
        });
    else
        return false;
}

function editRow(stateID, stateName) {
    $('#EditStateDiv').fadeIn();
    $('#AddStateDiv').hide();

    $('#txtStateNameEdit').val(stateName);
    $('#hdnEditStateID').val(stateID);
}