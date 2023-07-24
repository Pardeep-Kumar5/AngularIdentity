import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AboutComponent } from './about/about.component';
import { EmployeeComponent } from './employee/employee.component';
import { HomeComponent } from './home/home.component';
import { JwtActivateguardService } from './jwt-activateguard.service';
import { LoginComponent } from './login/login.component';


const routes: Routes = [
   {path:"",redirectTo:"home",pathMatch:"full"},
  {path:"home",component:HomeComponent},
  {path:"about",component:AboutComponent},
  {path:"employee",component:EmployeeComponent,canActivate:[JwtActivateguardService]},
  {path:"login",component:LoginComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
