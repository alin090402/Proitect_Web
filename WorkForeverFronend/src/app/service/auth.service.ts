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

  login(username: string, password: string): Observable<ServiceResponse<String>> {
    const body = {
      Username: username,
      Password: password
    }

    return this.Http.post<ServiceResponse<String>>('/Auth/login', body)
  }

}
