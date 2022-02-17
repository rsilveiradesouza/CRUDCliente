import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgxMaskModule } from 'ngx-mask';

import { HttpClientModule } from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { AjaxService } from 'src/app/shared/services/ajax.service';
import { ClienteService } from 'src/app/shared/services/cliente.service';
import { InputComponent } from './components/input/input.component';

@NgModule({
  declarations: [
    InputComponent
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    HttpClientModule,
    FormsModule,
    NgxMaskModule.forRoot()
  ],
  exports: [
    InputComponent,
    CommonModule,
    ReactiveFormsModule,
    HttpClientModule,
    FormsModule,
    NgxMaskModule
  ],
  providers: [
    AjaxService,
    ClienteService
  ],
  bootstrap: []
})
export class SharedModule { }
