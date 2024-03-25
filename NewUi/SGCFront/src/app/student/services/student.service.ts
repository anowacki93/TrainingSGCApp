import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { StudentModel } from '../models/student.model';
import { UpdateStudentRequest } from '../models/update-student-request.model';

@Injectable({
  providedIn: 'root'
})
export class StudentService {
  private apiUrl = 'https://localhost:44329/student';

  constructor(private http: HttpClient) { }

  createStudent(studentData: StudentModel): Observable<StudentModel> { // Update parameter and return type
    return this.http.post<StudentModel>(`${this.apiUrl}/create`, studentData);
  }

  getAllStudents(): Observable<StudentModel[]> {
    return this.http.get<StudentModel[]>(`${this.apiUrl}/getall`);
  }

  getStudentById(id: string): Observable<StudentModel> {
    return this.http.get<StudentModel>(`${this.apiUrl}/get/${id}`);
  }

  updateStudent(id: string, updateStudentRequest: UpdateStudentRequest): Observable<StudentModel> {
    return this.http.put<StudentModel>(`${this.apiUrl}/edit/${id}`, updateStudentRequest);
  }

  deleteStudent(id: string): Observable<StudentModel> {
    return this.http.delete<StudentModel>(`${this.apiUrl}/delete/${id}`);
  }
}
