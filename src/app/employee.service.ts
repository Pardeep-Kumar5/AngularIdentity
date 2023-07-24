import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Token } from '@angular/compiler';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Employee } from './employee';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {

  constructor(private httpclient:HttpClient) { }
  GetAllEmployee():Observable<any>
  {
    //jwt
  //   var CurrentUser={token:""};
  //   var hearder=new HttpHeaders();
  // hearder=hearder.set("Authorization","Bearer ");
  //   var CurrentUserSession=sessionStorage.getItem("currentuser");
  //   if(CurrentUserSession !=null)
  //   {
  //     CurrentUser=JSON.parse(CurrentUserSession);
  //     hearder=hearder.set("Authorization","Bearer "+CurrentUser.token);
  //   }
    return this.httpclient.get<any>("https://localhost:44358/api/Employee",);
  }
  SaveEmployee(NewEmployee:Employee):Observable<Employee>
  {
    //jwt
  //   var CurrentUser={token:""};
  //   var hearder=new HttpHeaders();
  // hearder=hearder.set("Authorization","Bearer ");
  //   var CurrentUserSession=sessionStorage.getItem("currentuser");
  //   if(CurrentUserSession !=null)
  //   {
  //     CurrentUser=JSON.parse(CurrentUserSession);
  //     hearder=hearder.set("Authorization","Bearer "+CurrentUser.token);
  //   }
    return this.httpclient.post<Employee>("https://localhost:44358/api/Employee",NewEmployee,);
  }
  UpdateEmployee(EditEmployee:Employee):Observable<Employee>
  {
     //jwt
  //    var CurrentUser={token:""};
  //    var hearder=new HttpHeaders();
  //  hearder=hearder.set("Authorization","Bearer ");
  //    var CurrentUserSession=sessionStorage.getItem("currentuser");
  //    if(CurrentUserSession !=null)
  //    {
  //      CurrentUser=JSON.parse(CurrentUserSession);
  //      hearder=hearder.set("Authorization","Bearer "+CurrentUser.token);
  //    }
    return this.httpclient.put<Employee>("https://localhost:44358/api/Employee",EditEmployee,);
  }
  DeleteEmployee(id:number):Observable<any>
  {
     //jwt
  //    var CurrentUser={token:""};
  //    var hearder=new HttpHeaders();
  //  hearder=hearder.set("Authorization","Bearer ");
  //    var CurrentUserSession=sessionStorage.getItem("currentuser");
  //    if(CurrentUserSession !=null)
  //    {
  //      CurrentUser=JSON.parse(CurrentUserSession);
  //      hearder=hearder.set("Authorization","Bearer "+CurrentUser.token);
  //    }
    return this.httpclient.delete<any>("https://localhost:44358/api/Employee/"+id,);
  }
}
