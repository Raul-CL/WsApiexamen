import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ActualizarComponent } from './actualizar/actualizar.component';
import { AgregarComponent } from './agregar/agregar.component';
import { ConsultarComponent } from './consultar/consultar.component';
import { EliminarComponent } from './eliminar/eliminar.component';
import { ExamenService } from './examen.service';
import { MaterialModule } from '../material/material.module';





@NgModule({
  declarations: [
    ActualizarComponent,
    AgregarComponent,
    ConsultarComponent,
    EliminarComponent
  ],
  imports: [
    CommonModule,
    MaterialModule
  ],
  exports: [
    ActualizarComponent,
    AgregarComponent,
    ConsultarComponent,
    EliminarComponent
  ],
  providers: [
    ExamenService
  ]
})
export class ExamenModule { }
