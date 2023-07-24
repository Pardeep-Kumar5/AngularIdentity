import { Component, OnInit } from '@angular/core';
import { Employee } from '../employee';
import { EmployeeService } from '../employee.service';

@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.scss']
})
export class EmployeeComponent {
  EmployeeList:Employee[]=[];
  NewEmployee:Employee= new Employee();
  EditEmployee:Employee=new Employee();
  constructor(private employeeService:EmployeeService){} 
  ngOnInit():void{
    this.GetAll();
  }
  GetAll()
  {
    this.employeeService.GetAllEmployee().subscribe(
      (response)=>{
        this.EmployeeList=response;
        console.log(this.EmployeeList)
      },
      (error)=>{
        console.log(error)
      }
    )
  }
  SaveClick()
  {
    this.employeeService.SaveEmployee(this.NewEmployee).subscribe(
      (Response)=>{
        this.GetAll();
        this.NewEmployee.name="";
        this.NewEmployee.address="";
        this.NewEmployee.salary=0;
      },
      (Error)=>{
        console.log(Error);
    
      }
    );
    }
  EditClick(d:any)
  {
    // alert(d.name)
   
    this.EditEmployee=d;
  }
  UpdateClick()
  {
    this.employeeService.UpdateEmployee(this.EditEmployee).subscribe(
      (response)=>{
        this.GetAll()
      },
      (error)=>{
        console.error();
        
      }

    )
  }
  DeleteClick(id:number)
  {
    // alert(id)
    let ans=window.confirm('want to delete data ???????');
    if(!ans) return;
     this.employeeService.DeleteEmployee(id).subscribe(
      (Response)=>{
        this.GetAll();
      },
      (Error)=>{
        console.log(Error);
        
      }
     )
  }
}
