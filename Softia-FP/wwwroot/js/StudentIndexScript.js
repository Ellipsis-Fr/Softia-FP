$("#mail").change(e => {
    $.ajax({
        url: "../Student/CheckMailNotExists",
        type: "POST",
        dataType: 'json',
        data: { "mail": e.target.value },
        success: success,
        error: (error) => {
            console.log(error);
        }
    });
})

function success(result) {

    if (result.isDouble) {
        let messageError = $("<p>Mail déjà existant</p>");
        messageError.css("color", "red");
        messageError.attr("id", "messageError");

        $("#contentMessageError").append(messageError);

        $("#submitBtn").prop("disabled", true);
    } else {
        $("#contentMessageError").empty();
        $("#submitBtn").prop("disabled", false);
    }
}

$("#resetBtn").click(() => {
    $("#contentMessageError").empty();
    $("#submitBtn").prop("disabled", false);
});