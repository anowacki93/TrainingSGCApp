import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { CourseModel } from '../model/course.model';
import { EnrollmentModel } from '../model/course.model';

@Injectable({
  providedIn: 'root'
})
export class CourseService {
  private apiUrl = 'https://localhost:44329/course'; // Updated API URL for courses

  constructor(private http: HttpClient) { }

  // Course-related operations
  createCourse(courseData: CourseModel): Observable<CourseModel> {
    return this.http.post<CourseModel>(`${this.apiUrl}/create`, courseData);
  }

  getAllCourses(): Observable<CourseModel[]> {
    return this.http.get<CourseModel[]>(`${this.apiUrl}/getall`);
  }

  getCourseById(id: string): Observable<CourseModel> {
    return this.http.get<CourseModel>(`${this.apiUrl}/get/${id}`);
  }

  updateCourse(id: string, updatedCourseData: CourseModel): Observable<CourseModel> {
    return this.http.put<CourseModel>(`${this.apiUrl}/edit/${id}`, updatedCourseData);
  }

  deleteCourse(id: string): Observable<any> {
    return this.http.delete<any>(`${this.apiUrl}/delete/${id}`);
  }

  // Enrollment-related operations
  enrollStudentsToCourse(courseId: string, studentIds: string[]): Observable<any> {
    const enrollments = studentIds.map(studentId => ({ studentId, courseId }));
    return this.http.post<any>(`${this.apiUrl}/enroll-students`, enrollments);
  }

  // Additional methods for managing enrollments if needed
}
