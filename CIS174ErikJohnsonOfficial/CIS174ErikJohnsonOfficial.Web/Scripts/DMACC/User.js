function updateUser() {
    var userId = $("#userID").val();
    var pass = $("#gamePW").val();
    var userName = $("#userName").val();
    var firstName = $("#firstName").val();
    var lastName = $("#lastName").val();
    var gender = $("#gender").val();
    var email = $("#email").val();
    var phone = $("#phone").val();

    $.ajax({
        url: "Person/UpdateUser",
        dataType: "json",
        data: {
            PersonId: userId,
            UserName: userName,
            Password: pass,
            FirstName: firstName,
            LastName: lastName,
            Gender: gender,
            Email: email,
            PhoneNumber: phone
        }
    }).done(function (data) {
        if (data) {
            $("#successMessage").removeClass("hidden").addClass("visible");
        } else {
            $("#errorMessage").removeClass("hidden").addClass("visible");
        }
    });
}