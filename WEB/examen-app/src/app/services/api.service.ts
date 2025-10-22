import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ApiService {
API_URL = 'http://localhost:3000/api';
  constructor(private http: HttpClient) { }
    // Métodos genéricos para usuarios, proyectos y tareas:
  get(endpoint: string): Observable<any>     { return this.http.get(`${this.API_URL}/${endpoint}`); }
  post(endpoint: string, data: any): Observable<any>   { return this.http.post(`${this.API_URL}/${endpoint}`, data); }
  put(endpoint: string, id: number, data: any): Observable<any>   { return this.http.put(`${this.API_URL}/${endpoint}/${id}`, data); }
  delete(endpoint: string, id: number): Observable<any>   { return this.http.delete(`${this.API_URL}/${endpoint}/${id}`); }
}
