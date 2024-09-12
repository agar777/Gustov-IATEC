import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {UsersListComponent} from "./users-list/users-list.component";
import {AuthGuard} from "../core/guards/auth.guard";

const routes: Routes = [
  {
    path: '',
    component: UsersListComponent,
    canActivate:[AuthGuard]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class UsersRoutingModule { }
