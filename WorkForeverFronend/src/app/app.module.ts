import {HttpClientModule} from '@angular/common/http';
import {NgModule} from '@angular/core';
import {BrowserModule} from '@angular/platform-browser';

import {AppRoutingModule} from './app-routing.module';
import {AppComponent} from './app.component';
import {LoginComponent} from './component/login/login.component';
import {ReactiveFormsModule} from "@angular/forms";
import {PreloadAllModules, RouterModule} from "@angular/router";
import {ROUTES} from "./app.routes";
import { RegisterComponent } from './component/register/register.component';
import { UsersTableComponent } from './component/users-table/users-table.component';
import {MatTableModule} from "@angular/material/table";
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NavbarComponent } from './component/navbar/navbar.component';
import { LayoutModule } from '@angular/cdk/layout';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatButtonModule } from '@angular/material/button';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatIconModule } from '@angular/material/icon';
import { MatListModule } from '@angular/material/list';
import { FactoryTableComponent } from './component/factory-table/factory-table.component';
import { ActivityDirective } from './directives/activity.directive';
import { AdminViewComponent } from './component/admin-view/admin-view.component';
import { AdminfactoryComponent } from './component/adminfactory/adminfactory.component';
import { ActivityPipePipe } from './pipe/activity-pipe.pipe';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    RegisterComponent,
    UsersTableComponent,
    NavbarComponent,
    FactoryTableComponent,
    ActivityDirective,
    AdminViewComponent,
    AdminfactoryComponent,
    ActivityPipePipe
  ],
  imports: [
    HttpClientModule,
    BrowserModule,
    AppRoutingModule,
    RouterModule.forRoot(ROUTES, {preloadingStrategy: PreloadAllModules}),
    ReactiveFormsModule,
    MatTableModule,
    BrowserAnimationsModule,
    LayoutModule,
    MatToolbarModule,
    MatButtonModule,
    MatSidenavModule,
    MatIconModule,
    MatListModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule {
}
