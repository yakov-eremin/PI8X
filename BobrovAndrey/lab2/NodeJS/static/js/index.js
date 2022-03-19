$(function () {
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
    let pkFlower = e.target.dataset.pkflower;
    
    let pkFlowersDom = document.getElementById("PK_Flowers");
    if(pkFlowersDom) {
        pkFlowersDom.value = pkFlower;
    }
    let popup = document.getElementById("popup");
    popup.classList.remove("hidden");
}