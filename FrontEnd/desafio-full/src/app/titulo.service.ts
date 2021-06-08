import { Injectable } from '@angular/core';

import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { TituloModel } from './titulo/titulo.model';


import { environment } from './../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class TituloService {

  constructor(private http: HttpClient) { }

  cadastrarTitulo(titulo: TituloModel) : Observable<any>{
    return this.http.post(environment.apiUrl,titulo);
  }

  listarTitulos() : Observable<any>{
    //header("Access-Control-Allow-Origin", "*")
    return this.http.get(environment.apiUrl);
  }

}