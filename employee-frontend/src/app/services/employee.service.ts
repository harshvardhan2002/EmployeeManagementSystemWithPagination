import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable, tap } from 'rxjs';
import { EmployeeDTO } from '../models/employee-dto';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {
  private url='https://localhost:7002/api/Employee'
  constructor(private http:HttpClient) { }

  getEmployees(pageNumber: number, pageSize: number): Observable<any> {
    let params = new HttpParams()
      .set('PageNumber', pageNumber)
      .set('PageSize', pageSize);
  
    return this.http.get<any>(this.url, { params }).pipe(
      tap((response: any) => {
        console.log("Full API Response:", response); // Log the response
      })
    );
  }
  
  


  // Delete employee
  deleteEmployee(id: number): Observable<any> {
    return this.http.delete(`${this.url}/${id}`);
  }
}
