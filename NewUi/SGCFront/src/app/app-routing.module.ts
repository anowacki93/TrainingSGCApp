import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddStudentComponent } from './student/addstudent/add-student/add-student.component';
import { StudentsListComponent } from './student/students-list/students-list.component';
import { EditStudentComponent } from './student/edit-student/edit-student.component';
import { AddCourseComponent } from './course/add-course/add-course.component';
import { CoursesListComponent } from './course/course-list/course-list.component';
import { EditCourseComponent } from './course/edit-course/edit-course.component';

const routes: Routes = [
  { path: 'student/create', component: AddStudentComponent },
  { path: 'student/getall', component: StudentsListComponent },
  {path: 'student/edit/:id',component: EditStudentComponent},
  { path: 'course/create', component: AddCourseComponent },
  { path: 'course/getall', component: CoursesListComponent },
  { path: 'course/edit/:id', component: EditCourseComponent },
  // Dodaj inne trasy tutaj, jeśli są potrzebne
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
