import {Injectable} from '@angular/core';
import {GetFactoryDto} from "../Dto/GetFactoryDto";
import {HttpClient, HttpHeaders} from "@angular/common/http";
import {Observable} from "rxjs";
import {ServiceResponse} from "../Dto/ServiceResponse";
import {StorageService} from "./storage.service";
import {WorkResultDto} from "../Dto/WorkResultDto";

@Injectable({
  providedIn: 'root'
})
export class FactoryService {

  constructor(private Http: HttpClient,
              private storageService: StorageService) {
  }

  getAllFactories(): Observable<ServiceResponse<GetFactoryDto[]>> {
    let auth_token = this.storageService.getUserToken()
    const headers = new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${auth_token}`
    });
    const requestOptions = {headers: headers};
    return this.Http
      .get<ServiceResponse<GetFactoryDto[]>>('/api/Factory/getAll', requestOptions);

  }

  work(factoryId:number): Observable<ServiceResponse<WorkResultDto>> {
    let auth_token = this.storageService.getUserToken()
    const headers = new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${auth_token}`
    });
    const requestOptions = {headers: headers};
    const body = {
      FactoryId: factoryId
    }
    console.log(factoryId);
    console.log(body);
    return this.Http
      .post<ServiceResponse<WorkResultDto>>(`/api/work`, body, requestOptions);
  }

}
