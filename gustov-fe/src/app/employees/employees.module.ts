import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { EmployeesRoutingModule } from './employees-routing.module';
import { EmployeesListComponent } from './employees-list/employees-list.component';
import { CreateEmployeesComponent } from './create-employees/create-employees.component';


@NgModule({
  declarations: [
    EmployeesListComponent,
    CreateEmployeesComponent
  ],
  imports: [
    CommonModule,
    EmployeesRoutingModule
  ]
})
export class EmployeesModule { }
