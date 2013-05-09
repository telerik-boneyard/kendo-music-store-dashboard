;

"use strict";

(function (window, undefined) {

    var musicDashboard = {

        router: undefined,

        setup: function () {

            this.router = new kendo.Router();

            this.setupRoutes();
            this.bindNavigation();

            this.router.start();


        },

        setupRoutes: function () {

            if (this.router) {

                this.router.route("/", function () {
                    console.log("home");
                });

                this.router.route("/sales", function () {
                    console.log("sales");
                });

                this.router.route("/social", function () {
                    console.log("social");
                });

            }

        },

        bindNavigation: function () {

            if (this.router) {

                $(".social-album, .nav-social").click(function (e) {
                    e.preventDefault();
                    e.stopPropagation();

                    //        clearInterval(valueInterval);
                    router.navigate("/social");

                });

                $(".charts-album, .nav-music").click(function (e) {
                    e.preventDefault();
                    e.stopPropagation();

                    router.navigate("/sales");

                });

                $("#main-header, .main-header-pennant").click(function (e) {
                    e.preventDefault();
                    e.stopPropagation();
                    router.navigate("/");

                });

            }

        }

    };





    return (window.musicDashboard = musicDashboard);

}(window));


musicDashboard.setup();




