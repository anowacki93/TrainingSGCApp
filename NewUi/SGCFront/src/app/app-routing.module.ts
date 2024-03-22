import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { StudentComponent } from './student/student/student.component';

const routes: Routes = [
  { path: 'student/create', component: StudentComponent },
  // Dodaj inne trasy tutaj, jeśli są potrzebne
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
