/// <reference path="../typings/modules/knockout/index.d.ts" />
/// <reference path="../typings/modules/jquery/index.d.ts" />
/// <reference path="modaleditor.ts" />
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
interface IAnswer {
    text: string;
    isCorrect: boolean;
}
interface IQuestionViewModel {
    answers: IAnswer[];
}
class Answer implements IAnswer {
    text: string;
    isCorrect: boolean;
    constructor(value: string, isCorrect: boolean) {
        this.text = value;
        this.isCorrect = isCorrect;
    }
}
class QuestionViewModel {
    answers: KnockoutObservableArray<IAnswer>;
    newAnswer: KnockoutObservable<string>;
    editor: IModal;;

    constructor(model: IQuestionViewModel) {
        this.answers = ko.observableArray(model.answers);
        this.newAnswer = ko.observable("");
        this.editor = new ModalEditor();
    }


    addAnswer() {
        this.editor.openModal();
    }
    saveText() {
        this.editor.saving(x => this.answers.push(new Answer(x, false)));
    }
}