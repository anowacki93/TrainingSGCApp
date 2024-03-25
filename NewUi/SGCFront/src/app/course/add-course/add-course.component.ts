import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators, FormArray, FormControl } from '@angular/forms';
import { CourseService } from '../service/course.service';
import { StudentService } from '../../student/services/student.service';
import { CourseModel } from '../model/course.model';
import { StudentModel } from '../../student/models/student.model';

@Component({
  selector: 'app-course',
  templateUrl: './add-course.component.html',
  styleUrls: ['./add-course.component.css']
})
export class AddCourseComponent implements OnInit {
  courseForm: FormGroup;
  students: StudentModel[] = [];

  constructor(
    private fb: FormBuilder,
    private courseService: CourseService,
    private studentService: StudentService
  ) {
    this.courseForm = this.fb.group({
      name: ['', Validators.required],
      studentControls: this.fb.array([]) // Array to store student form controls
    });
  }

  ngOnInit() {
    this.loadStudents();
  }

  loadStudents() {
    this.studentService.getAllStudents().subscribe(
      students => {
        this.students = students;
        const studentControls = this.students.map(student => this.fb.control(false));
        this.courseForm.setControl('studentControls', this.fb.array(studentControls));
      },
      error => {
        console.error(error);
        // Handle errors
      }
    );
  }

  onSubmit() {
    if (this.courseForm.valid) {
      const courseData: CourseModel = this.courseForm.value; // Convert form value to CourseModel object
      const selectedStudentIds = this.getSelectedStudentIds(); // Get selected student IDs
      courseData.enrollments = selectedStudentIds.map(studentId => ({
        studentId,
        courseId: '000', // Set the courseId appropriately
        grade: 0 // Set the default grade if needed
      }));
      console.log('Course Data with Enrollments:', courseData); // Log course data for debugging
      // Now, send the course data to the backend
      this.courseService.createCourse(courseData).subscribe(
        response => {
          console.log(response);
          // Handle response from the server
          this.courseForm.reset();
        },
        error => {
          console.error(error);
          // Handle errors
        }
      );
    }
  }
  
  
  getSelectedStudentIds(): string[] {
    const selectedStudentIds: string[] = [];
    const studentControls = this.courseForm.get('studentControls') as FormArray;
    studentControls.controls.forEach((control, index) => {
      if (control.value) {
        selectedStudentIds.push(this.students[index].id);
      }
    });
    return selectedStudentIds;
  }
  

  getStudentControl(index: number): FormControl {
    const studentControls = this.courseForm.get('studentControls') as FormArray;
    return studentControls.at(index) as FormControl;
  }
  
  
}
