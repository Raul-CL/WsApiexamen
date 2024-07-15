import { Component } from '@angular/core';
import { ExamenService } from '../examen.service';

@Component({
  selector: 'app-eliminar',
  templateUrl: './eliminar.component.html',
  styleUrl: './eliminar.component.css'
})
export class EliminarComponent {

  constructor(private examenService: ExamenService) { }

  idExamen: number = 0;
  metodo: boolean = false;

  borrar() {
    this.examenService.deleteExamen(this.idExamen, this.metodo)  
  }

}
