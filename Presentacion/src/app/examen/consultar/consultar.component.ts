import { Component, OnInit } from '@angular/core';
import { ExamenService } from '../examen.service';
import { Consultar } from '../interfaces/consultar';

@Component({
  selector: 'app-consultar',
  templateUrl: './consultar.component.html',
  styleUrl: './consultar.component.css'
})
export class ConsultarComponent {

  resultados: Consultar[] = [];
  nombre: string = '';
  descripcion: string = '';
  metodo: boolean = false;

  constructor(private examenService: ExamenService) { }

  resultado() {
    this.examenService.getExamenes(this.nombre, this.descripcion, this.metodo)
    .subscribe((response: any) => {
        this.resultados = response;
        this.examenService.resultados = response;
      });
  }
}
