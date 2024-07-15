import { Component } from '@angular/core';
import { ExamenService } from '../examen.service';

@Component({
  selector: 'app-actualizar',
  templateUrl: './actualizar.component.html',
  styleUrl: './actualizar.component.css'
})
export class ActualizarComponent {
  constructor(private examenService: ExamenService) { }

  idExamen: number = 0;
  nombre: string = '';
  descripcion: string = '';
  metodo: boolean = false;


  actualizar() {
    this.examenService.updateExamen(this.idExamen, this.nombre, this.descripcion, this.metodo)
  }
}
