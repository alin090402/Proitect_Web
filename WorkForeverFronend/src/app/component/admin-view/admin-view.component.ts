import { Component } from '@angular/core';
import {UserService} from "../../service/user.service";
import {GetUserWithEverythingDto} from "../../Dto/GetUserWithEverythingDto";
import {ActivityDirective} from "../../directives/activity.directive";
@Component({
  selector: 'app-admin-view',
  templateUrl: './admin-view.component.html',
  styleUrls: ['./admin-view.component.scss']
})
export class AdminViewComponent {
    menu: {user:GetUserWithEverythingDto,  isExpanded:boolean}[] = [];
  constructor(private userService: UserService) {
      userService.GetUsersWithEverything().subscribe(response => {
        console.log(response);
        if (response.success) {
          for (let user of response.data) {
            this.menu.push({user: user, isExpanded: false});
          }
        }
      });
    }

  toggleMenu(menu: {user:GetUserWithEverythingDto,  isExpanded:boolean}) {
    menu.isExpanded = !menu.isExpanded;
  }
}
