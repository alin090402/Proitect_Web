import {Component} from '@angular/core';
import {BreakpointObserver, Breakpoints} from '@angular/cdk/layout';
import {Observable} from 'rxjs';
import {map, shareReplay} from 'rxjs/operators';
import {Router} from "@angular/router";
import {StorageService} from "../../service/storage.service";
import {AuthService} from "../../service/auth.service";
import {UserService} from "../../service/user.service";
import {GetUserDto} from "../../Dto/GetUserDto";

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss']
})
export class NavbarComponent {

  isHandset$: Observable<boolean> = this.breakpointObserver.observe(Breakpoints.Handset)
    .pipe(
      map(result => result.matches),
      shareReplay()
    );

  constructor(private breakpointObserver: BreakpointObserver,
              private storageService: StorageService,
              private authService: AuthService,
              private userService: UserService,
              private router: Router) {
  }

  isLoggedIn(): boolean {
    return this.storageService.isLoggedIn();
  }


  logout(): void {
      this.storageService.clearUser();
      this.router.navigate(['/']);
  }

  isAdmin() {
    //console.log ("isAdmin(): ", this.isLoggedIn() , this.storageService.getUser().role);
    if (!this.isLoggedIn())
      return false;
    return this.storageService.getUser().role == 0;
  }

  computeName() {
    return this.storageService.getUser().username;
  }
}
