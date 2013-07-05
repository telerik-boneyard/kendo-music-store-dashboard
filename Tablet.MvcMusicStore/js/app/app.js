;

"use strict";

(function (window, undefined) {

    var musicDashboard = {

        //kendoui router object
        router: undefined,

        //Default settings for gauges
        defaultGaugeMin: 100,
        defaultGaugeMax: 400,
        valueInterval: undefined,

        setup: function () {

            this.router = new kendo.Router();

            this.setupViews();
            this.setupRoutes();            

            this.router.start();

        },

        //define vars to Hold Views for SPA mgt
        mainView: undefined,
        salesView: undefined,
        socialView: undefined,

        //define views for KendoUI
        setupViews: function () {

            var that = this,
                sv = document.querySelector("#salesview"),
                socv = document.querySelector("#socialView"),
                mv = document.querySelector("#mainview");

            //outerHTML
            that.salesView = new kendo.View(sv.outerHTML);
            that.socialView = new kendo.View(socv.outerHTML);
            that.mainView = new kendo.View(mv.outerHTML);

        },

        //defined Routes for KendoUI
        setupRoutes: function () {

            var that = this;

            if (that.router) {

                that.router.route("/", function () {


                    //destroy other views or they will be markup artifacts on the screen
                    that.salesView.destroy();
                    that.socialView.destroy();
                    
                    $(".main-nav-item-selected").removeClass("main-nav-item-selected");
                    $(".main-nav-item-icon-selected").removeClass("main-nav-item-icon-selected");
                    $(".nav-music-icon").addClass("main-nav-item-icon-selected");
                    $(".nav-music").addClass("main-nav-item-selected");

                    that.createMainView();

                });

                that.router.route("/sales", function () {

                    that.mainView.destroy();
                    that.socialView.destroy();

                    //destroy the main view gauge update callback interval
                    clearInterval(that.valueInterval);

                    $(".main-nav-item-selected").removeClass("main-nav-item-selected");
                    $(".main-nav-item-icon-selected").removeClass("main-nav-item-icon-selected");
                    $(".nav-sales-icon").addClass("main-nav-item-icon-selected");
                    $(".nav-sales").addClass("main-nav-item-selected");

                    that.createSalesView();

                });

                that.router.route("/social", function () {

                    that.mainView.destroy();
                    that.salesView.destroy();

                    clearInterval(that.valueInterval);

                    $(".main-nav-item-selected").removeClass("main-nav-item-selected");
                    $(".main-nav-item-icon-selected").removeClass("main-nav-item-icon-selected");
                    $(".nav-social-icon").addClass("main-nav-item-icon-selected");
                    $(".nav-social").addClass("main-nav-item-selected");

                    that.createSocialView();

                });

            }

        },


        //Main View Members

        createMainView: function () {
            var that = this;

            that.mainView.render("#main");

            $(".main-title").text("Music Store Sales");

            this.displayMainViewTotals();
            that.displayTopSingles();
            that.displayTopAlbums();
            that.CreateGauges();

            if (!that.valueInterval) {
                that.valueInterval = setInterval(function () {

                    that.UpdateGauges.call(that);

                }, 5000);
            }
        },

        displayMainViewTotals: function () {

            var item,
                totals = new kendo.data.DataSource({
                transport: {
                    read: 'api/sales/totals'
                },
                schema: {
                    data: function (response) {
                           item = {
                                today: kendo.toString(response.Today, "c"),
                                week: kendo.toString(response.Week, "c"),
                                month: kendo.toString(response.Month, "c"),
                                lastMonth: kendo.toString(response.LastMonth, "c")
                            };
                            return [item];
                        }
                },
                change: function (data) {
                    kendo.bind($("#home-view"), data.items[0]);
                }
            });
            totals.read();
        },

        displayTopSingles: function () {

            var dataSource = new kendo.data.DataSource({
                                    transport: {
                                        read: {
                                            url: "api/top/tracks",
                                            dataType: "json"
                                        }
                                    }
                                }),
                template = kendo.template($("#top-single-template").html());

            $("#topSinglesListView").kendoListView({
                dataSource: dataSource,
                template: template,
                dataBound: function (e) {
                    // handle event
                    $(".top-single-song-list-item").on("click", function (e) {

                        e.preventDefault();

                        window.location = "#/sales?target=singles";

                    });

                }

            });

        },

        displayTopAlbums: function () {

            var dataSource = new kendo.data.DataSource({
                transport: {
                    read: {
                        url: "api/top/albums",
                        dataType: "json"
                    }

                }
            });

            $("#topAlbumsListView").kendoListView({
                dataSource: dataSource,
                template: kendo.template($("#top-album-template").html()),
                dataBound: function (e) {
                    // handle event
                    $(".top-album-list-item").on("click", function (e) {

                        e.preventDefault();

                        window.location = "#/sales?target=album";

                    });

                }


            });
        },

        CreateGauges: function () {

            this.CreateGauge(".albums-per-hour", parseInt(Math.floor((Math.random() * this.defaultGaugeMax) + 1), 10));
            this.CreateGauge(".singles-per-hour", parseInt(Math.floor((Math.random() * this.defaultGaugeMax) + 1), 10));
            this.CreateGauge(".new-customers-per-hour", parseInt(Math.floor((Math.random() * this.defaultGaugeMax) + 1), 10));
            this.CreateGauge(".visitors-per-hour", parseInt(Math.floor((Math.random() * this.defaultGaugeMax) + 1), 10));
        },

        CreateGauge: function (selector, value, min, max) {

            if (!selector || selector === "") {
                return;
            }

            value = value || 0;
            min = min || this.defaultGaugeMin;
            max = max || this.defaultGaugeMax;

            $(selector).kendoRadialGauge({

                pointer: {
                    value: value,
                    color: "#fff"
                },

                scale: {
                    majorUnit: 40,
                    minorUnit: 20,
                    startAngle: -30,
                    endAngle: 210,
                    labels: {
                        color: "#fff"
                    },
                    majorTicks: {
                        color: "#fff"
                    },
                    max: this.defaultGaugeMax,
                    min: this.defaultGaugeMin,
                    ranges: [
                        {
                            from: 100,
                            to: 150,
                            color: "#3366ff"
                        }, {
                            from: 150,
                            to: 200,
                            color: "#336699"
                        }, {
                            from: 200,
                            to: 250,
                            color: "#ffc700"
                        }, {
                            from: 250,
                            to: 300,
                            color: "#ff7a00"
                        }, {
                            from: 300,
                            to: 350,
                            color: "#c20000"
                        }
                    ]
                }
            });

        },

        UpdateGauges: function () {
            //fetch new gauge data

            var that = this,
                gaugeValueDataSource = new kendo.data.DataSource({
                transport: {
                    read: 'api/sales/gauges'
                },
                schema: {
                    data: function (response) {
                        return [response];
                    }
                },
                change: function (data) {
                    that.ApplyGaugeDelta('.albums-per-hour', data.items[0].Albums);
                    that.ApplyGaugeDelta('.singles-per-hour', data.items[0].Singles);
                    that.ApplyGaugeDelta('.new-customers-per-hour', data.items[0].Customers);
                    that.ApplyGaugeDelta('.visitors-per-hour', data.items[0].Visitors);
                }
            });

            gaugeValueDataSource.read();
        },

        ApplyGaugeDelta: function (selector, delta) {

            var gauge = $(selector).data('kendoRadialGauge'),
                value = 0;

            if (gauge) {

                value = gauge.value();

                gauge.value(value + delta);

            } else {
                clearInterval(this.valueInterval);
            }

        },


        //Sales Members


        //sales variables
        salesPeriod: 60,
        salesGenrePeriod: 'weekly',
        searchesGenrePeriod: 7,
        salesChartType: "line",
        totalSalesUrl: "api/sales/TotalSales/" + this.salesPeriod,
        albumSales: "api/sales/AlbumSales/" + this.salesPeriod,
        singleSales: "api/sales/SingleSales/" + this.salesPeriod,
        totalDownloads: "api/sales/TotalDownloads/" + this.salesPeriod,
        ticketSales: "api/sales/TicketSales/" + this.salesPeriod,

        setupSalesUrls: function () {

            this.totalSalesUrl = "api/sales/TotalSales/" + this.salesPeriod;
            this.albumSales = "api/sales/AlbumSales/" + this.salesPeriod;
            this.singleSales = "api/sales/SingleSales/" + this.salesPeriod;
            this.totalDownloads = "api/sales/TotalDownloads/" + this.salesPeriod;
            this.ticketSales = "api/sales/TicketSales/" + this.salesPeriod;

        },

        //sales methods

        salesByGenreChartDataSource: undefined,
        searchesByGenreChartDataSource: undefined,

        setSalesChart: function (options) {

            options = $.extend({}, {

                title: {
                    text: "Store Sales",
                    color: "#EF8549"
                    , "font": "30px Arial,Helvetica,sans-serif"
                },
                dataSource: {
                    transport: {
                        read: {
                            url: this.totalSalesUrl,
                            dataType: "json"
                        }
                    },

                    group: {
                        field: "Genre"
                    },

                    sort: {
                        field: "Date",
                        dir: "asc"
                    }

                },
                dateField: "Date",
                series: [{
                    type: "column", //salesChartType,
                    field: "Sales"
                }],
                navigator: {
                    series: {
                        type: "area",
                        field: "Sales"
                    },
                    xAxis: {
                        color: "#fff"
                    },
                    categoryAxis: [
                        {
                            labels: {
                                color: "#fff"
                            }
                        }
                    ]
                },
                valueAxis: {
                    color: "#fff"
                },

                categoryAxis: [
                    {
                        field: "Date",
                        labels: {
                            color: "#fff"
                        },
                        type: "date"
                    }
                ],

                chartArea: {
                    background: ""
                },

                tooltip: {
                    visible: false,
                    background: "transparent",
                    border: {
                        width: 0
                    },
                    template: kendo.template($("#salesToolTip").html())
                }

            }, options);

            $(".store-sales-chart").kendoStockChart(options);

        },

        setSalesByGenreChart: function () {

            var options = {
                title: {
                    text: "Sales By Genre",
                    color: "#EF8549"
                },

                dataSource: this.salesByGenreChartDataSource,
                series: [{
                    type: "column",
                    field: "Sales",
                    name: "Sales",
                    groupNameTemplate: "#= group.value #"
                }],
                valueAxis: {
                    color: "#fff",
                    labels: {
                        format: "C"
                    }
                },
                categoryAxis: {
                    field: "Date",
                    color: "#fff",
                    labels: {
                        format: "MMM dd",
                        step: 1
                    }
                },
                chartArea: {
                    background: ""
                },
                tooltip: {
                    visible: true,
                    background: "transparent",
                    border: {
                        width: 0
                    },
                    template: kendo.template($("#genreSalesToolTipTemplate").html())
                }
                 , legend: {
                     position: "bottom",
                     labels: {
                         color: "#fff"
                     }
                 }
            };

            $(".sales-by-genre-chart").kendoChart(options);
        },

        setSearchesByGenreChart: function () {

            var options = {
                title: {
                    text: "Searches By Genre",
                    color: "#EF8549"
                },

                dataSource: this.searchesByGenreChartDataSource,

                chartArea: {
                    background: ""
                },

                series: [{
                    type: "column",
                    field: "Searches",
                    name: "Searches",
                    groupNameTemplate: "#= group.value #"
                }],

                valueAxis: {
                    color: "#fff"
                },

                categoryAxis: [
                    {
                        field: "Date",
                        color: '#FFF',
                        labels: {
                            format: "MMM dd",
                            step: 1
                        },
                        type: "date"
                    }
                ],

                tooltip: {
                    visible: true,
                    background: "transparent",
                    border: {
                        width: 0
                    },
                    template: kendo.template($("#genreSearchesToolTipTemplate").html())
                },

                legend: {
                    position: "bottom",
                    labels: {
                        color: "#fff"
                    }

                }
            };

            $(".searches-by-genre-chart").kendoChart(options);

        },

        parseQuerystring: function () {

            var qs = window.location.hash.split('?');

            if (qs.length > 1) {

                var foo = qs[1].split('&'),
                    dict = {},
                    elem = [],
                    i = 0;

                for (i = foo.length - 1; i >= 0; i--) {
                    elem = foo[i].split('=');
                    dict[elem[0]] = elem[1];
                }

                return dict;

            }

            return "";
        },

        getLabelOptions: function (period) {

            if (period == 'monthly')
                return {
                    format: "dd",
                    step: 2,
                    color: '#FFF'
                };

            if (period == 'yearly')
                return {
                    format: "MMM",
                    step: 1,
                    color: '#FFF'
                };
            return {
                format: "MMM dd",
                step: 1,
                color: '#FFF'
            };
        },

        updateSalesChartData: function (saleUrl, title, that) {

            $(".sales-chart-options-item-selected").removeClass("sales-chart-options-item-selected");
            $(this).addClass("sales-chart-options-item-selected");

            that.setSalesChart({
                title: {
                    text: title || "Store Sales",
                    color: "#fff"
                , "font": "30px Arial,Helvetica,sans-serif"
                },
                dataSource: {
                    transport: {
                        read: {
                            url: saleUrl,
                            dataType: "json"
                        }
                    }
                }
            });

        },

        removeSelectedGenreSalesType: function (parentWrapper) {

            $(".chart-type-area-selected," +
                ".chart-type-line-selected," +
                ".chart-type-stacked-bar-selected," +
                ".chart-type-column-selected," +
                ".chart-type-pie-selected," +
                ".chart-type-bar-selected," +
                ".chart-type-bubble-selected," +
                ".chart-type-doughnut-selected," +
                ".chart-type-scatter-selected",
                    parentWrapper)
                .removeClass("chart-type-area-selected")
                .removeClass("chart-type-line-selected")
                .removeClass("chart-type-column-selected")
                .removeClass("chart-type-bar-selected")
                .removeClass("chart-type-pie-selected")
                .removeClass("chart-type-bubble-selected")
                .removeClass("chart-type-doughnut-selected")
                .removeClass("chart-type-scatter-selected")
                .removeClass("chart-type-stacked-bar-selected");

        },

        changeChartType: function (chartSelector, parentChartType, that) {

            that.removeSelectedGenreSalesType(parentChartType);

            var $this = $(this),
                chartType = $this.data("charttype"),
                chart = $(chartSelector).data("kendoChart"),
                colors = ["#808600", "#cc5300", "#cc7100"],
                i = 0;

            $this.addClass("chart-type-" + chartType + "-selected");

            for (i = 0; i < chart.options.series.length; i++) {

                if (chartType !== "stacked-bar") {
                    chart.options.series[i].type = chartType;
                    chart.options.series[i].stack = false;
                } else {
                    chart.options.series[i].type = "bar";
                    chart.options.series[i].stack = true;
                }

                chart.options.series[i].color = colors[i];
                chart.options.series[i].opacity = 1;

            }

            chart.redraw();

        },

        createSalesView: function () {

            var that = this,
                get_vars = that.parseQuerystring();

            this.setupSalesUrls();

            that.salesByGenreChartDataSource = new kendo.data.DataSource({
                transport: {
                    read: {
                        url: "api/salesbygenre/" + that.salesGenrePeriod,
                        dataType: "json"
                    }
                },
                group: { field: "Genre" },
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

            that.searchesByGenreChartDataSource = new kendo.data.DataSource({
                transport: {
                    read: {
                        url: "api/searchesbygenre/" + that.salesGenrePeriod,
                        dataType: "json"
                    }
                },
                group: { field: "Genre" },
                sort: {
                    field: "Date",
                    dir: "asc"
                },
                schema: {
                    model: {
                        fields: {
                            Date: {
                                type: "date"
                            },
                            Genre: {type: "string"}
                        }
                    }
                }
            });

            that.salesView.render("#main");

            if (get_vars["target"] === "album") {

                that.albumSales = "api/sales/AlbumSales/" + that.salesPeriod;

                that.updateSalesChartData.call(document.querySelector(".sales-chart-options-albums"),
                        that.albumSales, "Store Album Sales", that);

            } else if (get_vars["target"] === "singles") {

                that.singleSales = "api/sales/SingleSales/" + that.salesPeriod;

                that.updateSalesChartData.call(document.querySelector(".sales-chart-options-singles"),
                        that.singleSales, "Store Single Sales", that);

            } else {
                that.setSalesChart();
            }

            $(".main-title").text("Store Sales Overview");

            that.setSalesByGenreChart();
            that.setSearchesByGenreChart();

            $(".genre-sales-tab").click(function (e) {

                var $this = $(this);

                if ($this.hasClass("time-sales-tab-selected")) {
                    return;
                }

                $(".time-sales-tab", "#sales-by-genre").removeClass("time-sales-tab-selected");

                var period = $this.data('period');

                $this.addClass("time-sales-tab-selected");

                that.salesByGenreChartDataSource
                    .options.transport.read.url = "api/salesbygenre/" + period;

                $('.sales-by-genre-chart')
                    .data('kendoChart')
                    .options.categoryAxis.labels = that.getLabelOptions(period);

                that.salesByGenreChartDataSource.read();
            });

            $(".genre-searches-tab").click(function (e) {

                var $this = $(this);

                if ($this.hasClass("time-sales-tab-selected")) {
                    return;
                }

                $(".time-sales-tab", "#searches-by-genre").removeClass("time-sales-tab-selected");

                var period = $this.data('period');

                $this.addClass("time-sales-tab-selected");

                that.searchesByGenreChartDataSource
                    .options.transport.read.url = "api/searchesbygenre/" + period;

                $('.searches-by-genre-chart')
                    .data('kendoChart')
                    .options.categoryAxis.labels = that.getLabelOptions(period);

                that.searchesByGenreChartDataSource.read();

            });

            $(".sales-chart-options-albums").click(function (e) {

                e.preventDefault();

                that.albumSales = "api/sales/AlbumSales/" + that.salesPeriod;

                that.updateSalesChartData.call(this, that.albumSales, "Store Album Sales", that);

            });

            $(".sales-chart-options-singles").click(function (e) {

                e.preventDefault();

                that.singleSales = "api/sales/SingleSales/" + that.salesPeriod;

                that.updateSalesChartData.call(this, that.singleSales, "Store Single Sales", that);

            });

            $(".sales-chart-options-sales").click(function (e) {

                e.preventDefault();

                that.totalSalesUrl = "api/sales/TotalSales/" + that.salesPeriod;

                that.updateSalesChartData.call(this, that.totalSalesUrl, "Store Total Sales", that);

            });

            $(".sales-chart-options-downloads").click(function (e) {

                e.preventDefault();

                that.totalDownloads = "api/sales/TotalDownloads/" + that.salesPeriod;

                that.updateSalesChartData.call(this, that.totalDownloads, "Store Downloads", that);

            });

            $(".sales-chart-options-tickets").click(function (e) {

                e.preventDefault();

                that.ticketSales = "api/sales/TicketSales/" + that.salesPeriod;

                that.updateSalesChartData.call(this, that.ticketSales, "Store Ticket Sales", that);

            });

            $(".chart-type-item", ".change-genre-sales-chart-type").click(function (e) {

                e.preventDefault();

                that.changeChartType.call(this, ".sales-by-genre-chart", ".change-genre-sales-chart-type", that);

            });

            $(".chart-type-item", ".genre-searches-chart-type").click(function (e) {

                e.preventDefault();

                that.changeChartType.call(this, ".searches-by-genre-chart", ".genre-searches-chart-type", that);

            });

            $(window).on("resize orientationchange", function (e) {
                $(".k-chart:not(.k-stockchart)").each(function () { $(this).data("kendoChart").redraw(); });
                $(".k-stockchart").each(function () { $(this).data("kendoStockChart").redraw(); });
            });

        },


        //Social Members

        socialStatsDataSource: undefined,


        createSocialView: function () {

            this.socialView.render("#main");

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
                dataSource:  that.socialStatsDataSource,
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

            $(window).on("resize orientationchange", function (e) {
                $socialSalesChart.data("kendoChart").redraw();
            });

            $(".social-tile-wrapper").click(function (e) {

                that.changeChartData.call(this, that);

            });

        }

    };


    return (window.musicDashboard = musicDashboard);

}(window));


$(document).data("kendoSkin", "uniform");

musicDashboard.setup();


