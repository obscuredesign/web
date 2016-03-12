$(function () {
    $(".datepicker").datepicker();

    var orderCount = 0;
    $('.ObscureDesign_Management_Article_Postprocessors').multiselect({
        buttonText: function (options) {
            if (options.length == 0) {
                return '---';
            }
            else {
                var selected = [];
                options.each(function () {
                    selected.push([$(this).text(), $(this).data('order')]);
                });

                selected.sort(function (a, b) {
                    //undefined hack necessary because buttonText executes before onChange
                    return (a[1] === undefined ? 999999 : a[1]) - (b[1] === undefined ? 999999 : b[1])
                })

                var text = '';
                for (var i = 0; i < selected.length; i++) {
                    text += selected[i][0] + ', ';
                }

                return text.substring(0, text.length - 2) + ' ';
            }
        },
        onChange: function (option, checked) {
            if (checked) {
                orderCount++;
                $(option).data('order', orderCount);
                $("input[name='Postprocessors[" + option.val() + "]']").val(orderCount);
            }
            else {
                $(option).removeData('order');
                $("input[name='Postprocessors[" + option.val() + "]']").val("");
            }
        }
    });
});