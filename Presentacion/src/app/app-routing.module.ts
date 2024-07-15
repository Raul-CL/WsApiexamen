import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ConsultarComponent } from './examen/consultar/consultar.component';
import { ActualizarComponent } from './examen/actualizar/actualizar.component';
import { AgregarComponent } from './examen/agregar/agregar.component';
import { EliminarComponent } from './examen/eliminar/eliminar.component';

const routes: Routes = [
  {
    path: '', component: ConsultarComponent, pathMatch: 'full'
  },
  {
    path: 'consultar', component: ConsultarComponent
  },
  {
    path: 'actualizar', component: ActualizarComponent
  },
  {
    path: 'agregar', component: AgregarComponent
  },
  {
    path: 'eliminar', component: EliminarComponent
  }

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
