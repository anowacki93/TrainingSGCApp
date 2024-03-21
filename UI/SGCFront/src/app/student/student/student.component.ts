import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { StudentService } from '../service/student.service';

@Component({
  selector: 'app-student',
  templateUrl: './student.component.html',
  styleUrls: ['./student.component.css']
})
export class StudentComponent {
  studentForm: FormGroup;

  constructor(private fb: FormBuilder, private studentService: StudentService) {
    this.studentForm = this.fb.group({
      firstname: ['', Validators.required],
      lastname: ['', Validators.required],
      age: ['', Validators.required]
    });
  }

  onSubmit() {
    if (this.studentForm.valid) {
      this.studentService.createStudent(this.studentForm.value).subscribe(
        response => {
          console.log(response);
          // Obsłuż odpowiedź z serwera
        },
        error => {
          console.error(error);
          // Obsłuż błędy
        }
      );
    }
  }
}
