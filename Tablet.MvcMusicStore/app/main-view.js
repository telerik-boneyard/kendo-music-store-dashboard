var defaultGaugeMin = 100,
    defaultGaugeMax = 400,
    valueInterval;


function createMainView() {

    $(".main-title").text("Music Store Sales");
    
    displayMainViewTotals();
    displayTopSingles();
    displayTopAlbums();
    CreateGauges();
    
    valueInterval = setInterval(UpdateGauges, 5000);

};

function displayMainViewTotals() {

    var totals = new kendo.data.DataSource({
        transport: {
            read: 'api/sales/totals'
        },
        schema : {
          data : function(response) {
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
}

function displayTopSingles() {

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

}

function displayTopAlbums() {

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
}

function CreateGauges() {

    CreateGauge(".albums-per-hour", parseInt(Math.floor((Math.random() * defaultGaugeMax) + 1), 10));
    CreateGauge(".singles-per-hour", parseInt(Math.floor((Math.random() * defaultGaugeMax) + 1), 10));
    CreateGauge(".new-customers-per-hour", parseInt(Math.floor((Math.random() * defaultGaugeMax) + 1), 10));
    CreateGauge(".visitors-per-hour", parseInt(Math.floor((Math.random() * defaultGaugeMax) + 1), 10));
};

function CreateGauge(selector, value, min, max) {

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

};


function UpdateGauges() {
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

    gaugeValueDataSource.read();
}

function ApplyGaugeDelta(selector, delta) {

    var gauge = $(selector).data('kendoRadialGauge'),
        value = 0;

    if (gauge) {

        value = gauge.value();

        gauge.value(value + delta);

    } else {
        clearInterval(valueInterval);
    }

}
