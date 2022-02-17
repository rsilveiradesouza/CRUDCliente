import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { NgxMaskModule } from 'ngx-mask';
import { ToastrModule } from 'ngx-toastr';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { ListarClientesPage } from './listar-clientes/listar-clientes.page';
import { AdicionarEditarClientePage } from './adicionar-editar-cliente/adicionar-editar-cliente.page';
import { ClientesRoutingModule } from './clientes-routing.module';
import { SharedModule } from 'src/app/shared/shared.module';

@NgModule({
  declarations: [
    ListarClientesPage,
    AdicionarEditarClientePage
  ],
  imports: [
    SharedModule,
    ClientesRoutingModule,
  ],
  providers: [],
  bootstrap: []
})
export class ClientesModule { }
