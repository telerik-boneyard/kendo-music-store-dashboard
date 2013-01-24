(function ($, kendo, store) {
    var urlParams = store.getUrlParams();
    var genreId = parseInt(urlParams.Genre);

    var viewModel = kendo.observable({
        albums: new kendo.data.DataSource({
            type: "odata",
            pageSize: store.config.browseGenrePageSize,
            serverFiltering: true,
            serverPaging: true,
            filter: {
                field: "GenreId",
                operator: "eq",
                value: genreId
            },
            transport: {
                read: store.config.albumsWithArtistsUrl
            },
            schema: {
                data: store.config.wcfSchemaData,
                total: store.config.wcfSchemaTotal
            }
        }),
        genre: null, // this will hold our Genre object, once loaded.

        viewAlbumDetails: function (e) {
            store.viewAlbumDetails(e.data.AlbumId);
        }
    });

    // Load the Genre data from the server.
    $.ajax({
        url: store.config.genresUrl + "(" + genreId + ")",
        type: "GET",
        dataType: "json",
        success: function (data) {
            viewModel.set("genre", data);
        }
    });

    kendo.bind("#body", viewModel);
})(jQuery, kendo, store);