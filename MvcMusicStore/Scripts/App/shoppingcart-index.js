(function ($, kendo, store) {
    var cartDataSource = store.cart.getCart();

    var viewModel = kendo.observable({
        cartItems: cartDataSource,
        updateQty: function (e) {
            e.data.set("Quantity", e.sender.value());
        },
        remove: function (e) {
            this.cartItems.remove(e.data);
        },
        total: 0
    });

    var calcTotal = function (e) {
        viewModel.set("total", store.cart.getTotalPrice());
    };

    cartDataSource.bind("change", calcTotal);
    kendo.bind($("#body"), viewModel);
})(jQuery, kendo, store);