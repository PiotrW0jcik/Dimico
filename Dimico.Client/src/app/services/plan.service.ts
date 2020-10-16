import { AuthService } from './auth.service';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { Plan } from './../models/Plan';

@Injectable({
  providedIn: 'root'
})
export class PlanService {
  private planPath = environment.apiUrl + '/plans';
  constructor(private http: HttpClient, private authService: AuthService) { }

  create(data): Observable<Plan>{
    let headers = new HttpHeaders();
    headers = headers.set('Authorization', `Bearer ${this.authService.getToken()}`);
    return this.http.post<Plan>(this.planPath, data,{headers});
  }
}
