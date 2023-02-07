import { Component } from '@angular/core';
import {UserService} from "../../service/user.service";
import {GetUserDto} from "../../Dto/GetUserDto";
import {MatTableDataSource} from "@angular/material/table";

@Component({
  selector: 'app-users-table',
  templateUrl: './users-table.component.html',
  styleUrls: ['./users-table.component.scss']
})
export class UsersTableComponent {

  users: MatTableDataSource<GetUserDto> = new MatTableDataSource<GetUserDto>();
  constructor(private userService: UserService
  ) {
    this.GenerateUserTable();
  }
  displayedColumns: string[] = ['Id', 'Username', 'WorkExperience', 'Money','Role'];
  GenerateUserTable(){
    console.log("GenerateUserTable");
    this.userService.getAllUsers().subscribe(response => {
      console.log (response);
      if (response.success)
      {
        this.users.data = response.data;

        console.log(this.users);
      }
    });
  }

}
