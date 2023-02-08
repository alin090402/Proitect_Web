import {Component, OnInit} from '@angular/core';
import {AuthService} from '../../service/auth.service';
import {FormBuilder, FormGroup, Validators} from "@angular/forms";
import {Router} from "@angular/router";
import {StorageService} from "../../service/storage.service";
import {UserService} from "../../service/user.service";

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  loginForm: FormGroup = new FormGroup({});
  role: Number = 2;

  constructor(private fb: FormBuilder,
              private authService: AuthService,
              private router: Router,
              private storageService: StorageService,
              private userService: UserService) {
    this.createForm();
  }


  // login(){
  //   this.authService.login('admin', 'admin').subscribe(response => {
  //     console.log(response);
  //   })
  // }

  createForm(): void {
    this.loginForm = this.fb.group({
      username: [null, Validators.required],
      password: [null, Validators.required]
    });
  }

  onSubmit(): void {
    if (this.loginForm.valid) {
      const body = {
        username: this.loginForm.value.username,
        password: this.loginForm.value.password
      };

      this.authService.login(this.loginForm.value.username, this.loginForm.value.password).subscribe(response => {
        console.log(response);
        if (response.success) {
          this.storageService.saveUserToken(response.data);
          this.userService.getUser().subscribe(response => {
            if (response.success){
              this.storageService.saveUser(response.data);
              this.router.navigate(['/accounts']);
            }
          });
        }
      })
    }
  }

  reloadPage(): void {
    window.location.reload();
  }


  ngOnInit() {
    //this.login();
  }
}
