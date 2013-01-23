function createSocialView() {

    $(".main-title").text("Social Networking");

    var defaultGauge = {

        pointer: {
            color: "#EF8549",
            shape: "arrow"
        },

        scale: {
            majorUnit: 10,
            minorUnit: 5,
            startAngle: -30,
            endAngle: 210,
            labels: {
                color: "#fff"
            },
            majorTicks: {
                color: "#fff"
            }
        }
    },

    radialGauge = $.extend({}, defaultGauge, { pointer: {color:"#fff"}});


    $("#social-public-awareness-gauge").kendoRadialGauge(radialGauge);
    $("#social-new-owners-gauge").kendoLinearGauge(defaultGauge);
    $("#social-facebook-linear-gauge").kendoLinearGauge(defaultGauge);
    $("#social-twitter-linear-gauge").kendoLinearGauge(defaultGauge);
    $("#social-gplus-linear-gauge").kendoLinearGauge(defaultGauge);
    $("#social-pinterest-linear-gauge").kendoLinearGauge(defaultGauge);

    createSocialChart();
};

function buildSocialStatsValueAxis() {
    var axis = [
        {
            title: { text: "sales" },
            name: "Sales",
            min: 100000,
            max: 3000000,
            labels: {
                format: "{0}",
                color: "#fff"
            },
            color: "#fff"
        }
    ];

    //facebook selected
    if ($('.facebook-tile').hasClass("social-tile-selected")) {
        axis.push({
            title: { text: "likes" },
            name: 'Likes',
            color: "#fff"
        });
    }

    //twitter selected
    if ($('.twitter-tile').hasClass("social-tile-selected")) {
        axis.push({
            title: { text: "tweets" },
            name: 'Tweets',
            color: "#fff"
        });
    }

    if ($('.pinterest-tile').hasClass("social-tile-selected")) {
        axis.push({
            title: { text: "pins" },
            name: 'Pins',
            color: "#fff"
        });
    }

    if ($('.google-tile').hasClass("social-tile-selected")) {
        axis.push({
            title: { text: "pluses" },
            name: 'Pluses',
            color: "#fff"
        });
    }

    return axis;
}

function buildSocialStatsSeries() {

    var series = [{
        type: "column",
        field: "Sales",
        name: "Sales",
        groupNameTemplate: "#= group.value # (#= series.name #)"
    }];

    if ($('.facebook-tile').hasClass("social-tile-selected")) {
        series.push({
            field: 'Likes',
            name: 'Likes',
            type: 'line',
            axis: 'Likes',
            color: "#4099FF"
        });
    }

    if ($('.twitter-tile').hasClass("social-tile-selected")) {
        series.push({
            field: 'Tweets',
            name: 'Tweets',
            type: 'line',
            axis: 'Tweets',
            color: "#3B5998"
        });
    }

    if ($('.pinterest-tile').hasClass("social-tile-selected")) {
        series.push({
            field: 'Pins',
            name: 'Pins',
            type: 'line',
            axis: 'Pins',
            color: "#f00"
        });
    }

    if ($('.google-tile').hasClass("social-tile-selected")) {
        series.push({
            field: 'Pluses',
            name: 'Pluses',
            type: 'line',
            axis: 'Pluses',
            color: "#d34836"
        });
    }

    return series;
}


function changeChartData() {

    var selected = $(this).data('selected'),
        $this = $(this),
        chart = $("#social-stats-chart").data('kendoChart');

    $this.data('selected', !selected);

    if (selected) {
        $(".social-tile-selected", $this).removeClass("social-tile-selected");
        $(".social-tile-title", $this).removeClass("social-tile-title-selected");
    } else {
        $(".social-tile", $this).addClass("social-tile-selected");
        $(".social-tile-title", $this).addClass("social-tile-title-selected");
    }

    chart.options.valueAxis = buildSocialStatsValueAxis();
    chart.options.series = buildSocialStatsSeries();
    chart.refresh();

}


var socialStatsDataSource = new kendo.data.DataSource({
    transport: {
        read: {
            url: "api/social/stats/",
            dataType: "json"
        }
    },
    sort: {
        field: "Date",
        dir: "asc"
    },
    schema: {
        model: {
            fields: {
                Date: {
                    type: "date"
                }
            }
        }
    }
});


function createSocialChart() {

    kendo.bind($('#social-view'), {});

    var socialAwarenessDataSource = new kendo.data.DataSource({
        transport: {
            read: 'api/social/awareness'
        },
        schema: {
            data: function (response) {
                //need to wrap this as an array for change event...
                return [response];
            }
        },
        change: function (data) {
            $('#social-public-awareness-gauge')
                .data("kendoRadialGauge")
                .value(data.items[0].Radial);

            $('#social-new-owners-gauge')
               .data("kendoLinearGauge")
               .value(data.items[0].Linear);
        }
    });

    var socialHeatDataSource = new kendo.data.DataSource({
        transport: {
            read: 'api/social/heat'
        },
        schema: {
            data: function (response) {
                return [response];
            }
        },
        change: function (data) {
            $('#social-facebook-linear-gauge')
                .data("kendoLinearGauge")
                .value(data.items[0].Facebook);

            $('#social-twitter-linear-gauge')
                .data("kendoLinearGauge")
                .value(data.items[0].Twitter);

            $('#social-gplus-linear-gauge')
                .data("kendoLinearGauge")
                .value(data.items[0].Google);

            $('#social-pinterest-linear-gauge')
                .data("kendoLinearGauge")
                .value(data.items[0].Pinterest);

        }
    });

    var topSongs = new kendo.data.DataSource({
        transport: {
            read: 'api/top/tracks'
        },
        change: function (result) {

            $('#top-songs-tabstrip').kendoTabStrip(
               {
                   dataSource: result.items,
                   autoBind: false,
                   dataTextField: "Name",
                   change: function () {
                       var selectedSong = result.items[this.select().index()];
                       socialHeatDataSource.read(
                           {
                               artistId: selectedSong.ArtistId,
                               songId: selectedSong.SongId
                           }
                       );
                   }
               }
           ).data('kendoTabStrip').select(0);
        }
    });

    //Need to clarify this with telerik...
    //If I do a normal bound Im not able to select the first element,
    //apparently a sync issue...
    var topArtists = new kendo.data.DataSource({
        transport: {
            read: 'api/top/artists'
        },
        change: function (result) {
            $('#top-artists-tabstrip').kendoTabStrip(
                {
                    dataSource: result.items,
                    autoBind: false,
                    dataTextField: "Name",
                    change: function () {
                        var id = result.items[this.select().index()].Id;
                        //re-fetch dependent datasource...
                        topSongs.read({ artistId: id });
                        socialStatsDataSource.read(
                            { artistId: id, from: "1/1/2012", to: "12/31/2012" });

                        socialAwarenessDataSource.read({ artistId: id });

                    }
                }
            ).data('kendoTabStrip').select(0);

            console.log($('#top-artists-tabstrip').data('kendoTabStrip'));
        }
    });
    topArtists.read();

    $('#social-stats-chart').kendoChart({

        title: {
            text: "Social Stats",
            color: "#EF8549",
            font: "30px Arial,Helvetica,sans-serif"
        },
        dataSource: socialStatsDataSource,
        autoBind: false,
        series: buildSocialStatsSeries(),
        legend: {
            position: "bottom",
            labels: {
                color: "#fff"
            }
        },
        valueAxis: buildSocialStatsValueAxis(),
        categoryAxis: {
            field: "Date",
            labels: {
                format: "MMM",
                color: "#fff"
            },
            axisCrossingValue: [0, 0, 100, 200, 300, 400]

        },
        chartArea: {
            background: ""
        },
    });


    $(window).on("resize orientationchange", function (e) {
        $("#social-stats-chart").data("kendoChart").redraw();
    });

    $(".social-tile-wrapper").click(function (e) {

        changeChartData.call(this);

    });

};

