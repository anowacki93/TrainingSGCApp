import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class StudentService {

  // Aktualizacja ścieżki do backendu
  private apiUrl = 'https://localhost:44329/student/create';

  constructor(private http: HttpClient) { }

  createStudent(studentData: any): Observable<any> {
    // Użyj pełnego adresu backendu
    return this.http.post<any>(this.apiUrl, studentData);
  }
}
