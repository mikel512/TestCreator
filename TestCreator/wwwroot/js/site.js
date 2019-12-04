// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$('#showClasses').click(function () {
    $('.center').show();
});

$('#questionSelector').change(function () {
    $('.divAnswers').hide();
    $('#' + $(this).val()).show();
});

function questionChange(Id, questions) {
    $('#qNameShow').show();
    for (var x = 0; x < questions.length;x++) {
        if (questions[x].questionID == id) {
            $('#questionNameBox').val() = q.questionContent;
        }
    }

}