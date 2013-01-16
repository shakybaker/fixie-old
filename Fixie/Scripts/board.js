//signalr
var hub = $.connection.boardHub;
hub.client.broadcastActivity = function (message) {
    var now = new Date();
    var date = fixie.toISOString(now);
    $('#activity-log').prepend("<li><a href='#'><img class='mid-user-thumb' src='/Images/user1.png' /></a><span class='msg'>" + message + "<br /><span class='pd' title='" + date + "'>just now</span></span></li>");
};
hub.client.moveCard = function (data) {
//TODO: move card
};
$.connection.hub.start();

var board = {

    init: function () {
        this.sizeDivs();
        this.addcardControls();
        //$(".cards-viewport").mCustomScrollbar();
        
        $(window).resize(function () {
            board.sizeDivs();
        });
        
        //toggle simple/detailed card view
        $('.detail-trigger').toggle(function () {
            $('.card-container').addClass('simple');
            $(this).html('DETAILED VIEW');
        }, function () {
            $('.card-container').removeClass('simple');
            $(this).html('SIMPLE VIEW');
        });

        $(".view-card").click(function () { alert($(this).attr("datacardid"));});
    },

    sizeDivs: function () {
        //TODO: cater for responsive design here
        $('.lane').height(
            $(window).height() - 150
        );
        $('.card-viewport').height(
            $(window).height() - 80
        );
        $('.cards-viewport').height(
            $(window).height() - 200
        );
    },

    addcardControls: function () {
        $(".card").mousedown(function () {
            $(this).addClass("select-card");
        });
        $(".card").mouseup(function () {
            $(this).removeClass("select-card");
        });
    },

    countCards: function () {
        $('.lane').each(function () {
            var cnt = $(this).find('li.card').length;
            var counter = $(this).find('.card-counter span.count');
            counter.removeClass('warn');
            counter.removeClass('none');
            if (cnt > 3) {
                counter.addClass('warn');
            }
            if (cnt < 1) {
                counter.addClass('none');
            }
            counter.html(cnt + ((cnt == 1) ? ' CARD' : ' CARDS'));
        });
    }

};
