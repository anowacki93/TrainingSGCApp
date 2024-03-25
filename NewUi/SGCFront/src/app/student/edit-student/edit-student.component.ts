import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { StudentService } from '../services/student.service';
import { StudentModel } from '../models/student.model';
import { UpdateStudentRequest } from '../models/update-student-request.model';

@Component({
  selector: 'app-edit-student',
  templateUrl: './edit-student.component.html',
  styleUrls: ['./edit-student.component.css']
})
export class EditStudentComponent implements OnInit, OnDestroy {

  id: string | null = null;
  paramsSubscription?: Subscription;
  editStudentSubscription?: Subscription;
  student?: StudentModel;

  constructor(
    private route: ActivatedRoute,
    private studentService: StudentService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.paramsSubscription = this.route.paramMap.subscribe({
      next: (params) => {
        this.id = params.get('id');

        if (this.id) {
          this.studentService.getStudentById(this.id).subscribe({
            next: (response) => {
              this.student = response;
            }
          });
        }
      }
    });
  }

  onFormSubmit(): void {
    if (this.id && this.student) {
      const updateStudentRequest: UpdateStudentRequest = {
        id: this.student.id,
        firstName: this.student.firstName || '',
        lastName: this.student.lastName || '',
        age: this.student.age || 0 // Assuming age is a number
      };
  
      this.editStudentSubscription = this.studentService.updateStudent(this.id, updateStudentRequest).subscribe({
        next: (response) => {
          this.router.navigateByUrl('/students');
        }
      });
    }
  }
  

  onDelete(): void {
    if (this.id) {
      this.studentService.deleteStudent(this.id).subscribe({
        next: (response) => {
          this.router.navigateByUrl('/students');
        }
      });
    }
  }

  ngOnDestroy(): void {
    this.paramsSubscription?.unsubscribe();
    this.editStudentSubscription?.unsubscribe();
  }
}