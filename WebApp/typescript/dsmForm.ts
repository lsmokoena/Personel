export class myAppForm {

    constructor(private _form: HTMLFormElement, private _nativeForm: any) {

        let childInputs: HTMLFormControlsCollection = <HTMLFormControlsCollection>_form.elements;


        for (let formInput = 0; formInput < childInputs.length; formInput++) {
            let input: HTMLInputElement = <HTMLInputElement>childInputs.item(formInput);
            //add validation handler to inputField
            this.addValidityHandler(input);

            if (input.type == 'button') {
                let formButton: HTMLButtonElement = <HTMLButtonElement>input;
                //add submit functionality on the button
                formButton.onclick = function () {
                    if (_form.checkValidity()) {
                        _form.submit();

                    } else {
                        _nativeForm.reportValidity();
                    }

                }
            }
        }

    }

    addResponse() {
        return 'hello world';
    }

    addValidityHandler(input: HTMLInputElement) {
        if (input.classList.contains('validate')) {
            this.addMessageToLabel(input);
            input.oninvalid = (e: Event) => {
                e.preventDefault();
                let source = e.srcElement;
                input.classList.add('invalid');
                console.log('focused on ' + source.id);
            };
        }

    }

    addMessageToLabel(inputField: HTMLInputElement): void {
        let label: HTMLLabelElement = <HTMLLabelElement>document.getElementById('l' + inputField.id);
        if (label != null) {
            label.setAttribute('data-error', inputField.validationMessage);
        }
    }
}
