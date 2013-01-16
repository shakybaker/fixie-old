

function padzero(n) {
    return n < 10 ? '0' + n : n;
}
function pad2zeros(n) {
    if (n < 100) { n = '0' + n; }
    if (n < 10) { n = '0' + n; }
    return n;     
}

var fixie = {

    init: function () {
        this.setupMenus();
        this.prettyDates();
    },

    toISOString: function(d) {
        return d.getUTCFullYear() + '-' +  padzero(d.getUTCMonth() + 1) + '-' + padzero(d.getUTCDate()) + 'T' + padzero(d.getUTCHours()) + ':' +  padzero(d.getUTCMinutes()) + ':' + padzero(d.getUTCSeconds()) + '.' + pad2zeros(d.getUTCMilliseconds()) + 'Z';
    },

    showModal: function () {
        $("#panel").removeClass("info-panel-on");
        $('#info-panel').css('right', '-20%');
        $('#menu').hide();
        $("#panel").removeClass("menu-on");
        $("#panel").addClass("modal-on");
        $("#modal-overlay").show();
        $("#modal-wrap").show();
    },

    hideModal: function () {
        $("#panel").removeClass("modal-on");
        $("#modal-overlay").hide();
        $("#modal-wrap").hide();
    },

    setupMenus: function () {
        $('#menu').hide();
        //$('#info-panel').hide();

        $('.menu-trigger').toggle(function () {
            $('#menu').show();

            $('#panel').animate({
                left: '250'
            }, 100, function () {
                // Animation complete.
            });

            $('#panel').addClass('menu-on');
        }, function () {
            $('#panel').animate({
                left: '0'
            }, 100, function () {
                $('#menu').hide();
                $('#panel').removeClass('menu-on');
            });

        });

        $('.menu-snap').toggle(function () {
            $('#menu').hide();
            $('#panel').removeClass('menu-on');
            $('#panel').removeClass('info-panel-on');
            $('#info-panel').css('right', '-20%');
        }, function () {
            $('#panel').addClass('info-panel-on');
            $('#info-panel').css('right', '0');
        });
    },

    prettyDates: function () {

        $(".pd").timeago();//TODO: make more performant
        setInterval(function () { $(".pd").timeago(); }, 5000);
    }

};
