import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { LoginService } from './login.service';
import {JwtHelperService}from'@auth0/angular-jwt';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class JwtActivateguardService implements CanActivate {

  constructor(private loginservices:LoginService,private router:Router,
    private jwthelperservices:JwtHelperService) { }
   canActivate(route: ActivatedRouteSnapshot,): boolean 
   {
    if(this.loginservices.isAuthenticated())
    {
      return true;
    }
    else
    {
      alert('You are not authorize to access this information')
      this.router.navigateByUrl("/login");
      return false;
    }
   }
}
