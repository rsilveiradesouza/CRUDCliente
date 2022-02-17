import { Injectable } from '@angular/core';
import { AbstractControl, ValidationErrors } from '@angular/forms';
import { cpf } from 'cpf-cnpj-validator';

@Injectable()
export class CustomValidator {
    static emailRegex = /^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$/;
    static celRegex = /(^\d{11}$)|(^$)/;

    /* Validador de CPF sem máscara */
    static cpf(control: AbstractControl): ValidationErrors | null {
        if (control.value && control.value.length < 11) {
            return { 'cpf': 'Formato do CPF inválido.' };
        }
        if (!cpf.isValid(control.value)) {
            return { 'cpf': 'CPF Inválido' };
        }
        return null;
    }

    /* Validador de email */
    static email(control: AbstractControl): ValidationErrors | null {
        if (!(CustomValidator.emailRegex.test(control.value)) && control.value) {
            return { 'email': 'E-mail inválido' };
        }
        return null;
    }

    /* Validador de celular */
    static cel(control: AbstractControl): ValidationErrors | null {
        if (!(CustomValidator.celRegex.test(control.value))) {
            return { 'cel': 'Celular inválido' };
        }
        return null;
    }

    /* Validador de campo preenchido */
    static required(control: AbstractControl): ValidationErrors | null {
        const value = control.value;
        if ((value && value?.toString().trim() === '') || value === null || value === undefined || value === '') { return { 'required': 'O campo é obrigatório' }; }
        return null;
    }
}
