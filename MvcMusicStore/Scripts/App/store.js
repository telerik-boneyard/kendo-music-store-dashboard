var store = (function ($, kendo) {
    var cart = new Cart($, kendo),
        config = new Config(),

        _openWindow = function (template, viewModel) {
            // Create a placeholder element.
            var window = $(document.createElement('div'));

            // Apply template to the placeholder element, and bind the viewmodel.
            var templateHtml = $(template).html();
            window.html(kendo.template(templateHtml)(viewModel));
            kendo.bind(window, viewModel);

            // Add window placeholder to the body.
            $('body').append(window);

            // Turn placeholder into a Window widget.
            window.kendoWindow({
                width: config.albumDetailsWindowWidth,
                title: viewModel.data.Title,
                resizable: false,
                close: function () {
                    // When the window is closed, remove the element from the document.
                    window.parents(".k-window").remove();
                }
            });

            // Center and show the Window.
            window.data("kendoWindow").center();
            window.data("kendoWindow").open();
        },

        _createAlbumDetailsViewModel = function (data) {
            return kendo.observable({
                quantity: 1,
                data: data,
                total: function() {
                    return this.get("data.Price") * this.get("quantity");
                },
                updateQty: function(e) {
                    this.set("quantity", e.sender.value());
                },
                addToCart: function(e) {
                    cart.addToCart(this.data, this.quantity);
                    var window = $(e.target).parents(".k-window-content").data("kendoWindow");
                    if (window) {
                        window.close();
                    }
                }
            });
        },

        viewAlbumDetails = function (albumId) {
            $.ajax({
                url: config.albumsUrl + "(" + albumId + ")",
                type: "GET",
                dataType: "json",
                success: function (data) {
                    _openWindow("#album-details-template", _createAlbumDetailsViewModel(data));
                }
            });
        },

        getUrlParams = function () {
            // this function was borrowed from StackOverflow:
            // http://stackoverflow.com/questions/901115/how-can-i-get-query-string-values
            var urlParams = {};
            var match,
                pl = /\+/g,
                search = /([^&=]+)=?([^&]*)/g,
                decode = function (s) { return decodeURIComponent(s.replace(pl, " ")); },
                query = window.location.search.substring(1);

            while (match = search.exec(query))
                urlParams[decode(match[1])] = decode(match[2]);

            return urlParams;
        };

    return {
        cart: cart,
        viewAlbumDetails: viewAlbumDetails,
        getUrlParams: getUrlParams,
        config: config
    };
})(jQuery, kendo);