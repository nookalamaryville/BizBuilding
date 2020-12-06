$(document).ready(function () {
  $.get("./scripts/templates/userstories.htm", function (templates) {
    var template = $(templates).filter("#tpl-userstories").html();
    $.getJSON("./scripts/json/userstories.json", function (data) {
      Mustache.parse(template);
      var rendered = Mustache.render(template, data);
      $("#userstories").html(rendered);
    });
  });
});
