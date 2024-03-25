import { NgModule } from '@angular/core';
import { BrowserModule, provideClientHydration } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AddStudentComponent } from './student/addstudent/add-student/add-student.component';
import { HttpClientModule, HttpClient } from '@angular/common/http';
import { StudentsListComponent } from './student/students-list/students-list.component';
import { EditStudentComponent } from './student/edit-student/edit-student.component';
import { AddCourseComponent } from './course/add-course/add-course.component';
import { EditCourseComponent } from './course/edit-course/edit-course.component';
import { CoursesListComponent } from './course/course-list/course-list.component';


@NgModule({
  declarations: [
    AppComponent,
    AddStudentComponent,
    StudentsListComponent,
    EditStudentComponent,
    AddCourseComponent,
    EditCourseComponent,
    CoursesListComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    ReactiveFormsModule
  ],
  providers: [
    provideClientHydration()
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
