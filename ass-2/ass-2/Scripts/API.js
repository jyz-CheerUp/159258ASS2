
    function validateHTML() {
        var htmlContent = document.documentElement.outerHTML;

    var w3cValidatorUrl = "https://validator.w3.org/nu/";


    var w3cValidatorForm = document.createElement("form");
    w3cValidatorForm.method = "POST";
    w3cValidatorForm.enctype = "multipart/form-data";
    w3cValidatorForm.action = w3cValidatorUrl;
    w3cValidatorForm.target = "_blank";
    w3cValidatorForm.style.display = "none";

    var w3cValidatorInput = document.createElement("input");
    w3cValidatorInput.type = "hidden";
    w3cValidatorInput.name = "content";
    w3cValidatorInput.value = htmlContent;
    w3cValidatorForm.appendChild(w3cValidatorInput);

    document.body.appendChild(w3cValidatorForm);
    w3cValidatorForm.submit();
    }
function validateCSS() {
    var cssContent = '';

    var styleSheets = document.styleSheets;
    for (var i = 0; i < styleSheets.length; i++) {
        var rules = styleSheets[i].cssRules;
        if (rules) {
            for (var j = 0; j < rules.length; j++) {
                cssContent += rules[j].cssText + '\n';
            }
        }
    }

    var cssValidatorUrl = "http://jigsaw.w3.org/css-validator/validator";

    var cssValidatorForm = document.createElement("form");
    cssValidatorForm.method = "POST";
    cssValidatorForm.enctype = "multipart/form-data";
    cssValidatorForm.action = cssValidatorUrl;
    cssValidatorForm.target = "_blank";
    cssValidatorForm.style.display = "none";

    var cssValidatorInput = document.createElement("input");
    cssValidatorInput.type = "hidden";
    cssValidatorInput.name = "text";
    cssValidatorInput.value = cssContent;
    cssValidatorForm.appendChild(cssValidatorInput);

    document.body.appendChild(cssValidatorForm);
    cssValidatorForm.submit();
}
