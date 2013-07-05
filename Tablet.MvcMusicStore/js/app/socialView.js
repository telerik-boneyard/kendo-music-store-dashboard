(function ($, kendo, musicDashboard, undefined) {
    musicDashboard.socialViewLogic = {
        socialStatsDataSource: undefined,

        createSocialView: function () {

            musicDashboard.socialView.render("#main");

            $(".main-title").text("Social Networking");

            var that = this,
                defaultGauge = {

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

            radialGauge = $.extend({}, defaultGauge, { pointer: { color: "#fff" } });

            $("#social-public-awareness-gauge").kendoRadialGauge(radialGauge);
            $("#social-new-owners-gauge").kendoLinearGauge(defaultGauge);
            $("#social-facebook-linear-gauge").kendoLinearGauge(defaultGauge);
            $("#social-twitter-linear-gauge").kendoLinearGauge(defaultGauge);
            $("#social-gplus-linear-gauge").kendoLinearGauge(defaultGauge);
            $("#social-pinterest-linear-gauge").kendoLinearGauge(defaultGauge);

            this.createSocialChart();
        },

        buildSocialStatsValueAxis: function () {

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
        },

        buildSocialStatsSeries: function () {

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
        },

        changeChartData: function (that) {

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

            chart.options.valueAxis = that.buildSocialStatsValueAxis();
            chart.options.series = that.buildSocialStatsSeries();
            chart.refresh();

        },

        createSocialChart: function () {

            var that = this,
                socialAwarenessDataSource = new kendo.data.DataSource({
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
                }),
                $socialSalesChart = $("#social-stats-chart"),
                chart,
                topArtists = new kendo.data.DataSource({
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

                                    var id = result.items[this.select().index()].Id,
                                        initSocial = $(".social-tile-wrapper[data-selected=true]");
                                    //re-fetch dependent datasource...
                                    topSongs.read({ artistId: id });

                                    $(".social-tile-selected").removeClass("social-tile-selected");
                                    $(".social-tile-title").removeClass("social-tile-title-selected");

                                    $(".social-tile", initSocial).addClass("social-tile-selected");
                                    $(".social-tile-title", initSocial).addClass("social-tile-title-selected");

                                    that.socialStatsDataSource.read({ artistId: id });
                                    socialAwarenessDataSource.read({ artistId: id });

                                }
                            }
                        ).data('kendoTabStrip').select(0);
                    }
                }),
                socialHeatDataSource = new kendo.data.DataSource({
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
                }),
                topSongs = new kendo.data.DataSource({
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

            that.socialStatsDataSource = new kendo.data.DataSource({
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

            kendo.bind($('#social-view'), {});

            topArtists.read();

            $socialSalesChart.kendoChart({

                title: {
                    text: "Social Stats",
                    color: "#EF8549",
                    font: "30px Arial,Helvetica,sans-serif"
                },
                dataSource: that.socialStatsDataSource,
                series: that.buildSocialStatsSeries(),
                legend: {
                    position: "bottom",
                    labels: {
                        color: "#fff"
                    }
                },
                valueAxis: that.buildSocialStatsValueAxis(),
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
                autoBind: false
            });

            $(".social-tile-wrapper").click(function (e) {

                that.changeChartData.call(this, that);

            });

        }
    };
}(window.jQuery, window.kendo, window.musicDashboard));
