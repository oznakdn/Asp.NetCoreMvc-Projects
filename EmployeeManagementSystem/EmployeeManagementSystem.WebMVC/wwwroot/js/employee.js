


$(document).ready(function () {

 GetAll();

});


// GetAll method
function GetAll() {
    $.ajax({
        url: "/Employee/GetAll",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            var html = ``;
            var stringData = JSON.parse(result);
            $.each(stringData, function (key, value) {
                html += '<tr>';
                html += `<td><img src="${value.PhotoUrl}" style="max-width:50px;"/></td>`;
                html += `<td>${value.Firstname}</td>`;
                html += `<td>${value.Lastname}</td>`;
                html += `<td>${value.Gender}</td>`;
                html += `<td>${value.Department}</td>`;
                html += `<td>${value.StartDate}</td>`;
                html += `<td><a href="#" id="btnUpdate" class="btn btn-warning" onclick="GetById('${value.Id}'); return;">Edit</a></td>`;
                html += `<td><a href="#" id="btnDelete" class="btn btn-danger" onclick="Delete('${value.Id}'); return;">Delete</a></td>`;
            });
            $("#tableBody").html(html);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });

}

// Add method


function Add() {

    var res = validate();
    if (res === false) {
        return false;
    }
    var empObj = {
        firstname: $("#txtFirstname").val(),
        lastname: $("#txtLastname").val(),
        photoUrl: $("#txtPhotoUrl").val(),
        gender: $("#txtGender").val(),
        department: $("#txtDepartment").val(),
        startDate: $("#txtStartDate").val()
    };

    $.ajax({
        url: "/Employee/Add",
        type: "POST",
        dataType: "Json",
        data: { createModel:empObj },
        success: function (result) {
            GetAll();
            $("#employeeModal").trigger("click");
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

// GetById method
function GetById(Id) {
    $("#txtFirstname").css("border-color", "lightgrey");
    $("#txtLastname").css("border-color", "lightgrey");
    $("#txtPhotoUrl").css("border-color", "lightgrey");
    $("#txtGender").css("border-color", "lightgrey");
    $("#txtDepartment").css("border-color", "lightgrey");
    $("#txtStartDate").css("border-color", "lightgrey");

    $.ajax({
        url: "/Employee/Get/" + Id,
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "Json",
        success: function (result) {
            $("#txtId").val(result.id);
            $("#txtFirstname").val(result.firstname);
            $("#txtLastname").val(result.lastname);
            $("#txtPhotoUrl").val(result.photoUrl);
            $("#txtGender").val(result.gender);
            $("#txtDepartment").val(result.department);
            $("#txtStartDate").val(result.startDate);

            $("#employeeModal").modal('show');
            $("#btnUpdate").show();
            $("#btnAdd").hide();
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
    return false;
}

// Update method
function Update() {
    var res = validate();
    if (res == false) {
        return false;
    }

    var Id = $("#txtId").val();
    var empObj = {
        firstname:$("#txtFirstname").val(),
        lastname:$("#txtLastname").val(),
        photoUrl:$("#txtPhotoUrl").val(),
        gender: $("#txtGender").val(),
        department: $("#txtDepartment").val(),
        startDate: $("#txtStartDate").val()
    };
    $.ajax({
        url: "Employee/Update",
        type: "POST",
        dataType: "Json",
        data: {
            editModel: empObj,
            id:Id
        },
        /*data: JSON.stringify(empObj),*/
        success: function (result) {
            GetAll();
            $("#employeeModal").trigger("click");

            $("#txtId").val("");
            $("#txtFirstname").val("");
            $("#txtLastname").val("");
            $("#txtPhotoUrl").val("");
            $("#txtGender").val("");
            $("#txtDepartment").val("");
            $("#txtStartDate").val("");

        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }

    });

}

// Delete method
function Delete(Id) {

    var ans = confirm("Are you sure you want to delete this record!");
    if (ans) {
        $.ajax({
            url: "/Employee/Remove/" + Id,
            type: "POST",
            contentType: "application/json;charset=utf-8",
            dataType: "Json",
            success: function (result) {
                GetAll();
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
    }
}


// For to clear inputs

function ClearInputs() {
    $("#txtFirstName").val("");
    $("#txtLastName").val("");
    $("#txtPhotoUrl").val("");
    $("#txtGender").val("");
    $("#txtDepartment").val("");
    $("#txtStartDate").val("");

    $("#btnUpdate").hide();
    $("#btnAdd").show();

    $("#txtFirstName").css("border-color", "lightgrey");
    $("#txtLastName").css("border-color", "lightgrey");
    $("#txtPhotoUrl").css("border-color", "lightgrey");
    $("#txtGender").css("border-color", "lightgrey");
    $("#txtDepartment").css("border-color", "lightgrey");
    $("#txtStartDate").css("border-color", "lightgrey");
}

// For Validation
function validate() {
    var isValid = true;
    if ($("#txtFirstname").val().trim() == "") {
        $("#txtFirstname").css("border-color", "red");
        isValid = false;
    }
    else {
        $("#txtFirstname").css("border-color", "lightgrey");
    }

    if ($("#txtLastname").val().trim() == "") {
        $("#txtLastname").css("border-color", "red");
        isValid = false;
    }
    else {
        $("#txtLastname").css("border-color", "lightgrey");
    }

    if ($("#txtPhotoUrl").val().trim() == "") {
        $("#txtPhotoUrl").css("border-color", "red");
        isValid = false;
    }
    else {
        $("#txtPhotoUrl").css("border-color", "lightgrey");
    }

    if ($("#txtGender").val().trim() == "") {
        $("#txtGender").css("border-color", "red");
        isValid = false;
    }
    else {
        $("#txtGender").css("border-color", "lightgrey");
    }

    if ($("#txtDepartment").val().trim() == "") {
        $("#txtDepartment").css("border-color", "red");
        isValid = false;
    }
    else {
        $("#txtDepartment").css("border-color", "lightgrey");
    }

    if ($("#txtStartDate").val().trim() == "") {
        $("#txtStartDate").css("border-color", "red");
        isValid = false;
    }
    else {
        $("#txtStartDate").css("border-color", "lightgrey");
    }

    return isValid;


}
