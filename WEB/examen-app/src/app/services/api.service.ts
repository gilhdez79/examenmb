import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders  } from '@angular/common/http';
import { Observable } from 'rxjs';
import {environment} from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ApiService {
API_URL = environment.apiUrl;
  constructor(private http: HttpClient) { }

      headersGet = new HttpHeaders({
      'Content-Type': 'application/json',
      'Access-Control-Allow-Headers': 'Content-Type',
      'Access-Control-Allow-Methods': 'GET',
      'Access-Control-Allow-Origin': '*'
    });
          headersPost = new HttpHeaders({
      'Content-Type': 'application/json',
   
      'Access-Control-Allow-Origin': '*'
    });
        
    // Métodos genéricos para usuarios, proyectos y tareas:
  get(endpoint: string): Observable<any>     { return this.http.get(`${this.API_URL}/${endpoint}`); }
  post(endpoint: string, data: any): Observable<any>   { return this.http.post(`${this.API_URL}/${endpoint}`, data, {headers:this.headersPost}); }
  put(endpoint: string, id: number, data: any): Observable<any>   { return this.http.put(`${this.API_URL}/${endpoint}/${id}`, data); }
  delete(endpoint: string, id: number): Observable<any>   { return this.http.delete(`${this.API_URL}/${endpoint}/${id}`); }
}
