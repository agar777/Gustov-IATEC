import { NgModule } from '@angular/core';
import { CommonModule, DatePipe } from '@angular/common';

import { EmployeesRoutingModule } from './employees-routing.module';
import { EmployeesListComponent } from './employees-list/employees-list.component';
import { CreateEmployeesComponent } from './create-employees/create-employees.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BreadcrumbsComponent } from '../components/breadcrumbs/breadcrumbs.component';
import { TableComponent } from '../components/table/table.component';
import { WebMaterialModule } from '../webmaterial.module';
import { MessageService } from 'primeng/api';


@NgModule({
  declarations: [
    EmployeesListComponent,
    CreateEmployeesComponent
  ],
  imports: [
    CommonModule,
    EmployeesRoutingModule,
    WebMaterialModule,
    FormsModule,
    ReactiveFormsModule,
    BreadcrumbsComponent,
    TableComponent,
  ],
  providers: [MessageService, DatePipe]

})
export class EmployeesModule { }
