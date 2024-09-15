import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {UsersListComponent} from "./users-list/users-list.component";
import {AuthGuard} from "../core/guards/auth.guard";
import { CreateUsersComponent } from './create-users/create-users.component';

const routes: Routes = [
  {
    path: '',
    component: UsersListComponent,
    // canActivate:[AuthGuard]
  },
  {
    path:'create',
    component: CreateUsersComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class UsersRoutingModule { }
