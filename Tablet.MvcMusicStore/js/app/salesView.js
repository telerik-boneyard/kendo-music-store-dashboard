(function ($, kendo, musicDashboard, undefined) {
    musicDashboard.salesViewLogic = {
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
                        step: 1,
                        rotation: 70
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
                            step: 1,
                            rotation: 70
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
                    color: '#FFF',
                    rotation: 70
                };

            if (period == 'yearly')
                return {
                    format: "MMM",
                    step: 1,
                    color: '#FFF',
                    rotation: 70
                };
            return {
                format: "MMM dd",
                step: 1,
                color: '#FFF',
                rotation: 70
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

            if (chartType == "stacked-bar" || chartType == "bar") {
                chart.options.categoryAxis.labels.rotation = 0;
                chart.options.valueAxis.labels.rotation = 70;
            } else {
                chart.options.categoryAxis.labels.rotation = 70;
                chart.options.valueAxis.labels.rotation = 0;
            }

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
                            Genre: { type: "string" }
                        }
                    }
                }
            });

            musicDashboard.salesView.render("#main");

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

        }
    };
}(window.jQuery, window.kendo, window.musicDashboard));
