var salesPeriod = 60,
    salesGenrePeriod = 'weekly',
    searchesGenrePeriod = 7,
    salesChartType = "line",
    totalSalesUrl = "api/sales/TotalSales/" + salesPeriod,
    albumSales = "api/sales/AlbumSales/" + salesPeriod,
    singleSales = "api/sales/SingleSales/" + salesPeriod,
    totalDownloads = "api/sales/TotalDownloads/" + salesPeriod,
    ticketSales = "api/sales/TicketSales/" + salesPeriod;


function setSalesChart(options) {

    options = $.extend({}, {

        title: {
            text: "Store Sales",
            color: "#EF8549"
            , "font": "30px Arial,Helvetica,sans-serif"
        },
        dataSource: {
            transport: {
                read: {
                    url: totalSalesUrl,
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

}

var salesByGenreChartDataSource = new kendo.data.DataSource({
    transport: {
        read: {
            url: "api/salesbygenre/" + salesGenrePeriod,
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

var searchesByGenreChartDataSource = new kendo.data.DataSource({
    transport: {
        read: {
            url: "api/searchesbygenre/" + salesGenrePeriod,
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

function setSalesByGenreChart() {

    var options = {
        title: {
            text: "Sales By Genre",
            color: "#EF8549"
        },

        dataSource: salesByGenreChartDataSource,
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
}

function setSearchesByGenreChart() {

    var options = {
        title: {
            text: "Searches By Genre",
            color: "#EF8549"
        },

        dataSource: searchesByGenreChartDataSource,

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

}

function parseQuerystring() {

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
}

function createSalesView() {

    var get_vars = parseQuerystring();

    if (get_vars["target"] === "album") {

        albumSales = "api/sales/AlbumSales/" + salesPeriod;

        updateSalesChartData.call(document.querySelector(".sales-chart-options-albums"), albumSales, "Store Album Sales");

    } else if (get_vars["target"] === "singles") {

        singleSales = "api/sales/SingleSales/" + salesPeriod;

        updateSalesChartData.call(document.querySelector(".sales-chart-options-singles"), singleSales, "Store Single Sales");

    } else {
        setSalesChart();

    }

    $(".main-title").text("Store Sales Overview");

    setSalesByGenreChart();
    setSearchesByGenreChart();

    $(".genre-sales-tab").click(function (e) {

        var $this = $(this);

        if ($this.hasClass("time-sales-tab-selected")) {
            return;
        }

        $(".time-sales-tab", "#sales-by-genre").removeClass("time-sales-tab-selected");

        var period = $this.data('period');

        $this.addClass("time-sales-tab-selected");

        salesByGenreChartDataSource
            .options.transport.read.url = "api/salesbygenre/" + period;

        $('.sales-by-genre-chart')
            .data('kendoChart')
            .options.categoryAxis.labels = getLabelOptions(period);

        salesByGenreChartDataSource.read();
    });

    $(".genre-searches-tab").click(function (e) {

        var $this = $(this);

        if ($this.hasClass("time-sales-tab-selected")) {
            return;
        }

        $(".time-sales-tab", "#searches-by-genre").removeClass("time-sales-tab-selected");

        var period = $this.data('period');

        $this.addClass("time-sales-tab-selected");

        searchesByGenreChartDataSource
            .options.transport.read.url = "api/searchesbygenre/" + period;

        $('.searches-by-genre-chart')
            .data('kendoChart')
            .options.categoryAxis.labels = getLabelOptions(period);

        searchesByGenreChartDataSource.read();

    });

    function getLabelOptions(period) {
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
    }

    function updateSalesChartData(saleUrl, title) {

        $(".sales-chart-options-item-selected").removeClass("sales-chart-options-item-selected");
        $(this).addClass("sales-chart-options-item-selected");

        title = title || "Store Sales";

        setSalesChart({
            title: {
                text: title,
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

    }

    $(".sales-chart-options-albums").click(function (e) {

        e.preventDefault();

        albumSales = "api/sales/AlbumSales/" + salesPeriod;

        updateSalesChartData.call(this, albumSales, "Store Album Sales");

    });

    $(".sales-chart-options-singles").click(function (e) {

        e.preventDefault();

        singleSales = "api/sales/SingleSales/" + salesPeriod;

        updateSalesChartData.call(this, singleSales, "Store Single Sales");

    });

    $(".sales-chart-options-sales").click(function (e) {

        e.preventDefault();

        totalSalesUrl = "api/sales/TotalSales/" + salesPeriod;

        updateSalesChartData.call(this, totalSalesUrl, "Store Total Sales");

    });

    $(".sales-chart-options-downloads").click(function (e) {

        e.preventDefault();

        totalDownloads = "api/sales/TotalDownloads/" + salesPeriod;

        updateSalesChartData.call(this, totalDownloads, "Store Downloads");

    });

    $(".sales-chart-options-tickets").click(function (e) {

        e.preventDefault();

        ticketSales = "api/sales/TicketSales/" + salesPeriod;

        updateSalesChartData.call(this, ticketSales, "Store Ticket Sales");

    });


    function removeSelectedGenreSalesType(parentWrapper) {

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

    }

    function changeChartType(chartSelector, parentChartType) {

        removeSelectedGenreSalesType(parentChartType);

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

    }

    $(".chart-type-item", ".change-genre-sales-chart-type").click(function (e) {

        e.preventDefault();

        changeChartType.call(this, ".sales-by-genre-chart", ".change-genre-sales-chart-type");

    });

    $(".chart-type-item", ".genre-searches-chart-type").click(function (e) {

        e.preventDefault();

        changeChartType.call(this, ".searches-by-genre-chart", ".genre-searches-chart-type");

    });

    $(window).on("resize orientationchange", function (e) {
        $(".sales-by-genre-chart").data("kendoChart").redraw();
        $(".searches-by-genre-chart").data("kendoChart").redraw();
        $(".store-sales-chart").data("kendoStockChart").redraw();
    });

}
