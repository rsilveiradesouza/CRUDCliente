import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Cliente } from 'src/app/shared/interface/interface';
import { ClienteService } from 'src/app/shared/services/cliente.service';
import Swal from 'sweetalert2'

@Component({
    selector: 'app-listar-clientes',
    templateUrl: 'listar-clientes.page.html',
    styleUrls: ['listar-clientes.page.scss']
})

export class ListarClientesPage implements OnInit {

    public clientes: Cliente[] = [];
    public loading = false;
    public loadingAlert = false;

    constructor(private clienteService: ClienteService, private toastr: ToastrService, private router: Router) { }

    async ngOnInit(): Promise<void> {
        this.obterDados();
    }

    async obterDados() {
        this.loading = true;
        this.clientes = await this.clienteService.obterClientes();
        this.loading = false;
    }

    removerCliente(id: string | null) {
        Swal.fire({
            title: 'Remover cliente',
            text: 'Realmente deseja remover o cliente?',
            icon: 'error',
            confirmButtonText: 'Sim',
            cancelButtonText: 'Não',
            showCancelButton: true,
            showLoaderOnConfirm: true,
            preConfirm: () => {
                return this.clienteService.removerCliente(id);
            }
        }).then(response => {
            if (response.isConfirmed) {
                this.toastr.success('Cliente removido com sucesso!', 'Removido!');
                this.obterDados();
            }
        });
    }

    editarCliente(id: string | null) {
        this.router.navigateByUrl(`/clientes/editar-cliente/${id}`);
    }
}