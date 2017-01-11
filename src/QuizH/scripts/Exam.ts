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

    constructor(available: Array<IQuestion>, inModel: Array<number>) {
        var availableQuestions = available.filter(function (value: IQuestion, index: number, array: IQuestion[]) {
            return inModel.indexOf(value.id) < 0;
        });
        this.availableQuestions = ko.observableArray<IQuestion>(availableQuestions);

        var questionsInModel = available.filter(function (value: IQuestion, index: number, array: IQuestion[]) {
            return inModel.indexOf(value.id) >= 0;
        });
        this.selectedQuestions = ko.observableArray<IQuestion>(questionsInModel);
        
    }
    selectQuestion(id: KnockoutObservable<number>) {
        this.selectedQuestions.push(this.availableQuestions()[id()]);
        this.availableQuestions.splice(id(), 1);
    }
}
