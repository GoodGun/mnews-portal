function AddCategory() {
    debugger;
    Category = new Object();
    Category.Name = $("#categoryName").val();
    Category.Url = $("#categoryUrl").val();
    Category.IsActive = $("#categoryIsActive").is(":checked");

    $.ajax({
        url: "/Category/Add",
        data: Category,
        type: "POST",
        dataType: 'json',
        success: function () {
            if (response.Success) {
                //bootbox alert de message sonrası function'ı callback tanımlaması olarak yaptık
                bootbox.alert(response.Message, function () {
                    location.reload();
                });

            }
            else {
                bootbox.alert(response.Message);
            }
        }

    });
}