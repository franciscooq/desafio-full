import { Injectable } from '@angular/core';

import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class TituloService {

  constructor(private http: HttpClient) { }

  listarTitulos() : Observable<any>{
    //header("Access-Control-Allow-Origin", "*")
    return this.http.get("http://localhost:23673/Titulo");
  }

}