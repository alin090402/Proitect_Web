import { Component, OnInit } from '@angular/core';
import { AuthService } from '../../service/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  constructor(private authService : AuthService){
  }

  login(){
    this.authService.login('admin', 'admin').subscribe(response => {
      console.log(response);
    })
  }

  ngOnInit() {
    this.login();
  }
}
