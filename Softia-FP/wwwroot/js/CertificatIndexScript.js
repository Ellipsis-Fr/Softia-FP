
$("#selectStudent").change((e) => {

    $.ajax({
        url: "../Student/GetStudent",
        type: "POST",
        dataType: 'json',
        data: { "id": e.target.value },
        success: success,
        error: (error) => {
            console.log(error);
        }
    });
    
})

function success(result) {

    $("#conventionAssociated").attr("placeholder", result.studentConventionName);

    let message = "Bonjour, " + result.studentLastName + " " + result.studentFirstName + ", \n\n\n"
        + "Vous avez suivi " + result.studentConventionQtyHour + " heures de formation chez FormationPlus.\n"
        + "Pouvez vous nous retourner ce mail avec la pièce jointe signée.\n\n"
        + "Cordialement,\n"
        + "FormationPlus";

    $("#contentMail").val(message);
}