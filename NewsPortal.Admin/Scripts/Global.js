function AddCategory() {
    var category = new Object();
    category.Name = $("#categoryName").val();
    category.Url = $("#categoryUrl").val();
    category.IsActive = $("#categoryIsActive").is(":checked");
    category.ParentCategoryId = $("#ParentCategoryId").val();

    $.ajax({
        url: "/category/add",
        data: category,
        type: "POST",
        success: function (response) {
            if (response.Success) {
                bootbox.alert(response.Message, function () {
                    location.reload();
                });
            }
            else {
                bootbox.alert(response.Message, function () {

                });
            }
        }
    });
}