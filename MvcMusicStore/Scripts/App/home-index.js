(function ($, kendo, store) {
    var viewModel = kendo.observable({
        featuredArtistName: store.config.featuredArtist,
        
        featuredArtistAlbums: new kendo.data.DataSource({
            type: "odata",
            serverFiltering: true,
            serverPaging: true,
            pageSize: 5,
            filter: {
                field: "Artist/Name",
                operator: "eq",
                value: store.config.featuredArtist
            },
            transport: {
                read: store.config.albumsWithArtistsUrl
            },
            schema: {
                data: store.config.wcfSchemaData,
                total: store.config.wcfSchemaTotal
            }
        }),

        topSellingAlbums: new kendo.data.DataSource({
            type: "odata",
            transport: {
                read: store.config.albumsWithArtistsUrl + "&$top=5"
            },
            schema: {
                data: store.config.wcfSchemaData,
                total: store.config.wcfSchemaTotal
            }
        }),

        bannerImages: store.config.bannerImages,

        viewAlbumDetails: function (e) {
            store.viewAlbumDetails(e.data.AlbumId);
        }
    });

    kendo.bind("#body", viewModel);
})(jQuery, kendo, store);