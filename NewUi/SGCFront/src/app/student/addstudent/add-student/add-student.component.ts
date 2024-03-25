import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { StudentService } from '../../services/student.service';
import { StudentModel } from '../../models/student.model'; // Import the Student model

@Component({
  selector: 'app-student',
  templateUrl: './add-student.component.html',
  styleUrls: ['./add-student.component.css']
})
export class AddStudentComponent {
  studentForm: FormGroup;

  constructor(private fb: FormBuilder, private studentService: StudentService) {
    this.studentForm = this.fb.group({
      firstName: ['', Validators.required], // Update form control names
      lastName: ['', Validators.required],
      age: ['', Validators.required]
    });
  }

  onSubmit() {
    if (this.studentForm.valid) {
      const studentData: StudentModel = this.studentForm.value; // Convert form value to Student object
      this.studentService.createStudent(studentData).subscribe(
        response => {
          console.log(response);
          // Handle response from the server
          this.studentForm.reset();
        },
        error => {
          console.error(error);
          // Handle errors
        }
      );
    }
  }
}
