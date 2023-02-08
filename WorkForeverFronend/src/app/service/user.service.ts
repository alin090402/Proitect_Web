import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders} from "@angular/common/http";
import {StorageService} from "./storage.service";
import {Observable} from "rxjs";
import {ServiceResponse} from "../Dto/ServiceResponse";
import {GetUserDto} from "../Dto/GetUserDto";
import {GetUserWithEverythingDto} from "../Dto/GetUserWithEverythingDto";

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private Http:HttpClient,
              private storageService: StorageService
  ) { }

  getAllUsers():Observable<ServiceResponse<GetUserDto[]>>{
    let auth_token = this.storageService.getUserToken()

    const headers = new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${auth_token}`
    });
    console.log(headers)
    const requestOptions = { headers: headers };
    return this.Http
      .get<ServiceResponse<GetUserDto[]>>('/api/User/getAll', requestOptions);

  }

  getUser(): Observable<ServiceResponse<GetUserDto>> {
    let auth_token = this.storageService.getUserToken()
    const headers = new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${auth_token}`
    });
    const requestOptions = { headers: headers };
    return this.Http
      .get<ServiceResponse<GetUserDto>>('/api/User/getCurrentUser', requestOptions);
  }

  GetUsersWithEverything(): Observable<ServiceResponse<GetUserWithEverythingDto[]>> {
    let auth_token = this.storageService.getUserToken()
const headers = new HttpHeaders({
      'Content-Type': 'application/json',
  'Authorization': `Bearer ${auth_token}`
}
);
    const requestOptions = { headers: headers };
    return this.Http
      .get<ServiceResponse<GetUserWithEverythingDto[]>>('/api/User/getAllWithEverything', requestOptions);

  }
}
