/// <reference path="../typings/modules/knockout/index.d.ts" />
import * as ko from "knockout";
interface IExam {
    id: number;
    text: string;
}

class ExamsViewModel {
    questions: Array<IExam>;

    constructor(questions: Array<IExam>) {
        this.questions = questions;
    }
}


