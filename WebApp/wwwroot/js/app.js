let errorMessages = {
    'form': {
        'formerror': {
            'output': 'toastr',
            'type': 'error',
            'message': 'Please complete this form before submitting.'
        },
        'resetpassword': {
            'output': 'toastr',
            'type': 'error',
            'message': 'Pasword field values do not match. Please ensure that both fields match before trying again.'
        },
        'perspectiveerror': {
            'output': 'toastr',
            'type': 'error',
            'message': 'Please select at least a single perspective before continuing.'
        },
        'rolefunctionerror': {
            'output': 'toastr',
            'type': 'error',
            'message': 'Please select at least a single function before continuing.'
        },
        'fieldruleserror': {
            'output': 'toastr',
            'type': 'error',
            'message': 'Please add at least a single rule before continuing.'
        },
        'accounttypefielderror': {
            'output': 'toastr',
            'type': 'error',
            'message': 'Please add at least a single field before continuing.'
        }, 'nomembererror': {
            'output': 'toastr',
            'type': 'error',
            'message': 'Please select at a member before continuing.'
        }, 'password': {
            'zeroinput': {
                'output': 'toastr',
                'type': 'error',
                'message': 'Please complete the pasword field.'
            },
            'failedpassword': {
                'output': 'dialog',
                'type': 'error',
                'title': 'Password Complexity Error',
                'message': 'Please enter a password with the following complexity: </br>- 1 special character</br>- 1 number</br>- 1 capital letter</br>- Minimum than 6 characters'
            }
        }
    },
    'input': {
        'email': 'Please enter a valid email address.',
        'tel': 'Please enter a valid phone number.',
        'text': 'Please enter a value based on the title.'
    }, 'system': {
        'users': {
            'create': 'User successfully created.',
            'update': 'User successfully updated.',
            'delete': 'User successfully removed.',
            'empty': 'User not found',
            'off': 'User successfully deleted',
            'on': 'User successfully activated'
        },
        'roles': {
            'create': 'Role successfully created.',
            'update': 'Role successfully updated.',
            'delete': 'Role successfully removed.',
            'empty': 'Role not found',
            'off': 'Role successfully deleted',
            'on': 'Role successfully activated'
        },
        'members': {
            'create': 'Member successfully created.',
            'update': 'Member successfully updated.',
            'delete': 'Member successfully removed.',
            'empty': 'Member not found',
            'off': 'Member successfully deleted',
            'on': 'Member successfully activated'
        },
        'accounttype': {
            'create': 'Account Type successfully created.',
            'update': 'Account Type successfully updated.',
            'delete': 'Account Type successfully removed.',
            'empty': 'Account Type not found',
            'off': 'Account Type successfully deleted',
            'on': 'Account Type successfully activated'
        },
        'industries': {
            'create': 'Industry successfully created.',
            'update': 'Industry successfully changed.',
            'delete': 'Industry successfully removed.',
            'empty': 'Industry not found',
            'off': 'Industry successfully deleted',
            'on': 'Industry successfully activated'
        },
        'perspectives': {
            'create': 'Perspective successfully created.',
            'update': 'Perspective successfully changed.',
            'delete': 'Perspective successfully removed.',
            'empty': 'Perspective not found',
            'off': 'Perspective successfully deleted',
            'on': 'Perspective successfully activated'
        },
        'submmissiontype': {
            'create': 'Submission Type successfully created.',
            'update': 'Submission Type successfully changed.',
            'delete': 'Submission Type successfully removed.',
            'empty': 'Submission Type not found',
            'off': 'Submission Type successfully deleted',
            'on': 'Submission Type successfully activated'
        },
        'fields': {
            'create': 'Field successfully created.',
            'update': 'Field successfully changed.',
            'delete': 'Field successfully removed.',
            'empty': 'Field not found',
            'off': 'Field successfully deleted',
            'on': 'Field successfully activated'
        },
        'rules': {
            'create': 'Rule successfully created.',
            'update': 'Rule successfully changed.',
            'delete': 'Rule successfully removed.',
            'empty': 'Rule not found',
            'off': 'Rule successfully deleted',
            'on': 'Rule successfully activated'
        },
        'login': {
            'fail': 'Incorrect password combination.'
        }
    }
};
window.error = errorMessages;
let appDocument = document;
let applicationBody = appDocument.body;
let controlsContent = document.getElementById('controlscontent');
let logoffControlsSection = document.getElementById('logoffsection');
let defaultSection = document.getElementById('default');
let logoffButton = document.getElementById('logoff');
logoffButton.onclick = (e) => {
    $('#renderedsection').toggle('hiddendiv');
    e.preventDefault();
    controlsContent.innerHTML = logoffControlsSection.innerHTML;
    dialog._dialogTitleBackground.classList.add('primary-color');
    dialog._dialogContent.innerText = 'Are  you sure you want to sign out?';
    dialog._dialogTitle.innerText = 'Sign Out';
    var signoutButton = document.getElementById('signout');
    signoutButton.onclick = () => {
        window.location = e.srcElement.href;
    };
    var close = document.getElementById('closelogoff');
    close.onclick = () => {
        $('#renderedsection').toggle('hiddendiv');
        dialog._dialogContent.innerText = '';
        dialog.closeDialog();
        controlsContent.innerHTML = defaultSection.innerHTML;
    };
    dialog.showDialog();
};
applicationBody.onload = (e) => {
    controlsContent.innerHTML = defaultSection.innerHTML;
    let appState = document.getElementById('userstate');
    let dsmAppBootstrap = new DsmApplicationBootStrap(appDocument);
    dsmAppBootstrap.initApplicationNavigationSystem(appState.value);
    if (document.forms.length > 0) {
        dsmAppBootstrap.initAppForm();
    }
    dsmAppBootstrap.initAppSearch();
    dsmAppBootstrap.initAppTable();
};
function resetPassword() {
    var password = document.getElementById('password');
    var confirmPassword = document.getElementById('confirmPassword');
    var form = document.getElementById('resetpassword');
    return new Promise(function (resolve, reject) {
        if (password.value == confirmPassword.value) {
            resolve();
        }
        else {
            reject(error.form.resetpassword);
        }
    });
}
class BulkActions {
    constructor(document) {
    }
    disableCheckedRecord(id) {
    }
    getCheckedRecordIs() {
        let data = [];
        return data;
    }
    checkAllElements() {
    }
    submitData(id) {
        let submitData = new XMLHttpRequest();
        submitData.open("POST", "");
    }
}
class FieldRules {
    constructor(_appDocument) {
        this._table = document.getElementById('fieldRules');
        this._dataField = document.getElementById('rules');
    }
    getAllRuleIDs() {
        let dataArray = [];
        for (let ruleRow = 1; ruleRow < this._table.rows.length; ruleRow++) {
            let row = this._table.rows.item(ruleRow);
            dataArray.push(row.getAttribute('ruleid'));
        }
        return dataArray;
    }
    addRule(rule, callback) {
        let bodyTable = document.getElementById('rulesBody');
        let ruleid = 'rule' + rule.rule.id;
        bodyTable.innerHTML += '<tr id="' + ruleid + '" ruleid="' + rule.rule.id + '" class="ui-sortable-handle">' + this.getRow(rule, ruleid) + '</tr>';
        callback();
    }
    getRow(rule, ruleid) {
        return '<td><strong>' + rule.ruletype.description + '</strong></td>' +
            '<td>' +
            this.getPerspectivesListElement(rule.rule.id, rule.perspectives) +
            '</td>' +
            '<td>' + rule.rule.description + '</td>' +
            '<td><i class="fa fa-remove fa-lg float-right" onclick="rulesTable.deleteRule(document.getElementById(\'' + ruleid + '\'),getRuleAndPerspectives);"></i></td>';
    }
    getPerspectivesListElement(ruleID, perspectives) {
        let perspectiveList = '';
        perspectives.forEach((perspective) => {
            perspectiveList += '<li persid="' + perspective.id + '"><span class="bullet primary-color"></span>' + perspective.description + '</li>';
        });
        return '<div class="row"> <div class="col-md-10"><ul ruleid="' + ruleID + '" id="perspec' + ruleID + '" name="rulePerspectiveArray">' + perspectiveList + '</ul>' +
            '</div>' +
            '<div class="col-md-1">' +
            '<i class="fa fa-lg fa-pencil float-right" onclick="editPerspective(' + ruleID + ')"></i>' +
            '</div>' +
            '</div>';
    }
    deleteRule(row, callback) {
        this._table.deleteRow(row.rowIndex);
        toastr['success']('Rule deleted successfully.');
        callback();
    }
}
window.rulesTable = new FieldRules(document);
class DsmApplicationBootStrap {
    constructor(_document) {
        this._document = _document;
        let config = document.getElementsByName('config');
        config.forEach(element => {
            eval(element.getAttribute('init'));
            //var func = eval(element.getAttribute('init'));
            this.initAppSearch(element.getAttribute('tbodyid'), element.getAttribute('trowspan'));
        });
    }
    initAppForm() {
        let formList = this._document.forms;
        for (let formitem = 0; formitem < formList.length; formitem++) {
            let form = formList.item(formitem);
            let saveButton = this._document.getElementById(form.getAttribute('data-submitButtonID'));
            let f = new AppForm(form, this._document, saveButton);
        }
    }
    initAppTable() {
    }
    initAppSearch(tablebodyid, trowspan) {
        let searchField = this._document.getElementById('searchfield');
        if (searchField != null) {
            let search = new DisplayEngine(searchField, 5, (window.location.origin + window.location.pathname), tablebodyid, trowspan);
        }
    }
    initApplicationNavigationSystem(userState) {
        let sideBar = this._document.getElementById('sidebar');
        let topBar = this._document.getElementById('topbar');
        let navigationPanel = new NavigationPanelControl(sideBar, topBar, this._document, userState);
        window.nav = navigationPanel;
        return navigationPanel;
    }
}
class DisplayEngine {
    constructor(_searchField, _listCount, _pageURL, _tableBodyId, _rowSpan) {
        this._searchField = _searchField;
        this._listCount = _listCount;
        this._pageURL = _pageURL;
        this._tableBodyId = _tableBodyId;
        this._rowSpan = _rowSpan;
        this._searchField.oninput = (e) => {
            this.returnResult(_pageURL + '?filter=' + e.srcElement.value, this.processSearch);
        };
        let paginationSection = document.getElementById('paginationcontrols');
        //this.paginate(paginationSection);
    }
    /*paginate(paginationSection: HTMLUListElement){
        for (var listItemIndex = 0; listItemIndex < paginationSection.children.length; listItemIndex++) {
            var listItem = paginationSection.children[listItemIndex];

            for (var listItemContentIndex = 0; listItemContentIndex < listItem.children.length; listItemContentIndex++) {
                var paginationAnchor: HTMLAnchorElement = <HTMLAnchorElement>listItem.children[listItemContentIndex];
                paginationAnchor.onclick = (e: Event)=>{
                    e.preventDefault();
                    let parameter: HTMLAnchorElement = <HTMLAnchorElement>e.srcElement;
                    
                    if(parameter.href !== '#'){
                        //console.log(parameter.href);
                        this.returnResult(parameter.href,this.processPagination);
                    }
                };
                
            }
        }
    }*/
    processPagination(result) {
        let parser = new DOMParser();
        let parseDocument = parser.parseFromString(result, "text/html");
        let searchresult = parseDocument.getElementById('searchresult');
        document.getElementById('searchresult').innerHTML = searchresult.innerHTML;
    }
    processSearch(result) {
        let parser = new DOMParser();
        let parseDocument = parser.parseFromString(result, "text/html");
        let searchresult = parseDocument.getElementById('searchresult');
        var rowSize = searchresult.rows;
        if (rowSize.length == 0) {
            document.getElementById('searchresult').innerHTML = '<tr><td>No items found</td><tr>';
        }
        else {
            document.getElementById('searchresult').innerHTML = searchresult.innerHTML;
            $('.mdb-select').material_select();
        }
        let paginationSection = parseDocument.getElementById('paginationsection');
        document.getElementById('paginationsection').innerHTML = paginationSection.innerHTML;
    }
    returnResult(url, callback) {
        let xhttp = new XMLHttpRequest();
        xhttp.onreadystatechange = function () {
            if (this.readyState == 4 && this.status == 200) {
                callback(xhttp.responseText);
            }
        };
        xhttp.open('GET', url, true);
        xhttp.send();
    }
}
class DeviceType {
    setMobile() {
    }
    setDesktop() {
    }
}
function validateUser() {
    return new Promise((resolve, reject) => { resolve(); });
}
var DialogType;
(function (DialogType) {
    DialogType[DialogType["MessageDialog"] = 0] = "MessageDialog";
    DialogType[DialogType["ContentDialog"] = 1] = "ContentDialog";
})(DialogType || (DialogType = {}));
window.dialogtype = DialogType;
class DialogEngine {
    constructor(appDocument) {
        this._dialogContainer = document.getElementById('dialogcontainer');
        this._dialogTitleBackground = document.getElementById('dialog-title-background');
        this._dialogTitle = document.getElementById('dialog-title');
        this._dialogContent = document.getElementById('dialog-content');
        this._dialogControl = document.getElementById('dialog-controls');
        this._showButton = document.getElementById('dialog-open');
        this._closeButton = document.getElementById('dialog-close');
        this._dialogControlSection = document.getElementById('dialog-control-section');
    }
    closeDialog(callback, dialogType) {
        this._closeButton.click();
        if (callback != undefined) {
            callback();
        }
    }
    showDialog() {
        this._dialogTitleBackground.classList.remove('primary-colour');
        this._showButton.click();
    }
    clearChildSection() {
        this._dialogControlSection.innerHTML = '';
    }
    showCustomDialog(title, controls, content) {
        this.clearChildSection();
        this._dialogTitleBackground.classList.add('primary-color');
        //this._dialogContent.innerHTML = content;
        this._dialogTitle.innerHTML = title;
        /*this.createButton({
            actionTitle: 'Close',
            action: () => {
                this.closeDialog();
            },
            actionStyle: 'dsm-skin-primary-color-dark'
        });*/
        this.showDialog();
    }
    showInfoDialog(title, content) {
        this.clearChildSection();
        this._dialogTitleBackground.classList.add('primary-color');
        this._dialogContent.innerHTML = content;
        this._dialogTitle.innerHTML = title;
        this.createButton({
            actionTitle: 'Close',
            action: () => {
                this.closeDialog();
            },
            actionStyle: 'dsm-skin-primary-color-dark'
        });
        this.showDialog();
    }
    showDangerDialog(title, content) {
        this.clearChildSection();
        this._dialogContent.innerHTML = content;
        this._dialogTitle.innerHTML = title;
        this._dialogTitleBackground.classList.add('error');
        /*this.createButton({
            actionTitle: 'Close',
            action: () => {
                this.closeDialog();
            },
            actionStyle: 'error-button'
        });
*/
        this._dialogControlSection.innerHTML = '<a id="closedialog" onclick="dialog.closeDialog();" class="btn error waves-effect waves-light">Close</a>';
        this.showDialog();
    }
    shrinkDialog() {
        this._dialogContainer.classList.remove('modal-lg');
    }
    growDialog() {
        this._dialogContainer.classList.add('modal-lg');
    }
    showSuccessDialog(title, content) {
        this.clearChildSection();
        this._dialogContent.innerHTML = content;
        this._dialogTitle.innerHTML = title;
        this._dialogTitleBackground.classList.add('error');
        this.createButton({
            actionTitle: 'Close',
            action: () => {
                this.closeDialog();
            },
            actionStyle: 'error-button'
        });
        this.showDialog();
    }
    showWarningDialog(title, controls, content) {
        this.clearChildSection();
        this._dialogTitleBackground.classList.add('primary-color');
        this._dialogContent.innerHTML = content;
        this._dialogTitle.innerHTML = title;
        this.createButton({
            actionTitle: 'Close',
            action: () => {
                this.closeDialog();
            },
            actionStyle: 'dsm-skin-primary-color-dark'
        });
        this.showDialog();
    }
    createButton(buttonMetaData) {
        let button = appDocument.createElement('button');
        button.innerHTML = buttonMetaData.actionTitle;
        button.classList.add('btn');
        button.classList.add(buttonMetaData.actionStyle);
        button.classList.add('waves-effect');
        button.classList.add('waves-light');
        button.onclick = buttonMetaData.action;
        this._dialogControl.appendChild(button);
    }
    displayErrorMessage(error) {
        if (error.output == 'dialog') {
            switch (error.type) {
                case 'info':
                    this.showInfoDialog(error.title, error.message);
                    break;
                case 'warning':
                    this.showWarningDialog(error.title, error.message);
                    break;
                case 'success':
                    this.showSuccessDialog(error.title, error.message);
                    break;
                case 'error':
                    this.showDangerDialog(error.title, error.message);
                    break;
            }
        }
        else {
            toastr[error.type](error.message);
        }
    }
}
window.dialog = new DialogEngine(document);
class NavigationPanelControl {
    constructor(_sideBar, _topBar, _document, _userState) {
        this._sideBar = _sideBar;
        this._topBar = _topBar;
        this._document = _document;
        this._userState = _userState;
        this._mainSection = this._document.getElementsByTagName('main')[0];
        this._content = this._document.getElementById('content');
        this._sideBar.style.marginTop = this._topBar.clientHeight + 'px';
        this._mainSection = this._document.getElementsByTagName('main')[0];
        this._content = this._document.getElementById('content');
        this._toggleButtonSection = this._document.getElementById('toggleButtonSection');
        this._togglebutton = this._document.getElementById('drawertoggle');
        let title = this._document.getElementById('title');
        this._togglebutton.onclick = (e) => {
            let sourceButton = e.srcElement;
            if (sourceButton.getAttribute('toggle') == 'true') {
                this.showSidebar();
                sourceButton.classList.add('nav-menu-button');
                //this._togglebutton.classList.remove('full-body');
                //title.classList.remove('full-body-title');
                sourceButton.setAttribute('toggle', 'false');
            }
            else {
                this.hideSidebar();
                sourceButton.classList.remove('nav-menu-button');
                //this._togglebutton.classList.add('full-body');
                //title.classList.add('full-body-title');
                sourceButton.setAttribute('toggle', 'true');
            }
        };
        let menuItems = document.getElementsByName('menu-item');
        menuItems.forEach((menuItem) => {
            menuItem.onclick = () => {
                this._togglebutton.click();
            };
        });
        this.manageNavigationScreen();
    }
    manageNavigationScreen() {
        if (this._userState == '') {
            this.hideDrawerButton();
            this._content.style.marginLeft = '-240px';
            $('#' + this._togglebutton.id).remove();
        }
        else {
            this.showSidebar();
            this.showDrawerButton();
            this._topBar.classList.remove('hiddendiv');
            //this.showTopbar();
        }
    }
    showDrawerButton() {
        this._toggleButtonSection.classList.remove('hiddendiv');
    }
    hideDrawerButton() {
        this._toggleButtonSection.classList.add('hiddendiv');
    }
    showSidebar() {
        this._sideBar.classList.remove('hiddendiv');
        this._content.classList.remove('full-body');
    }
    hideSidebar() {
        this._sideBar.classList.add('hiddendiv');
        this._content.classList.add('full-body');
    }
    showTopbar() {
        this._content.classList.remove('topbar-full');
        this._topBar.classList.remove('hiddendiv');
    }
    hideTopbar() {
        this._content.classList.add('topbar-full');
        this._topBar.classList.add('hiddendiv');
    }
}
class AppForm {
    constructor(_form, applicationDocument, _submitButton) {
        this._form = _form;
        this.applicationDocument = applicationDocument;
        this._submitButton = _submitButton;
        let dialog = new DialogEngine(applicationDocument);
        /*if (this._form.getAttribute('data-strict-validator') == 'true') {
            if (this._form.checkValidity()) {
                this._submitButton.disabled = false;
            } else {
                this._submitButton.disabled = true;
            }

            this._form.onchange = (e: Event) => {
                if (this._form.checkValidity()) {
                    this._submitButton.disabled = false;
                } else {
                    this._submitButton.disabled = true;
                }
            };
        }*/
        if (this._form.getAttribute('data-submitButtonID') != null) {
            this._submitButton.onclick = (e) => {
                if (this._form.getAttribute('presubmit') != null) {
                    var func = eval(this._form.getAttribute('presubmit'));
                    func.then(() => {
                        this._form.submit();
                    }).catch((error) => {
                        dialog.displayErrorMessage(error);
                    });
                }
                else {
                    this._form.submit();
                }
            };
        }
        let childInputs = _form.elements;
        for (let formInput = 0; formInput < childInputs.length; formInput++) {
            new Input(childInputs.item(formInput), this.applicationDocument, this._form);
        }
    }
}
class MultipleSelect {
    constructor(applicationDocument, _checkBoxIds) {
        this._checkBoxIds = _checkBoxIds;
    }
    getCheckedCheckBoxes() {
        let checkedCheckBox = [];
        this._checkBoxIds.forEach((checkboxid) => {
            let checkbox = document.getElementById(checkboxid);
            if (checkbox.checked) {
                checkedCheckBox.push(checkbox);
            }
        });
        return checkedCheckBox;
    }
    setCheckbox() {
    }
}
class Input {
    constructor(_inputField, _applicationDocument, _form) {
        this._inputField = _inputField;
        this._applicationDocument = _applicationDocument;
        this._form = _form;
        this.addValidityHandler(_inputField);
        this._inputFieldLabel = document.getElementById('l' + this._inputField.id);
        if (this._form.getAttribute('data-indicator') == 'true') {
            this.addRequired(_inputField);
        }
        _inputField.oninput = (e) => {
            let source = e.srcElement;
            _inputField.classList.remove('invalid');
            _inputField.classList.remove('valid');
            if (source.value == '') {
                this.removeMessageFromLabel(source);
            }
            else {
                this.addMessageToLabel(source);
            }
        };
        _inputField.oninvalid = (e) => {
            let source = e.srcElement;
            source.classList.add('invalid');
            if (source.value == '') {
                this.removeMessageFromLabel(source);
            }
        };
        _inputField.onfocus = () => {
            _inputField.classList.remove('invalid');
            _inputField.classList.remove('valid');
            this._inputFieldLabel.removeAttribute('style');
        };
        _inputField.onblur = (e) => {
            let source = e.srcElement;
            _inputField.checkValidity();
            if (_inputField.value != '') {
                this.addMessageToLabel(this._inputField);
            }
            if (this._form.getAttribute('data-indicator') == 'false') {
                _inputField.classList.remove('invalid');
                _inputField.classList.remove('valid');
            }
        };
    }
    addValidityHandler(input) {
        if (input.classList.contains('validate')) {
            this.addMessageToLabel(input);
            input.oninvalid = (e) => {
                e.preventDefault();
                let source = e.srcElement;
                source.classList.add('invalid');
            };
        }
    }
    addRequired(inputField) {
        if (inputField.getAttribute('required') == '') {
            this._inputFieldLabel.innerHTML = this._inputFieldLabel.innerHTML.concat('<span style="color: red;"> *<span>');
            this._inputFieldLabel.setAttribute('data-error', 'Please fill in this field.');
        }
    }
    addMessageToLabel(inputField) {
        if (this._inputFieldLabel != null) {
            this._inputFieldLabel.setAttribute('data-error', error.input[inputField.type]);
        }
    }
    removeMessageFromLabel(inputField) {
        if (this._inputFieldLabel != null) {
            this._inputFieldLabel.setAttribute('data-error', '');
        }
    }
}
class dragAndDropImplementation {
    constructor(_document) {
        this._document = _document;
    }
    setDragAndDroppable(ulList) {
        let list = document.getElementById(ulList);
        for (let listitem = 0; listitem < list.children.length; listitem++) {
            let listItem = list.children.item(listitem);
            $('#' + listItem.id).draggable();
        }
    }
}
window.draganddrop = new dragAndDropImplementation(document);
function checkFormValidity(elementId) {
    return new Promise((resolve, reject) => {
        let form = document.getElementById(elementId);
        if (form.checkValidity()) {
            resolve();
        }
        else {
            reject(error.form.formerror);
        }
    });
}
function validateForm(elementId, callback) {
    return new Promise((resolve, reject) => {
        if (callback != undefined) {
            checkFormValidity(elementId).then(() => {
                return callback();
            }).then(() => {
                resolve();
            }).catch((error) => {
                reject(error);
            });
        }
        else {
            checkFormValidity(elementId).then(() => {
                resolve();
            }).catch((error) => {
                reject(error);
            });
        }
    });
}
class DataTable {
    constructor() {
    }
    setTableSearchable(tableId, searchFieldId) {
        this._dataTable = $('#' + tableId).DataTable({
            paging: true,
            searching: true,
            select: true,
            info: false,
            scrollx: false,
            iDisplayLength: 5
        });
        document.getElementById(tableId + '_filter').classList.add('hiddendiv');
        document.getElementById(tableId + '_length').classList.add('hiddendiv');
        let searchField = document.getElementById(searchFieldId);
        searchField.oninput = () => {
            this._dataTable.search(searchField.value).draw();
        };
        this._paginatePrevious = document.getElementById(tableId + '_previous');
        this._paginateNext = document.getElementById(tableId + '_next');
    }
}
window.mainTable = new DataTable();
window.toggleSelect = function (checkboxName, state) {
    var checkboxes = document.getElementsByName(checkboxName);
    checkboxes.forEach((checkbox) => {
        checkbox.checked = state;
    });
};
function setDualColumn(tableId) {
    var tableBody = '';
    var rowCount = 0;
    let table = document.getElementById(tableId);
    for (let row = 0; row < table.rows.length; row++) {
        var tableRow = table.rows.item(row);
        if (row % 2 == 0) {
            tableBody += '<tr><td><div class="row">' + tableRow.cells[0].innerHTML;
        }
        else {
            tableBody += tableRow.cells[0].innerHTML + '</div></td></tr>';
        }
        rowCount++;
    }
    if (rowCount % 2 == 1) {
        tableBody += '</td></tr>';
    }
    table.innerHTML = tableBody;
}
function checkPasswordStrength(passwordField) {
    return new Promise((resolve, reject) => {
        var password_strength = document.getElementById(passwordField);
        //TextBox left blank.
        /* if (password_strength.value.length == 0) {
            reject(error.form.password.zeroinput)
    
        } */
        //Regular Expressions.
        var regex = new Array();
        regex.push("[A-Z]"); //Uppercase Alphabet.
        regex.push("[a-z]"); //Lowercase Alphabet.
        regex.push("[0-9]"); //Digit.
        regex.push("[$@$!%*#?&]"); //Special Character.
        var passed = 0;
        //Validate for each Regular Expression.
        for (var i = 0; i < regex.length; i++) {
            if (new RegExp(regex[i]).test(password_strength.value)) {
                passed++;
            }
        }
        //Validate for length of Password.
        if (passed == regex.length && password_strength.value.length > 6) {
            resolve();
        }
        else {
            reject(error.form.password.failedpassword);
        }
    });
}
function checkPasswordValueStrength(password) {
    return new Promise((resolve, reject) => {
        //TextBox left blank.
        /* if (password_strength.value.length == 0) {
            reject(error.form.password.zeroinput)
    
        } */
        //Regular Expressions.
        var regex = new Array();
        regex.push("[A-Z]"); //Uppercase Alphabet.
        regex.push("[a-z]"); //Lowercase Alphabet.
        regex.push("[0-9]"); //Digit.
        regex.push("[$@$!%*#?&]"); //Special Character.
        var passed = 0;
        //Validate for each Regular Expression.
        for (var i = 0; i < regex.length; i++) {
            if (new RegExp(regex[i]).test(password)) {
                passed++;
            }
        }
        //Validate for length of Password.
        if (passed == regex.length && password.length > 6) {
            resolve();
        }
        else {
            reject(error.form.password.failedpassword);
        }
    });
}
function confirmationDialog(titlename, href) {
    dialog._dialogTitleBackground.classList.add('warn-skin');
    dialog._dialogTitle.innerText = 'Delete';
    dialog._dialogContent.innerText = "Are  you sure you want to delete '" + titlename + "'?";
    dialog.showDialog();
    return new Promise((resolve, reject) => {
        var deleteButton = document.getElementById('delete');
        deleteButton.onclick = () => {
            //resolve();
            window.location = href;
            console.log('deleted');
        };
    });
}
function showAboutDialog() {
    dialog.showDialog();
}
function callAPI(endpoint, callback) {
    let getFields = new XMLHttpRequest();
    getFields.onreadystatechange = function () {
        if (this.readyState == 4 && this.status == 200) {
            // Typical action to be performed when the document is ready:
            callback(JSON.parse(getFields.responseText));
        }
    };
    getFields.open("GET", window.location.origin + '/api/' + endpoint);
    getFields.send();
}
//# sourceMappingURL=app.js.map