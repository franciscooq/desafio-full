export class TituloModel{
    numeroTitulo!: string;
    clienteDevedor!: ClienteDevedor;
    juros!: string;
    multa!: string;
    parcelas!: Parcelas;
}

class ClienteDevedor{
    nome!: string;
    cpf! : string;
}

class Parcelas{
    numeroParcela!: string;
    dataVencimento!: string;
    valorParcela!: string;
}