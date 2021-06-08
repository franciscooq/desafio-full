import { Component, OnInit } from '@angular/core';
import { TituloService } from '../titulo.service';
import { TituloModel } from './titulo.model';

@Component({
  selector: 'app-titulo',
  templateUrl: './titulo.component.html',
  styleUrls: ['./titulo.component.css']
})
export class TituloComponent implements OnInit {

  titulo: TituloModel = new TituloModel();
  titulos: Array<any> = Array();

  constructor(private tituloService: TituloService) { }

  ngOnInit(): void {
    this.listarTitulos();
  }

  cadastrar(){
    console.log(this.titulo);
    this.tituloService.cadastrarTitulo(this.titulo).subscribe(titulo => {
      console.log(titulo);
      this.titulo = new TituloModel();
      this.listarTitulos();
    }, err =>{ 
      console.log('Erro ao Cadastrar Titulos: ', err);
    });
  }

  listarTitulos(){
    this.tituloService.listarTitulos().subscribe(titulos => {
      console.log(titulos);
      this.titulos = titulos;

    }, err =>{ 
      console.log('Erro ao listar Titulos: ', err);
    });
  }

}
