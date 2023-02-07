import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {ServiceResponse} from '../Dto/ServiceResponse';
import {Observable} from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private Http: HttpClient) {
  }

  login(username: string, password: string): Observable<ServiceResponse<string>> {
    const body = {
      Username: username,
      Password: password
    }
    return this.Http.post<ServiceResponse<string>>('/api/Auth/login', body)
  }

  register(username: string, password: string, email: string): Observable<ServiceResponse<Number>> {
    const body = {
      Username: username,
      Password: password,
      Email: email
    }

    return this.Http.post<ServiceResponse<Number>>('/api/Auth/register', body)
  }
}
