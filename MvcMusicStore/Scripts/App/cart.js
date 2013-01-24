var Cart = function ($, kendo) {
    var that = this,
        cartData = null,
        cartLocalStorageName = "KendoMusicStoreCart",

        _getCartJson = function () {
            try {
                if (localStorage && localStorage[cartLocalStorageName] && localStorage[cartLocalStorageName].length > 0) {
                    return JSON.parse(localStorage[cartLocalStorageName]);
                }
            } catch (e) { }
            return [];
        },

        _setCartJson = function () {
            try {
                if (cartData.data().length == 0) {
                    localStorage.removeItem(cartLocalStorageName);
                } else {
                    localStorage[cartLocalStorageName] = JSON.stringify(cartData.data());
                }
            } catch (e) {
                alert("There was a problem saving your shopping cart to the browser local storage.");
            }
        };

    this.getCart = function () {
        if (!cartData) {
            cartData = new kendo.data.DataSource({
                data: _getCartJson(),
                change: function (data) {
                    for (var i = 0; i < data.items.length; i++) {
                        var item = data.items[i];
                        item.set("Total", item.Quantity * item.Album.Price);
                    }
                    _setCartJson();
                },
                aggregate: [{ field: "Total", aggregate: "sum" }]
            });
        }
        return cartData;
    };

    this.addToCart = function (album, qty) {
        that.getCart().add({
            Album: album,
            Quantity: qty,
            Total: 0
        });
        _setCartJson();
    };

    this.clearCart = function () {
        that.getCart().data([]);
        _setCartJson();
    };

    this.getTotalPrice = function () {
        // Return the aggregate of album totals.
        // When there are no albums in the cart, the '.Total' aggregate does not exist.
        var aggregates = that.getCart().aggregates();
        return aggregates.Total ? aggregates.Total.sum : 0;
    }
};