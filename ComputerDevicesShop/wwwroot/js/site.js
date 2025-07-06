// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(function () {
    $(".star").rateYo({
        starWidth: "10px",
        rating: 4,
        fullStar: true,
        spacing: "7px"
    });
    //$("#submitRating").click(function () {
    //    var rating = $("#ratingValue").val();
    //    var itemId = 123; // например, id устройства или товара

    //    $.ajax({
    //        url: '/Ratings/SaveRating',
    //        type: 'POST',
    //        data: {
    //            rating: rating,
    //            itemId: itemId
    //        },
    //        success: function (response) {
    //            alert("Оценка сохранена");
    //        },
    //        error: function () {
    //            alert("Ошибка при сохранении");
    //        }
    //    });
    //});
    //$("#getRating").click(function () {
    //    var rating = $(".star").rateYo("rating");
    //    alert("Вы выбрали рейтинг: " + rating);
    //});
})
function setRate(deviceId) {
    // Получаем значение рейтинга из RateYo
    var rating = $("#getRating").rateYo("rating");
    console.log(rating)
    // Отправляем в контроллер через AJAX
    $.ajax({
        url: '/Home/SaveRating',
        type: 'POST',
        data: {
            rating: rating,
            deviceId: deviceId
        },
        success: function () {
            console.log("Рейтинг сохранен: " + rating);
        },
        error: function () {
            console.error("Ошибка при сохранении рейтинга");
        }
    });
}


