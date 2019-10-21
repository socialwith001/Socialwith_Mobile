//가로 스크롤 이동 메뉴
$(document).ready(function () {
    var sidePixel = 0;
    var url = location.href;
    var urlArray = url.split("plan");
    var url2Level, url3Level;

    $(".nav li").removeClass("active");
    if (urlArray.length == 1) {
        if (url.split("calendar").length == 1) {
            $(".home-gnb").addClass("active");
            sidePixel = 0;
        } else {
            $(".calendar-gnb").addClass("active");
        }
    } else {
        url2Level = urlArray[1].split("?")[0].replace("/", "")
        if (url2Level == "day") {
            $(".day-gnb").addClass("active");
            sidePixel = -40;
        } else if (url2Level == "refur") {
            $(".refur-gnb").addClass("active");
            sidePixel = -140;
        } else if (url2Level == "promotion") {
            $(".promotion-gnb").addClass("active");
            sidePixel = -250;
        } else if (url2Level == "newproducts") {
            $(".newproducts-gnb").addClass("active");
            sidePixel = -280;
        } else if (url2Level == "navimro") {
            $(".navimro-gnb").addClass("active");
            sidePixel = -250;
        } else {
            url3Level = url.split("=");
            if (url3Level[1] == "117") {
                $(".overseas").addClass("active");
                sidePixel = -320;
            } else {
                $(".plan-gnb").addClass("active");
                sidePixel = -250;
            }
        }
    }
    // 서브메뉴 가로 스크롤 이동
    setTimeout(function () {
        $(".nav").css("transform", "translateZ(0px) translateX(" + sidePixel + "px)");
    }, 500);
});

/* 스크롤에따라 플로팅 가능한기능[지정위치부터 fixed] */
$(window).scroll(function () {
    if ($(window).scrollTop() >= 52) {
        $(".gnb").css({ position: 'fixed' });
        $("#mainHeader").hide();
    } else {
        $(".gnb").css({ position: '' });
        $("#mainHeader").show();
    }
});


$(document).ready(function () {
    var slider = $('.bxslider').bxSlider({
        auto: true,
        autoControls: false,
        controls: true,
        pager: false,
        pagerType: 'short',
        touchEnabled: true,
    });

    // 클릭시 멈춤 현상 해결 //
    $(document).on('click', '.bx-next, .bx-prev,  #bx-pager1', function () {
        slider.stopAuto();
        slider.startAuto();
    });

});