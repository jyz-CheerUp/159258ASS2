 <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.1.0/jquery.min.js"></script>

        (function ($) {
            $.fn.timeline = function () {
                var selectors = {
                    id: $(this),
                    item: $(this).find(".item"),
                    activeClass: "item--active",
                    img: ".img"
                };
               // Activate the first timeline item and set the timeline background image to the picture of the first item
                selectors.item.eq(0).addClass(selectors.activeClass);
                selectors.id.css(
                    "background-image",
                    "url(" +
                    selectors.item.first()
                        .find(selectors.img)
                        .attr("src") +
                    ")"
                );
              // Gets the total number of timeline items
                var itemLength = selectors.item.length;
            // When the page scrolls, a scrolling event is triggered
                $(window).scroll(function () {
                    var max, min;
                // Get the page scroll distance
                    var pos = $(this).scrollTop();
                    selectors.item.each(function (i) {
                 // Gets the minimum and maximum heights for the current timeline item
                        min = $(this).offset().top;
                        max = $(this).height() + $(this).offset().top;
                        var that = $(this);
// If you scroll to the last item and exceed half the height of the current item,
// Then the last item is set to active and the background image is set to the image of the last item
                        if (i == itemLength - 2 && pos > min + $(this).height() / 2) {
                            selectors.item.removeClass(selectors.activeClass);
                            selectors.id.css(
                                "background-image",
                                "url(" +
                                selectors.item.last()
                                    .find(selectors.img)
                                    .attr("src") +
                                ")"
                            );
                            selectors.item.last().addClass(selectors.activeClass);
                        }
                // If the current scroll position is between the minimum and maximum height of the current item,
// Then the current project is set to the active state and the background image is set to the picture of the current project
                        else if (pos <= max - 10 && pos >= min) {
                            selectors.id.css(
                                "background-image",
                                "url(" +
                                $(this)
                                    .find(selectors.img)
                                    .attr("src") +
                                ")"
                            );
                            selectors.item.removeClass(selectors.activeClass);
                            $(this).addClass(selectors.activeClass);
                        }
                    });
                });
            };
        })(jQuery)
        /*
   Finally, we call the timeline plug-in and pass in the ID of the timeline as an argument.
This will enable the timeline plug-in and bind scroll events to that timeline.
        */
       $("#shell").timeline();



