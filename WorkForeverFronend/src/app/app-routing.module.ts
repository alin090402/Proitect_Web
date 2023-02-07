import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {LoginComponent} from "./component/login/login.component";
import {RegisterComponent} from "./component/register/register.component";
import {UsersTableComponent} from "./component/users-table/users-table.component";
import {NavbarComponent} from "./component/navbar/navbar.component";
import {FactoryTableComponent} from "./component/factory-table/factory-table.component";

export const ROUTES: Routes = [
  {path: '', component: LoginComponent},
  {path: 'login', component: LoginComponent},
  {path: 'register', component: RegisterComponent},
  {path: 'users', component: UsersTableComponent},
  {path: 'nav', component: NavbarComponent},
  {path: 'factories', component: FactoryTableComponent},
  {path: '**', redirectTo: ''}
];
@NgModule({
  imports: [RouterModule.forRoot(ROUTES)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
