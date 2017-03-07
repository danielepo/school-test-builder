/// <reference path="../typings/modules/knockout/index.d.ts" />
/// <reference path="../typings/modules/jquery/index.d.ts" />
//import ko = require('knockout')
interface IQuestion {
    id: number;
    text: string;
    subjectId: number;
}
interface ISubject {
    id: number;
    title: string;
}

class ExamsViewModel {
    availableQuestions: KnockoutObservableArray<IQuestion>;
    selectedQuestions: KnockoutObservableArray<IQuestion>;
    //filteredQuestions: KnockoutComputed<IQuestion[]>;

    subjects: ISubject[];
    selectedSubject: KnockoutObservable<number>;

    constructor(available: IQuestion[], inModel: number[], subjects: ISubject[]) {
        this.subjects = subjects;
        
        var availableQuestions = available.filter(function (value: IQuestion, index: number, array: IQuestion[]) {
            return inModel.indexOf(value.id) < 0;
        });

        this.availableQuestions = ko.observableArray<IQuestion>(availableQuestions);

        var questionsInModel = available.filter(function (value: IQuestion, index: number, array: IQuestion[]) {
            return inModel.indexOf(value.id) >= 0;
        });
        this.selectedQuestions = ko.observableArray<IQuestion>(questionsInModel);
        this.selectedSubject = ko.observable<number>(0);
    }

    selectQuestion(id: KnockoutObservable<number>) {
        this.selectedQuestions.push(this.availableQuestions()[id()]);
        this.availableQuestions.splice(id(), 1);
    }
    filteredQuestions = () => ko.computed({
        owner: this,
        read: function () {
            debugger;
            var subject = typeof this.selectedSubject() == "undefined" ? 0 : this.selectedSubject() ;
            return this.availableQuestions().filter(
                function (value: IQuestion, index: number, array: IQuestion[]) {
                    return subject == 0 || value.subjectId == subject;
                });
        }
    })();

}