/// <reference path="../typings/modules/jquery/index.d.ts" />
/// <reference path="../typings/modules/bootstrap/index.d.ts" />
/// <reference path="../typings/modules/tinymce/tinymce.d.ts" />

interface myCallbackType { (text: string): void }

interface IModal {
    openModal: { (): void };
    saving: { (callback: myCallbackType): void };
}
class ModalEditor implements IModal {

    //Public Method
    openModal() {
        $('#myModal').modal("show");
    }
    saving(callback: myCallbackType) {
        if (tinyMCE.activeEditor != null) {

            callback(tinyMCE.activeEditor.getContent());
            tinyMCE.activeEditor.setContent("");
        }
    }
}
