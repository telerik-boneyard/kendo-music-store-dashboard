(function ($, kendo, musicDashboard, undefined) {
    musicDashboard.mainViewLogic = {
        createMainView: function () {
            var that = this;

            musicDashboard.mainView.render("#main");

            $(".main-title").text("Music Store Sales");

            this.displayMainViewTotals();
            this.displayTopSingles();
            this.displayTopAlbums();
            this.CreateGauges();

            if (!musicDashboard.valueInterval) {
                musicDashboard.valueInterval = setInterval(function () {

                    that.UpdateGauges.call(that);

                }, 5000);
            }
        },

        displayMainViewTotals: function () {

            var item,
                totals = new kendo.data.DataSource({
                    transport: {
                        read: baseUrl + '/api/sales/totals'
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
                        url: baseUrl + "/api/top/tracks",
                        dataType: "json"
                    }
                }
            });
            var template = kendo.template($("#top-single-template").html());

            $("#topSinglesListView").kendoListView({
                dataSource: dataSource,
                template: template,
                dataBound: function (e) {
                    $(".top-single-song-list-item").on("click", function (e) {

                        e.preventDefault();

                        window.location = "#/sales/singles";

                    });
                }
            });

        },

        displayTopAlbums: function () {
            var dataSource = new kendo.data.DataSource({
                transport: {
                    read: {
                        url: baseUrl + "/api/top/albums",
                        dataType: "json"
                    }

                }
            });

            $("#topAlbumsListView").kendoListView({
                dataSource: dataSource,
                template: kendo.template($("#top-album-template").html()),
                dataBound: function (e) {
                    $(".top-album-list-item").on("click", function (e) {

                        e.preventDefault();

                        window.location = "#/sales/album";

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
            min = min || musicDashboard.defaultGaugeMin;
            max = max || musicDashboard.defaultGaugeMax;

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
                    max: max,
                    min: min,
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
                        read: baseUrl + '/api/sales/gauges'
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

        }
    };
}(window.jQuery, window.kendo, window.musicDashboard));
