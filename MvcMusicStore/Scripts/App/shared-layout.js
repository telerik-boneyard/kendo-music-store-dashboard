(function ($, kendo, store) {
    $("#menu").kendoMenu();
    
    $("#cart-menu").kendoCartMenu({
        dataSource: store.cart.getCart()
    });
    
    $("#main-search").kendoAutoComplete({
        filter: 'contains',
        minLength: 3,
        dataTextField: "Title",
        placeholder: "Search music...",
        height: 300,
        template: kendo.template($("#search-result-template").html()),

        dataSource: {
            type: "odata",
            serverFiltering: true,
            serverPaging: true,
            pageSize: store.config.searchMaxResults,
            transport: {
                read: store.config.albumsWithArtistsUrl
            },
            schema: {
                data: store.config.wcfSchemaData,
                total: store.config.wcfSchemaTotal
            }
        },

        select: function (e) {
            e.preventDefault(); // Stop the selected item text from moving up to the AutoComplete.
            e.sender.value(""); // clear the user entered search term.
            var albumId = e.item.children("div").data("album-id");
            store.viewAlbumDetails(albumId);
        }
    });

    //FOUJUI FIX - Reveal body after UI initilization completes
    $("#menu, #cart-search").css("opacity", 1);
})(jQuery, kendo, store);