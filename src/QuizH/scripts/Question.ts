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
    title: string;
    freeTextLines: number;
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
    editor: IModal;
    title: KnockoutObservable<string>;
    freeTextLines: KnockoutObservable<number>;

    constructor(model: IQuestionViewModel) {
        this.answers = ko.observableArray(model.answers);
        this.newAnswer = ko.observable("");
        this.editor = new ModalEditor();
        this.title = ko.observable(model.title);
        this.freeTextLines = ko.observable(model.freeTextLines)
    }


    addAnswer() {
        this.editor.openModal(x => this.answers.push(new Answer(x, false)));
    }
    saveText() {
        //debugger;
        this.editor.saving();
    }
    editAnswer(id: number) {
        this.editor.edit = this.answers()[id].text;
        this.editor.openModal(x => {
            //console.log(id);
            this.answers.splice(id, 1);
            this.answers.push(new Answer(x, false))
        });
    }
    editTitle() {
        this.editor.edit = this.title();
        this.editor.openModal(x => {
            this.title(x)
        });
    }
}