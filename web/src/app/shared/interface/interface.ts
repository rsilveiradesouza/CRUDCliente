export interface Cliente {
    id: string | null;
    nome: string;
    cpf: string;
    email: string | null;
    celular: string | number;
}

export interface AdicionarClienteDto {
    id: string;
}

export interface EditarClienteDto {
    id: string;
}