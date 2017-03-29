/// <reference path="../typings/modules/jquery/index.d.ts" />
/// <reference path="../typings/modules/bootstrap/index.d.ts" />
/// <reference path="../typings/modules/tinymce/tinymce.d.ts" />

interface myCallbackType { (text: string): void }

interface IModal {
    openModal: { (callback: myCallbackType): void };
    saving: { (): void };
    edit: string;
}
class ModalEditor implements IModal {
    callback: myCallbackType;
    edit: string;
    //Public Method
    openModal(callback: myCallbackType) {
        $('#myModal').modal("show");
        this.callback = callback;
        tinyMCE.activeEditor.setContent(this.edit);
    }
    saving() {
        if (tinyMCE.activeEditor != null) {
            this.callback(tinyMCE.activeEditor.getContent());
            tinyMCE.activeEditor.setContent("");
            this.edit = "";
        }
    }

}
