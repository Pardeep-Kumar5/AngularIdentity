import { Injectable } from '@angular/core';
import{HttpClient}from '@angular/common/http';
import{map,Observable}from 'rxjs';
import { Login } from './login';
import { JsonPipe } from '@angular/common';
import { Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';

@Injectable({
  providedIn: 'root'
})
export class LoginService {
  currentUserName:any="";
  constructor(private httpclient:HttpClient,private router:Router,
    private Jwthelperservice:JwtHelperService) { }
  checkuser(login:Login):Observable<any>
  {
    return this.httpclient.post<any>("https://localhost:44358/api/Account/authenticate"
    ,login).pipe(map (u=>{
      if(u)
      {
        this.currentUserName=u.username;
        sessionStorage["currentuser"]=JSON.stringify(u);
      }
      return u;
    }))
  }
  Logout()
  {
    this.currentUserName="";
    sessionStorage.removeItem("currentuser");
    this.router.navigateByUrl("/login");
  }
  public isAuthenticated():boolean
  {
    if(this.Jwthelperservice.isTokenExpired())
    {
      return false;
    }
    else
    {
      return true;
    }
  }
}
