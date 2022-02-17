import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Cliente } from 'src/app/shared/interface/interface';
import { ClienteService } from 'src/app/shared/services/cliente.service';
import { CustomValidator } from 'src/app/shared/services/validator.service';

@Component({
  selector: 'app-adicionar-editar-cliente',
  templateUrl: 'adicionar-editar-cliente.page.html'
})

export class AdicionarEditarClientePage implements OnInit {

  public loading = false;
  public loadingButton = false;
  public form = new FormGroup({
    nome: new FormControl('', [CustomValidator.required]),
    cpf: new FormControl('', [CustomValidator.required, CustomValidator.cpf]),
    celular: new FormControl('', [CustomValidator.cel]),
    email: new FormControl('', [CustomValidator.email])
  });
  public id: string | undefined;
  public ehEdicao = false;
  public cliente: Cliente | undefined;

  constructor(private clienteService: ClienteService, private route: ActivatedRoute, private router: Router, private toastr: ToastrService) { }

  async ngOnInit(): Promise<void> {
    this.ehEdicao = this.route.snapshot.data['edit'];
    if (this.ehEdicao) {
      const id = this.route.snapshot.paramMap.get('id') as string;

      this.obterCliente(id).then((cliente) => {
        this.id = cliente.id!;
        this.form.patchValue({
          nome: cliente.nome,
          cpf: cliente.cpf,
          celular: cliente.celular,
          email: cliente.email,
        })
      }).catch(() => {
        this.toastr.error('Cliente não encontrado.', 'Erro!');
        this.router.navigateByUrl('/clientes');
      }).finally(() => {
        this.loadingButton = false;
      });
    }
  }

  async obterCliente(id: string): Promise<Cliente> {
    return await this.clienteService.obterCliente(id);
  }

  async adicionarCliente(): Promise<void> {
    if (this.form.invalid) {
      this.exibirErros();
      return;
    }
    this.loadingButton = true;
    const data = {
      id: null,
      nome: this.form.value.nome,
      cpf: this.form.value.cpf,
      celular: this.form.value.celular,
      email: this.form.value.email,
    }

    this.clienteService.adicionarCliente(data).then(() => {
      this.toastr.success('Cliente adicionado com sucesso!', 'Adicionado!');
      this.router.navigateByUrl('/clientes');
    }).catch((response) => {
      this.toastr.error(response.error.errors.message, 'Erro!');
    }).finally(() => {
      this.loadingButton = false;
    });

  }

  async editarCliente(): Promise<void> {
    if (this.form.invalid) {
      this.exibirErros();
      return;
    }
    this.loadingButton = true;
    const data = {
      id: this.id!,
      nome: this.form.value.nome,
      cpf: this.form.value.cpf,
      celular: this.form.value.celular,
      email: this.form.value.email,
    }

    this.clienteService.editarCliente(data).then(() => {
      this.toastr.success('Cliente editado com sucesso!', 'Editado!');
      this.router.navigateByUrl('/clientes');
    }).catch((response) => {
      this.toastr.error(response.error.errors.message, 'Erro!');
    }).finally(() => {
      this.loadingButton = false;
    });
  }

  exibirErros(): void {
    for (const key in this.form.controls) {
      this.form.controls[key].markAsDirty();
      this.form.controls[key].markAsTouched();
      this.form.controls[key].updateValueAndValidity();
    }
  }
}