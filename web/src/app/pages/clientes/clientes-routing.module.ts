import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AdicionarEditarClientePage } from './adicionar-editar-cliente/adicionar-editar-cliente.page';
import { ListarClientesPage } from './listar-clientes/listar-clientes.page';

const routes: Routes = [
    { path: '', component: ListarClientesPage},
    { path: 'adicionar-cliente', component: AdicionarEditarClientePage, data: {edit: false}},
    { path: 'editar-cliente/:id', component: AdicionarEditarClientePage, data: {edit: true}},
];
@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class ClientesRoutingModule { }
