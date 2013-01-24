(function ($, kendo, Date, store) {
    var initComplete = false;
    var dateRanges = [{
        name: "Day",
        start: Date.today().toString("M/d/yyyy"),
        end: Date.today().add(1).days().toString("M/d/yyyy"),
        unit: "days"
    },
    {
        name: "Week",
        start: Date.today().add(-7).days().toString("M/d/yyyy"),
        end: Date.today().add(1).days().toString("M/d/yyyy"),
        unit: "days"
    },
    {
        name: "Month",
        start: Date.today().add(-1).months().toString("M/d/yyyy"),
        end: Date.today().add(1).days().toString("M/d/yyyy"),
        unit: "days"
    },
    {
        name: "Year",
        start: Date.today().add(-1).years().toString("M/d/yyyy"),
        end: Date.today().add(1).days().toString("M/d/yyyy"),
        unit: "months"
    }];

    var genreChartTypes = [{
        name: "Pie",
        type: "pie"
    },
    {
        name: "Donut",
        type: "donut"
    },
    {
        name: "Cake",
        type: "cake"
    }];

    var selectedDateRange = dateRanges[1];
    var selectedGenreChartType = genreChartTypes[0];

    var revenueChartDataSource = new kendo.data.DataSource({
        transport: {
            read: {
                url: store.config.salesAndRevenueUrl,
                dataType: "json"
            },
            parameterMap: function (options, type) {
                return {
                    start: selectedDateRange.start,
                    end: selectedDateRange.end
                };
            }
        },
        sort: {
            field: "Day",
            dir: "asc"
        }
    });

    var genreChartDataSource = new kendo.data.DataSource({
        transport: {
            read: {
                url: store.config.salesByGenreUrl,
                dataType: "json"
            },
            parameterMap: function (options, type) {
                return {
                    start: selectedDateRange.start,
                    end: selectedDateRange.end
                };
            }
        },
        sort: {
            field: "Genre",
            dir: "asc"
        }
    });

    var createOrderRevenueChart = function () {
        $("#revenue-chart").kendoChart({
            theme: $(document).data("kendoSkin") || "default",
            dataSource: revenueChartDataSource,
            legend: {
                position: "top"
            },
            series: [
                {
                    type: "column",
                    name: "Revenue",
                    field: "Revenue",
                    color: "#cc6e38",
                    tooltip: {
                        visible: true,
                        format: "{0:c}"
                    }
                },
                {
                    type: "line",
                    name: "Orders",
                    field: "Orders",
                    color: "#5a5959",
                    axis: "orders",
                    tooltip: {
                        visible: true,
                        format: "{0} Orders"
                    }
                }
            ],
            valueAxis: [
                {
                    title: { text: "Revenue" },
                    labels: {
                        format: "c"
                    }
                },
                {
                    name: "orders",
                    title: { text: "Number of Orders" },
                    color: "#ec5e0a"
                }
            ],
            categoryAxis: {
                field: "Day",
                format: "d",
                type: "date",
                baseUnit: selectedDateRange.unit,
                labels: {
                    rotation: 60
                },
                axisCrossingValue: [0, 1000]
            },
            tooltip: {
                visible: true
            }
        });
    };

    var createGenreChart = function () {
        $("#genre-chart").kendoChart({
            theme: $(document).data("kendoSkin") || "default",
            dataSource: genreChartDataSource,
            seriesDefaults: {
                type: selectedGenreChartType.type,
                labels: {
                    template: "#= category # - #= kendo.format('{0:P}', percentage)#",
                    visible: true,
                    position: "outsideEnd"
                }
            },
            legend: {
                visible: false
            },
            series: [{
                field: "Count",
                categoryField: "Genre"
            }]
        });
    };

    setTimeout(function () {
        // Initialize the chart with a delay to make sure
        // the initial animation is visible
        createOrderRevenueChart();
        createGenreChart();
    }, 400);

    var dateRangeChanged = function (e) {
        if (!initComplete) {
            return;
        }
        var data = this.dataSource.view();
        selectedDateRange = data[$(this.select()[0]).index()];
        $("#revenue-chart").data("kendoChart").options.categoryAxis.baseUnit = selectedDateRange.unit;
        revenueChartDataSource.read();
        genreChartDataSource.read();
    };

    var genreChartTypeChanged = function (e) {
        if (!initComplete) {
            return;
        }

        selectedGenreChartType = genreChartTypes[$(this.select()[0]).index()];

        if (selectedGenreChartType.type === "cake") {
            $("#genre-chart").html('<a href="http://knowyourmeme.com/memes/the-cake-is-a-lie"><img src="/content/images/cake.png" alt="The Cake is a Lie!" /><span class="cake">The cake is a lie!</span></a>');
        } else {
            $("#genre-chart").text("");
            $("#genre-chart").show();
            var chart = $("#genre-chart").data("kendoChart");
            chart.options.seriesDefaults.type = selectedGenreChartType.type;
            for (var i = 0; i < chart.options.series.length; i++) {
                chart.options.series[i].type = selectedGenreChartType.type;
            }
            chart.refresh();
        }
    };

    var dateRangeSelector = $("#date-range");
    dateRangeSelector.kendoListView({
        dataSource: dateRanges,
        template: "<li>#= name #</li>",
        selectable: "single",
        change: dateRangeChanged
    });
    dateRangeSelector.data("kendoListView").select(dateRangeSelector.children()[1]);

    var genreChartTypeSelector = $("#genre-chart-type");
    genreChartTypeSelector.kendoListView({
        dataSource: genreChartTypes,
        template: "<li>#= name #</li>",
        selectable: "single",
        change: genreChartTypeChanged
    });
    genreChartTypeSelector.data("kendoListView").select(genreChartTypeSelector.children()[0]);
    initComplete = true;
})(jQuery, kendo, Date, store);