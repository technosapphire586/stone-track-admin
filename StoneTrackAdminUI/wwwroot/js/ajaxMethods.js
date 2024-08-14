(function ($) {

        $('#btnUpdateStatus').click(function () {
            var uid = $("#UId").val();
            var status = $("#martialmaleapplicant").val();
            var data = {
                "OrderId": uid,
                "OrderStatus": status
            };
            $.ajax({
                url: "/Home/UpdateOrderStatus",
                type: "POST",
                data: data,
                dataType: 'json',
                success: function (data) {
                    alert(data);
                    window.setTimeout(function () { location.reload() }, 1000);
                },
                error: function () {
                    alert("An error has occured!!!");
                }
            });
        });

    $('#btnUpdateImage').click(function () {
        debugger
        let formData = new FormData()
        var d = $('#MyDoucment')[0].files[0]

        formData.append('OrderId', Number($('#UIde').val()));
        formData.append('UpdateDoucment', d);

        $.ajax({
            url: "/Home/UploadOrderDoucment",
           /* url: "@Url.Action("UploadOrderDoucment", "Home")",*/
            type: "POST",
            contentType: false,
            processData: false,
            data: formData,
            success: function (data) {
                alert(data);
                window.setTimeout(function () { location.reload() }, 1000);
            },
            error: function () {
                alert("An error has occured!!!");
            }
        });
    });


    $('#btnUpdatePaymentStatus').click(function () {
        debugger
        var uid = $("#UId1").val();
        var status = $("#martialmaleapplicant1").val();
        var data = {
            "OrderId": uid,
            "PaymentStatus": status
        };
        $.ajax({
            url: "/Home/UpdatePaymentStatus",
            type: "POST",
            data: data,
            dataType: 'json',
            success: function (data) {
                alert(data);
                window.setTimeout(function () { location.reload() }, 1000);
            },
            error: function () {
                alert("An error has occured!!!");
            }
        });
    });


})(jQuery);

