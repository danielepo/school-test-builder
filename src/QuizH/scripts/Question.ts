/// <reference path="../typings/modules/knockout/index.d.ts" />
/// <reference path="../typings/modules/jquery/index.d.ts" />
//import ko = require('knockout')
interface IQuestion {
    id: number;
    text: string;
    subjectId: number;
    courses: number[];
}
interface ISubject {
    id: number;
    title: string;
}
interface ICourse {
    id: number;
    title: string;
}
interface IQuestionViewModel{
    answers: string[];
}
interface IAnswer {
    text: string
}
class Answer implements IAnswer {
    text: string;
    constructor(value: string) {
        this.text = value;
    }
}
class QuestionViewModel {
    answers: KnockoutObservableArray<IAnswer>;
    newAnswer: KnockoutObservable<string>;
    constructor(model: IQuestionViewModel) {
        var temp = model.answers.map(function (value) { return new Answer(value); });
        this.answers = ko.observableArray(temp);
        this.newAnswer = ko.observable("");
    }


    addAnswer() {
        this.answers.push(new Answer(this.newAnswer()));
        this.newAnswer("");
    }
}