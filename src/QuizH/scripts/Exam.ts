/// <reference path="../typings/modules/knockout/index.d.ts" />

import ko = require("knockout");
function sayHello() {
    const compiler = (document.getElementById("compiler") as HTMLInputElement).value;
    const framework = (document.getElementById("framework") as HTMLInputElement).value
    ko.applyBindings(new ViewModel);
    return `Hello from ${compiler} and ${framework}!`;
}