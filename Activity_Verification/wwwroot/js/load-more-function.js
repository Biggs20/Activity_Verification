$(document).ready(function () {

    var pagelength = 10;
    var pageIndex = 1;

    var selector = "tr:gt(" + pagelength + ")";
    $(selector).hide();

    $("#loadMore").click(function () {
        var itemsCount = ((pageIndex * pagelength) + pagelength);
        var selector = "tr:lt(" + itemsCount + ")";
        $(selector).show();
        pageIndex++;
    });

});