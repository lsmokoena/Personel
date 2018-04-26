export class myAppForm {
    constructor(_form, _nativeForm) {
        this._form = _form;
        this._nativeForm = _nativeForm;
        let childInputs = _form.elements;
        for (let formInput = 0; formInput < childInputs.length; formInput++) {
            let input = childInputs.item(formInput);
            //add validation handler to inputField
            this.addValidityHandler(input);
            if (input.type == 'button') {
                let formButton = input;
                //add submit functionality on the button
                formButton.onclick = function () {
                    if (_form.checkValidity()) {
                        _form.submit();
                    }
                    else {
                        _nativeForm.reportValidity();
                    }
                };
            }
        }
    }
    addResponse() {
        return 'hello world';
    }
    addValidityHandler(input) {
        if (input.classList.contains('validate')) {
            this.addMessageToLabel(input);
            input.oninvalid = (e) => {
                e.preventDefault();
                let source = e.srcElement;
                input.classList.add('invalid');
                console.log('focused on ' + source.id);
            };
        }
    }
    addMessageToLabel(inputField) {
        let label = document.getElementById('l' + inputField.id);
        if (label != null) {
            label.setAttribute('data-error', inputField.validationMessage);
        }
    }
}
//# sourceMappingURL=dsmForm.js.map