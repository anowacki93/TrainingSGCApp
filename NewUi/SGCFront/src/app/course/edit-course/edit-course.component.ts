import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { FormBuilder, FormGroup, FormArray } from '@angular/forms';
import { CourseService } from '../service/course.service';
import { CourseModel } from '../model/course.model';
import { StudentService } from '../../student/services/student.service';
import { StudentModel } from '../../student/models/student.model';

@Component({
  selector: 'app-edit-course',
  templateUrl: './edit-course.component.html',
  styleUrls: ['./edit-course.component.css']
})
export class EditCourseComponent implements OnInit, OnDestroy {

  id: string | null = null;
  paramsSubscription?: Subscription;
  course: CourseModel | undefined;
  allStudents: StudentModel[] = [];
  courseForm: FormGroup;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private courseService: CourseService,
    private studentService: StudentService,
    private fb: FormBuilder
  ) {
    this.courseForm = this.fb.group({
      id: [''],
      name: [''],
      students: this.fb.array([])
    });
  }

  ngOnInit(): void {
    this.loadCourse();
  }

  loadCourse(): void {
    this.route.paramMap.subscribe(params => {
      this.id = params.get('id');
      if (this.id) {
        this.courseService.getCourseById(this.id).subscribe(course => {
          this.course = course;
          this.loadStudents();
        });
      }
    });
  }

  loadStudents(): void {
    this.studentService.getAllStudents().subscribe(students => {
      this.allStudents = students;
      this.initForm();
    });
  }

  initForm(): void {
    if (this.course) {
      this.courseForm.patchValue({
        id: this.course.id,
        name: this.course.name
      });

      const students = this.courseForm.get('students') as FormArray;
      students.clear();

      this.allStudents.forEach((student) => {
        const isChecked = this.isEnrolled(student.id);
        students.push(this.fb.control(isChecked));
      });
    }
  }

  onFormSubmit(): void {
    if (this.courseForm.valid && this.course) {
      // Process form submission here
    }
  }

  onDelete(): void {
    if (this.id) {
      // Process course deletion here
    }
  }

  ngOnDestroy(): void {
    this.paramsSubscription?.unsubscribe();
  }

  isEnrolled(studentId: string): boolean {
    console.log("Student:"+studentId+" Enrolled:"+this.course?.enrollments?.find(enrollment => enrollment.studentId))
    return !!this.course?.enrollments?.find(enrollment => enrollment.studentId === studentId);
  }


  toggleEnrollment(studentId: string, event: any): void {
    const isChecked = event.target.checked;
    const students = this.courseForm.get('students') as FormArray;
    const index = this.allStudents.findIndex(student => student.id === studentId);
    students.at(index).setValue(isChecked);
}

}
