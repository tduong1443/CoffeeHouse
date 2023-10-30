// Paging - Shop
$(document).ready(function () {
    $(document).on("click", ".page-link", function (e) {
        e.preventDefault();
        var url = $(this).attr("href");

        $.ajax({
            url: url,
            type: "GET",
            dataType: "html",
            success: function (data) {
                var content = $(data).find("#content");
                $("#content").html(content);
            },
            error: function () {
                alert("Đã xảy ra lỗi.");
            }
        });
    });
});

// Cart - ShopCart

$(document).ready(function () {
    $(document).on("click", ".add-to-cart", function (e) {
        e.preventDefault();
        var url = $(this).attr("href");

        $.ajax({
            url: url,
            type: "GET",
            dataType: "html",
            success: function (data) {
                var content = $(data).find(".table-reponsive");
                $(".table-reponsive").html(content);
                alert("Success")
            },
            error: function () {
                alert("Đã xảy ra lỗi.");
            }
        });
    });
});

// CartItem

$(document).ready(function () {
    $(document).on("click", ".btn", function (e) {
        e.preventDefault();
        var url = $(this).attr("href");

        $.ajax({
            url: url,
            type: "GET",
            dataType: "html",
            success: function (data) {
                var content = $(data).find(".table-reponsive");
                $(".table-reponsive").html(content);
            },
            error: function () {
                alert("Đã xảy ra lỗi.");
            }
        });
    });
});