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
interface IExamViewModel{
    availableQuestions: IQuestion[];
    alreadySelectedQuestions: number[];
    subjects: ISubject[];
    courses: ICourse[];
    title: string;
}

class ExamsViewModel {
    availableQuestions: KnockoutObservableArray<IQuestion>;
    selectedQuestions: KnockoutObservableArray<IQuestion>;
    //filteredQuestions: KnockoutComputed<IQuestion[]>;

    subjects: ISubject[];
    courses: ICourse[];

    selectedSubject: KnockoutObservable<number>;
    selectedCourse: KnockoutObservable<number>;
    editor: IModal;
    title: KnockoutObservable<string>;

    constructor(model: IExamViewModel) {
        this.subjects = model.subjects;
        this.courses = model.courses;
        
        var availableQuestions = model.availableQuestions.filter(function (value: IQuestion, index: number, array: IQuestion[]) {
            return model.alreadySelectedQuestions.indexOf(value.id) < 0;
        });

        this.availableQuestions = ko.observableArray<IQuestion>(availableQuestions);

        var questionsInModel = model.availableQuestions.filter(function (value: IQuestion, index: number, array: IQuestion[]) {
            return model.alreadySelectedQuestions.indexOf(value.id) >= 0;
        });
        this.selectedQuestions = ko.observableArray<IQuestion>(questionsInModel);
        this.selectedSubject = ko.observable<number>(0);
        this.selectedCourse = ko.observable<number>(0);
        this.editor = new ModalEditor();
        this.title = ko.observable(model.title);

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
            var course = typeof this.selectedCourse() == "undefined" ? 0 : this.selectedCourse() ;
            return this.availableQuestions().filter(
                function (value: IQuestion, index: number, array: IQuestion[]) {
                    var hasSubject = subject == 0 || value.subjectId == subject;
                    var hasCourse = course == 0 || value.courses.indexOf(course) != -1;
                    return hasSubject && hasCourse;
                });
        }
    })();

    editTitle() {
        this.editor.edit = this.title();
        this.editor.openModal(x => {
            this.title(x)
        });
    }
    saveText() {
        //debugger;
        this.editor.saving();
    }
}