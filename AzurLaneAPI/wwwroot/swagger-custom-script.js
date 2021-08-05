(function() {
    window.addEventListener("load", function() {
        setTimeout(function() {

            // Section 01 - Set url link 
            var logo = document.getElementsByClassName('link');
            logo[0].href = "https://api.azurlane.mutedevs.nl";
            logo[0].target = "_blank";

            // Section 02 - Set logo
            logo[0].children[0].alt = "AzurLaneAPI";
            logo[0].children[0].src = "/swagger-ui/resources/logo.png";
        });
    });
})();