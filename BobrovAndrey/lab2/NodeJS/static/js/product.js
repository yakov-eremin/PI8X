$(function () {
    $('.carousel-control-prev').click(() => {
        $('#carousel').carousel('prev');
    });
    $('.carousel-control-next').click(() => {
        $('#carousel').carousel('next');
    });
    $('.orderBtn').click(buy);
    $('#popupClose').click(() => {
        let popup = document.getElementById("popup");
        popup.classList.add("hidden");
    });
    $("button.navbar-toggler").on("click", function(e) {
        var target = $(this).data("target");
        $(target).toggleClass("show");
    });
})

function buy(e) {
    e.preventDefault();
    let popup = document.getElementById("popup");
    popup.classList.remove("hidden");
}