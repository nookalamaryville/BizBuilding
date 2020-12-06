$(document).ready(function () {
  $.get("./scripts/templates/homefeatures.htm", function (templates) {
    var featurestemplate = $(templates).filter("#tpl-homefeatures").html();
    var bannertemplate = $(templates).filter("#tpl-homebanner").html();
    $.getJSON("../../scripts/json/homefeatures.json", function (data) {
      Mustache.parse(featurestemplate);
      Mustache.parse(bannertemplate);
      var renderedfeatures = Mustache.render(
        featurestemplate,
        data.homefeatures
      );
      var renderedbanner = Mustache.render(bannertemplate, data.homebanner);
      $("#home-features").html(renderedfeatures);
      $("#home-banner").html(renderedbanner);
    });
  });
});
