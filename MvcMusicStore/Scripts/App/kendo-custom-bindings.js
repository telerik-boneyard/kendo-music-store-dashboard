kendo.data.binders.rotateImages = kendo.data.Binder.extend({
    init: function (element, bindings, options) {
        kendo.data.Binder.fn.init.call(this, element, bindings, options);
        var binding = this.bindings.rotateImages;
        var target = $(element);
        binding.rotateDelay = target.data("rotate-delay");
        binding.imageIndex = 0;
        binding.doImageRotation = function () {
            var imageArray = binding.get();
            var nextImageUrl = imageArray[binding.imageIndex];

            kendo.fx(target).fadeOut().play().then(function(){ 
                target.attr("src", nextImageUrl);
                kendo.fx(target).fadeIn().play();
            });

            binding.imageIndex++;
            if (binding.imageIndex >= imageArray.length) {
                binding.imageIndex = 0;
            }
        };
    },
    refresh: function () {
        var binding = this.bindings.rotateImages;
        binding.imageIndex = 0;
        binding.doImageRotation();
        binding.interval = setInterval(binding.doImageRotation, binding.rotateDelay);
    },
    destroy: function () {
        var binding = this.bindings.rotateImages;
        clearInterval(binding.interval);
    }
});

kendo.data.binders.textFormatted = kendo.data.Binder.extend({
    refresh: function () {
        var format = $(this.element).data("format");
        var text = this.bindings.textFormatted.get();

        if (text == null) {
            text = "";
        }

        $(this.element).text(format ? kendo.toString(text, format) : text);
    }
});
