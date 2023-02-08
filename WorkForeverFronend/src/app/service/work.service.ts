import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders} from "@angular/common/http";
import {StorageService} from "./storage.service";
import {Observable} from "rxjs";
import {ServiceResponse} from "../Dto/ServiceResponse";
import {GetUserDto} from "../Dto/GetUserDto";
import {GetWorkRecordDto} from "../Dto/GetWorkRecordDto";

@Injectable({
  providedIn: 'root'
})
export class WorkService {

  constructor(private Http:HttpClient,
              private storageService: StorageService
  ) {
  }
  getWorkHistoryForUser(userId: number):Observable<ServiceResponse<GetWorkRecordDto[]>>
  {
    let auth_token = this.storageService.getUserToken();
    const headers = new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${auth_token}`
    });
    const requestOptions = { headers: headers };
    return this.Http
      .get<ServiceResponse<GetWorkRecordDto[]>>('/api/Work/getWorkRecordsByUser/${userId}', requestOptions);

  }

  getWorkHistoryForFactory(factoryId: number):Observable<ServiceResponse<GetWorkRecordDto[]>>
  {
    let auth_token = this.storageService.getUserToken();
    const headers = new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${auth_token}`
    });
    const requestOptions = { headers: headers };
    return this.Http
      .get<ServiceResponse<GetWorkRecordDto[]>>(`/api/Work/getWorkRecordsByFactory/${factoryId}`, requestOptions);
  }
}
