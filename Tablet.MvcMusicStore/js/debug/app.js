;

"use strict";

(function (window, undefined) {

    var musicDashboard = {

        router: undefined,
        defaultGaugeMin: 100,
        defaultGaugeMax: 400,
        valueInterval: undefined,


        setup: function () {

            this.router = new kendo.Router();

            this.setupRoutes();
            this.bindNavigation();

            this.router.start();


        },

        setupRoutes: function () {

            if (this.router) {

                this.router.route("/", function () {
                    console.log("home");

                    $(".main-nav-item-selected").removeClass("main-nav-item-selected");
                    $(".main-nav-item-icon-selected").removeClass("main-nav-item-icon-selected");
                    $(".nav-music-icon").addClass("main-nav-item-icon-selected");
                    $(".nav-music").addClass("main-nav-item-selected");
                });

                this.router.route("/sales", function () {
                    console.log("sales");

                    $(".main-nav-item-selected").removeClass("main-nav-item-selected");
                    $(".main-nav-item-icon-selected").removeClass("main-nav-item-icon-selected");
                    $(".nav-sales-icon").addClass("main-nav-item-icon-selected");
                    $(".nav-sales").addClass("main-nav-item-selected");
                });

                this.router.route("/social", function () {
                    console.log("social");

                    $(".main-nav-item-selected").removeClass("main-nav-item-selected");
                    $(".main-nav-item-icon-selected").removeClass("main-nav-item-icon-selected");
                    $(".nav-social-icon").addClass("main-nav-item-icon-selected");
                    $(".nav-social").addClass("main-nav-item-selected");
                });

            }

        },

        bindNavigation: function () {

            if (this.router) {

                $(".social-album, .nav-social").click(function (e) {
                    e.preventDefault();
                    e.stopPropagation();

                    //        clearInterval(valueInterval);
                    router.navigate("/social");

                });

                $(".charts-album, .nav-music").click(function (e) {
                    e.preventDefault();
                    e.stopPropagation();

                    router.navigate("/sales");

                });

                $("#main-header, .main-header-pennant").click(function (e) {
                    e.preventDefault();
                    e.stopPropagation();
                    router.navigate("/");

                });

            }

        },


        //Main View Members

        createMainView: function () {

            $(".main-title").text("Music Store Sales");

            this.displayMainViewTotals();
            this.displayTopSingles();
            this.displayTopAlbums();
            this.CreateGauges();

            this.valueInterval = setInterval(this.UpdateGauges, 5000);

        },

        displayMainViewTotals: function () {

            var totals = new kendo.data.DataSource({
                transport: {
                    read: 'api/sales/totals'
                },
                schema: {
                    data: function (response) {
                        var item = {
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
            });

            $("#topSinglesListView").kendoListView({
                dataSource: dataSource,
                template: kendo.template($("#top-single-template").html()),
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

            CreateGauge(".albums-per-hour", parseInt(Math.floor((Math.random() * defaultGaugeMax) + 1), 10));
            CreateGauge(".singles-per-hour", parseInt(Math.floor((Math.random() * defaultGaugeMax) + 1), 10));
            CreateGauge(".new-customers-per-hour", parseInt(Math.floor((Math.random() * defaultGaugeMax) + 1), 10));
            CreateGauge(".visitors-per-hour", parseInt(Math.floor((Math.random() * defaultGaugeMax) + 1), 10));
        },

        CreateGauge: function (selector, value, min, max) {

            if (!selector || selector === "") {
                return;
            }

            value = value || 0;
            min = min || defaultGaugeMin;
            max = max || defaultGaugeMax;

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
                    max: defaultGaugeMax,
                    min: defaultGaugeMin,
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

            var gaugeValueDataSource = new kendo.data.DataSource({
                transport: {
                    read: 'api/sales/gauges'
                },
                schema: {
                    data: function (response) {
                        return [response];
                    }
                },
                change: function (data) {
                    ApplyGaugeDelta('.albums-per-hour', data.items[0].Albums);
                    ApplyGaugeDelta('.singles-per-hour', data.items[0].Singles);
                    ApplyGaugeDelta('.new-customers-per-hour', data.items[0].Customers);
                    ApplyGaugeDelta('.visitors-per-hour', data.items[0].Visitors);
                }
            });

            this.gaugeValueDataSource.read();
        },

        ApplyGaugeDelta: function (selector, delta) {

            var gauge = $(selector).data('kendoRadialGauge'),
                value = 0;

            if (gauge) {

                value = gauge.value();

                gauge.value(value + delta);

            } else {
                clearInterval(valueInterval);
            }

        },


        //Sales Members


        //sales variables
        salesPeriod: 60,
        salesGenrePeriod: 'weekly',
        searchesGenrePeriod: 7,
        salesChartType: "line",
        totalSalesUrl: "api/sales/TotalSales/" + salesPeriod,
        albumSales: "api/sales/AlbumSales/" + salesPeriod,
        singleSales: "api/sales/SingleSales/" + salesPeriod,
        totalDownloads: "api/sales/TotalDownloads/" + salesPeriod,
        ticketSales: "api/sales/TicketSales/" + salesPeriod,

        //sales methods
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

        updateSalesChartData: function (saleUrl, title) {

            $(".sales-chart-options-item-selected").removeClass("sales-chart-options-item-selected");
            $(this).addClass("sales-chart-options-item-selected");

            setSalesChart({
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

        changeChartType: function (chartSelector, parentChartType) {

            this.removeSelectedGenreSalesType(parentChartType);

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

            if (get_vars["target"] === "album") {

                that.albumSales = "api/sales/AlbumSales/" + that.salesPeriod;

                that.updateSalesChartData.call(document.querySelector(".sales-chart-options-albums"),
                        that.albumSales, "Store Album Sales");

            } else if (get_vars["target"] === "singles") {

                that.singleSales = "api/sales/SingleSales/" + that.salesPeriod;

                that.updateSalesChartData.call(document.querySelector(".sales-chart-options-singles"),
                        that.singleSales, "Store Single Sales");

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

                that.updateSalesChartData.call(this, that.albumSales, "Store Album Sales");

            });

            $(".sales-chart-options-singles").click(function (e) {

                e.preventDefault();

                that.singleSales = "api/sales/SingleSales/" + that.salesPeriod;

                that.updateSalesChartData.call(this, that.singleSales, "Store Single Sales");

            });

            $(".sales-chart-options-sales").click(function (e) {

                e.preventDefault();

                that.totalSalesUrl = "api/sales/TotalSales/" + that.salesPeriod;

                that.updateSalesChartData.call(this, that.totalSalesUrl, "Store Total Sales");

            });

            $(".sales-chart-options-downloads").click(function (e) {

                e.preventDefault();

                that.totalDownloads = "api/sales/TotalDownloads/" + that.salesPeriod;

                that.updateSalesChartData.call(this, that.totalDownloads, "Store Downloads");

            });

            $(".sales-chart-options-tickets").click(function (e) {

                e.preventDefault();

                that.ticketSales = "api/sales/TicketSales/" + that.salesPeriod;

                that.updateSalesChartData.call(this, that.ticketSales, "Store Ticket Sales");

            });

            $(".chart-type-item", ".change-genre-sales-chart-type").click(function (e) {

                e.preventDefault();

                that.changeChartType.call(this, ".sales-by-genre-chart", ".change-genre-sales-chart-type");

            });

            $(".chart-type-item", ".genre-searches-chart-type").click(function (e) {

                e.preventDefault();

                that.changeChartType.call(this, ".searches-by-genre-chart", ".genre-searches-chart-type");

            });

            $(window).on("resize orientationchange", function (e) {
                $(".sales-by-genre-chart").data("kendoChart").redraw();
                $(".searches-by-genre-chart").data("kendoChart").redraw();
                $(".store-sales-chart").data("kendoStockChart").redraw();
            });

        }

    };





    return (window.musicDashboard = musicDashboard);

}(window));


$(document).data("kendoSkin", "uniform");

musicDashboard.setup();




