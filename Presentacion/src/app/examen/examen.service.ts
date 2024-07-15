import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environment/environment';
import { Consultar } from './interfaces/consultar';

@Injectable({
  providedIn: 'root'
})
export class ExamenService {

  baseUrl: string = environment.apiUrl;
  examenUrl: string = `${this.baseUrl}examen`;
  resultados: Consultar[] = [];

  constructor(private http: HttpClient) { }

  getExamenes(nombre: string, descripcion: string, metodo: boolean) {
    let params = {
      nombre: nombre,
      descripcion: descripcion,
      metodo: metodo.toString()
    };

    return this.http.get<Consultar[]>(this.examenUrl, { params })
  }

  deleteExamen(idExamen: number, metodo: boolean) {
    let params = {
      metodo: metodo.toString(),
      idExamen: idExamen
    };

    this.http.delete(this.examenUrl, { params })
      .subscribe((response: any) => {        
        return response;
      });
  }

  postExamen(nombre: string, descripcion: string, metodo: boolean) {
    let body = {
      nombre: nombre,
      descripcion: descripcion,
      metodo: metodo
    };

    this.http.post(this.examenUrl, body)
      .subscribe((response: any) => {
        return response;
      });
  }

  updateExamen(idExamen: number, nombre: string, descripcion: string, metodo: boolean) {
    let body = {
      idExamen: idExamen,
      nombre: nombre,
      descripcion: descripcion,
      metodo: metodo
    };

    this.http.put(this.examenUrl, body)
      .subscribe((response: any) => {
        return response;
      });
  }
}