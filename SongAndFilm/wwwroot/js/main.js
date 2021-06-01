/*js for menu*/

$(document).ready(function () {
  $(".navbar-xbootstrap").click(function () {
    $(".nav-xbootstrap").toggleClass("visible");
  });
});
/*js for animation at the icon menu*/
$(document).ready(function () {
  $(".navbar-xbootstrap").click(function () {
    $(".span1").toggleClass("rotateRight");
    $(".span2").toggleClass("transparent");
    $(".span3").toggleClass("rotateLeft");
  });
});

/*js for load more*/
$(document).ready(function () {
  $(".moreBox").slice(0, 3).show();
  if ($(".blogBox:hidden").length != 0) {
    $("#loadMore").show();
  }
  $("#loadMore").on("click", function (e) {
    e.preventDefault();
    $(".moreBox:hidden").slice(0, 6).slideDown();
    if ($(".moreBox:hidden").length == 0) {
      $("#loadMore").fadeOut("slow");
    }
  });
});

