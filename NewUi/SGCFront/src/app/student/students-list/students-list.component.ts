import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { StudentService } from '../services/student.service';
import { Student } from '../models/student.model';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'students-list',
  templateUrl: './students-list.component.html',
  styleUrl: './students-list.component.css'
})
export class StudentsListComponent implements OnInit{

  students$?: Observable<Student[]>;

  constructor(private studentService: StudentService){

  }
  ngOnInit(): void {
    this.students$ = this.studentService.getAllStudents();
  }

}
