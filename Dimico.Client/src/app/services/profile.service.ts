import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Profile } from '../models/Profile';
import { AuthService } from './auth.service';

@Injectable({
  providedIn: 'root'
})
export class ProfileService {
  private profilePath = environment.apiUrl + '/profiles';
  constructor(private http: HttpClient, private authService: AuthService) { }
  getProfile(): Observable<Profile> {
    return this.http.get<Profile>(this.profilePath);
  }
  create(data): Observable<Profile>{
    return this.http.put<Profile>(this.profilePath,{
      Email: data.Email,
      UserName: data.UserName,
      Name: data.Name,
      MainPhotoUrl: data.MainPhotoUrl,
      WebSite: data.WebSite,
      Biography: data.Biography,
      Gender: Number(data.Gender),
      IsPrivate: data.IsPrivate 
  }) 
  }
}
 