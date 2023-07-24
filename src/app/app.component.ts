import { Component } from '@angular/core';
import { LoginService } from './login.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
 
  title = 'AngularProjectWithJWT_1030';
  constructor(public loginservice:LoginService){}
  LogoutClick()
  {
    this.loginservice.Logout();
  }
}
