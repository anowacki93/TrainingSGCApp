import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { CourseService } from '../service/course.service';
import { CourseModel } from '../model/course.model';

@Component({
  selector: 'courses-list',
  templateUrl: './course-list.component.html',
  styleUrls: ['./course-list.component.css']
})
export class CoursesListComponent implements OnInit {
  courses$?: Observable<CourseModel[]>;

  constructor(private courseService: CourseService) { }

  ngOnInit(): void {
    this.courses$ = this.courseService.getAllCourses();
  }
}
