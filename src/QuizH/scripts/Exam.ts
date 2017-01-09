/// <reference path="../typings/modules/knockout/index.d.ts" />
import ko = require('knockout')
interface IQuestion {
    id: number;
    text: string;
}

class ExamsViewModel {
    availableQuestions: Array<IQuestion>;
    selectedQuestions: ko.ObservableArray<IQuestion>;

    constructor(questions: any) {
        this.availableQuestions = questions;
        this.selectedQuestions = ko.observableArray<IQuestion>([]);
    }
    selectQuestion(id: ko.Observable<number>) {
        this.selectedQuestions.push(this.availableQuestions[id()]);
    }
}


var vm = new ExamsViewModel([{ "id": 0, "text": "Question 1" }, { "id": 1, "text": "Question 2" }]);
ko.applyBindings(vm);
