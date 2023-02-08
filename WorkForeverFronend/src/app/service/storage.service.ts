import { Injectable } from '@angular/core';
import {GetUserDto} from "../Dto/GetUserDto";
const USER_KEY = 'auth-user';
const TOKEN = 'auth-token';
@Injectable({
  providedIn: 'root'
})
export class StorageService {

  constructor() {
  }
  isLoggedIn(): boolean {
    return window.sessionStorage.getItem(TOKEN) != null &&
      window.sessionStorage.getItem(USER_KEY) != null
  }
  clearUser(): void {
    window.sessionStorage.removeItem(TOKEN);
    window.sessionStorage.removeItem(USER_KEY);
  }
  saveUserToken(token:string): void {
    window.sessionStorage.removeItem(TOKEN);
    window.sessionStorage.setItem(TOKEN, token);
  }
  getUserToken(): string {
    return <string>sessionStorage.getItem(TOKEN);
  }
  saveUser(user: GetUserDto): void {
    window.sessionStorage.removeItem(USER_KEY);
    window.sessionStorage.setItem(USER_KEY, JSON.stringify(user));
  }
  getUser(): GetUserDto {
    return JSON.parse(<string>sessionStorage.getItem(USER_KEY));
  }

}
