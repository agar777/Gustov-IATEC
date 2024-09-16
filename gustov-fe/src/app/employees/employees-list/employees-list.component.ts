import { Component, ViewChild } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { Employee } from '../../core/models/employee.model';
import { EmployeeService } from '../../core/services/employee.service';
import { MatPaginator } from '@angular/material/paginator';
import { MessageService } from 'primeng/api';
import { Router } from '@angular/router';
import { MatDialog } from '@angular/material/dialog';
import { RequestVacationComponent } from '../../request/requestVacation.component';
import { AlertService } from '../../core/services/alert.service';

@Component({
  selector: 'app-employees-list',
  templateUrl: './employees-list.component.html',
  styleUrl: './employees-list.component.scss'
})
export class EmployeesListComponent {
  columns: string[] = [
    'Nº',
    'name',
    'lastName',
    'address',
    'hireDate',
    'actions'
  ];

  dataSource!: MatTableDataSource<Employee>;
  @ViewChild(MatPaginator, { static: true }) paginator!: MatPaginator;

  constructor(
    private employeeService: EmployeeService,
    private alertService: AlertService,
    private router: Router,
    private dialog: MatDialog,
  ) {
  }

  ngOnInit() {
    this.getAll();
  }

  getAll() {
    this.employeeService.getAll().subscribe((data)=>{
      this.dataSource = new MatTableDataSource<Employee>(data);
      this.dataSource.paginator = this.paginator;
    })
  }

  update(userId:any){
    this.router.navigate(['/employees/edit/',userId]);
  }

  delete(userId:any){
    this.alertService.confirmAction("Delete").then(result=>{
      if (result.isConfirmed) {
        this.employeeService.delete(userId).subscribe(data=>{
          this.alertService.showSuccessMessage("Successfully deleted",()=>{

            this.getAll();
          });      
        })
      }
    }) 
  }

  requestVacation(employeeId:number){
    const dialogRef = this.dialog.open(RequestVacationComponent,{
      data: {
        estado: true,
        title: 'Request Vacation',
        employeeId: employeeId
      },
    });
    dialogRef.afterClosed().subscribe((result) => {
      if (result){
        this.getAll();
      }
    });
  }

  calculateYearsWorked(hireDate: Date): boolean {
    let dateObject = new Date(hireDate);
    let currentDate = new Date().getFullYear();
    let yearsWorked = currentDate - dateObject.getFullYear();    
    return yearsWorked>=1;
  }

}
