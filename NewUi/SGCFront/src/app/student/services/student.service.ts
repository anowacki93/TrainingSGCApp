import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Student } from '../models/student.model'; // Import the Student model

@Injectable({
  providedIn: 'root'
})
export class StudentService {
  private apiUrl = 'https://localhost:44329/student';

  constructor(private http: HttpClient) { }

  createStudent(studentData: Student): Observable<Student> { // Update parameter and return type
    return this.http.post<Student>(`${this.apiUrl}/create`, studentData);
  }

  getAllStudents(): Observable<Student[]> {
    return this.http.get<Student[]>(`${this.apiUrl}/getall`);
  }
}
