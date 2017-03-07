function AddCategory() {
    var category = new Object();
    category.Name = $("#categoryName").val();
    category.Url = $("#categoryUrl").val();
    category.IsActive = $("#categoryIsActive").is(":checked");
    category.ParentCategoryId = $("#parentId").val();

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

function DeleteCategory()
{
    var catId = $("#deleteCategory").attr("data-id");
    
    $.ajax({
        url: "/category/delete/" + catId,
        data: catId,
        type: "POST",
        dataType: 'json',
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

function UpdateCategory()
{
    alert(1);
}