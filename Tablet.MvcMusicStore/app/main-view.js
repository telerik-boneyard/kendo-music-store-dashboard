var defaultGaugeMin = 100,
    defaultGaugeMax = 400,
    albumsPerHr = 0;


function createMainView() {

    displayMainViewTotals();
    displayTopSingles();
    displayTopAlbums();
    CreateGauges();
    
    albumsPerHr = setInterval(UpdateGauges, 5000);

  //  new KineticScroll(document.getElementById("topSinglesListView"));
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
            console.log(data.items[0]);
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

    UpdateGauge(".albums-per-hour");
    UpdateGauge(".singles-per-hour");
    UpdateGauge(".new-customers-per-hour");
    UpdateGauge(".visitors-per-hour");

};

function randomDelta(value) {

    var v = parseInt(Math.floor((Math.random() * 40) - 20), 10);

    if (v + value > defaultGaugeMax) {
        value -= v;
    } else {
        value += v;
    }

    return value;

}

function UpdateGauge(selector) {

    if (!selector || selector === "") {
        return;
    }

    var gauge = $(selector).data("kendoRadialGauge");

    if (gauge.length > 1) {

        gauge.value(randomDelta(gauge.value()));

    } else {

        clearInterval(albumsPerHr);

    }

};
