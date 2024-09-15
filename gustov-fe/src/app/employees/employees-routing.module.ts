import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EmployeesListComponent } from './employees-list/employees-list.component';
import { CreateEmployeesComponent } from './create-employees/create-employees.component';

const routes: Routes = [
  {
    path: '',
    component: EmployeesListComponent,
    // canActivate:[AuthGuard]
  },
  {
    path:'create',
    component: CreateEmployeesComponent
  },
  {
    path:'edit/:employeeId',
    component:CreateEmployeesComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class EmployeesRoutingModule { }
