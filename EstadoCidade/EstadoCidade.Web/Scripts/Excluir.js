$(function() {
    $('.btn-excluir').click(function () {
        $('#modalExcluir').modal();
        $('#btn-confirmar-excluir').attr('data-id', $(this).attr('data-id'));
    });

    $('#btn-confirmar-excluir').click(function () {
        var url = $(this).attr('data-url');
        var id = $(this).attr('data-id');

        $.ajax({
            url: url + '/' + id,
            type: 'DELETE',
            success : function (dados) {
                $('tr[data-id=' + dados.Id + ']').hide('slow');
            }
        });

    });
});