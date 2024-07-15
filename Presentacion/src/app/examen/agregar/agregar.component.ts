import { Component } from '@angular/core';
import { ExamenService } from '../examen.service';

@Component({
  selector: 'app-agregar',
  templateUrl: './agregar.component.html',
  styleUrl: './agregar.component.css'
})
export class AgregarComponent {
  constructor(private examenService: ExamenService) { }

  nombre: string = '';
  descripcion: string = '';
  metodo: boolean = false;

  agregar() {
    this.examenService.postExamen(this.nombre, this.descripcion, this.metodo)
  }

}
