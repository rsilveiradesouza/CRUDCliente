import { AfterViewInit, Component, Input, OnInit, Optional, Self } from '@angular/core';
import { AbstractControl, ControlValueAccessor, NgControl } from '@angular/forms';

@Component({
    selector: 'app-input',
    templateUrl: 'input.component.html',
    styleUrls: ['input.component.scss']
})

export class InputComponent implements OnInit, AfterViewInit, ControlValueAccessor {

    public value: string | null | string = '';
    public disabled = false;
    public onChangeFn!: (value: string) => void;
    public onTouched!: () => void;

    @Input() label: string | undefined;
    @Input() type: string | undefined;
    @Input() placeholder = '';

    constructor(@Optional() @Self() public controlDir: NgControl) {
        this.controlDir.valueAccessor = this;
    }

    ngOnInit(): void {
        if (!this.type) { throw new Error('Propriedade [type] é obrigatório!'); }
    }

    ngAfterViewInit(): void {
        this.control.updateValueAndValidity();
    }

    get control(): AbstractControl {
        return this.controlDir.control as AbstractControl;
    }

    writeValue(value: string): void {
        this.value = value;
    }

    registerOnChange(fn: (value: string) => void): void {
        this.onChangeFn = fn;
    }

    registerOnTouched(fn: () => void): void {
        this.onTouched = fn;
    }

    onBlur(): void {
        this.onTouched();
    }

    modelChange(event: string): void {
        this.onChangeFn(event);
    }

    setDisabledState(disabled: boolean): void {
        this.disabled = disabled;
    }

    get hasError(): boolean {
        return this.control.invalid && (this.control.dirty || this.control.touched);
    }

    get errorMessage(): string {
        if (this.control.errors) {
            const keys: string[] = Object.keys(this.control.errors);
            return this.control.errors[keys[0]];
        } else {
            return '';
        }
    }

    get isRequired(): boolean {
        if (this.control.validator) {
            const validator = this.control.validator({} as AbstractControl);
            return validator && validator['required'];
        }
        return false;
    }

    get hasMask(): boolean {
        return this.getMask !== null;
    }

    get getMask(): string {
        switch (this.type) {
            case 'cpf':
                return '000.000.000-00';
            case 'text':
                return '';
            case 'cel':
                return '(00) 00000-0000';
            default:
                return '';
        }
    }

    get getType(): string {
        switch (this.type) {
            case 'cpf':
                return 'tel';
            case 'text':
                return 'text';
            case 'cel':
                return 'tel';
            default:
                return '';
        }
    }
}