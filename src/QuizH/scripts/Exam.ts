/// <reference path="../typings/modules/knockout/index.d.ts" />
/// <reference path="../typings/modules/jquery/index.d.ts" />
//import ko = require('knockout')
interface IQuestion {
    id: number;
    text: string;
}

class ExamsViewModel {
    availableQuestions: KnockoutObservableArray<IQuestion>;
    selectedQuestions: KnockoutObservableArray<IQuestion>;

    constructor(questions: any) {
        this.availableQuestions = ko.observableArray<IQuestion>(questions);
        this.selectedQuestions = ko.observableArray<IQuestion>([]);
        
    }
    selectQuestion(id: KnockoutObservable<number>) {
        this.selectedQuestions.push(this.availableQuestions()[id()]);
        this.availableQuestions.splice(id(), 1);
    }
}
$.getJSON("/Question/Get",function (data) {
        var vm = new ExamsViewModel(data);
        ko.applyBindings(vm);
    }
);