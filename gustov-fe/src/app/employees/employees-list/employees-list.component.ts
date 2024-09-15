import { Component, ViewChild } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { Employee } from '../../core/models/employee.model';
import { EmployeeService } from '../../core/services/employee.service';
import { MatPaginator } from '@angular/material/paginator';
import { MessageService } from 'primeng/api';
import { Router } from '@angular/router';

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
    private messageService: MessageService,
    private router: Router
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
    this.employeeService.delete(userId).subscribe(data=>{
      this.messageService.add({
        severity: 'success',
        summary: 'Éxito',
        detail: 'Successfully deleted',
        key: 'success',
        life: 3000
      });
      this.getAll();
    })
  }

}
