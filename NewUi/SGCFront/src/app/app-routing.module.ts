import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddStudentComponent } from './student/addstudent/add-student/add-student.component';
import { StudentsListComponent } from './student/students-list/students-list.component';
import { EditStudentComponent } from './student/edit-student/edit-student.component';

const routes: Routes = [
  { path: 'student/create', component: AddStudentComponent },
  { path: 'student/getall', component: StudentsListComponent },
  {path: 'student/edit/:id',component: EditStudentComponent},
  // Dodaj inne trasy tutaj, jeśli są potrzebne
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
