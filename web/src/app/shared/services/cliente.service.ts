import { Injectable } from '@angular/core';
import { AdicionarClienteDto, Cliente, EditarClienteDto } from '../interface/interface';
import { AjaxService } from './ajax.service';

@Injectable({ providedIn: 'root' })
export class ClienteService {
    constructor(private ajaxService: AjaxService) { }

     obterClientes(): Promise<Cliente[]> {
        return this.ajaxService.get<Cliente[]>("clientes");
    }

    async adicionarCliente(data: Cliente): Promise<AdicionarClienteDto> {
        return await this.ajaxService.post<AdicionarClienteDto>("clientes", data);
    }

    async editarCliente(data: Cliente): Promise<EditarClienteDto> {
        return await this.ajaxService.put<EditarClienteDto>("clientes", data);
    }

    async removerCliente(id: string | null): Promise<void> {
        return await this.ajaxService.delete<void>("clientes/" + id);
    }

    async obterCliente(id: string): Promise<Cliente> {
        return await this.ajaxService.get<Cliente>("clientes/" + id);
    }
}