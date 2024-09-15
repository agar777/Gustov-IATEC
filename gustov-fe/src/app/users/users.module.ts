import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { UsersRoutingModule } from './users-routing.module';
import { UsersListComponent } from './users-list/users-list.component';
import { CreateUsersComponent } from './create-users/create-users.component';
import {WebMaterialModule} from "../webmaterial.module";
import {FormsModule, ReactiveFormsModule} from "@angular/forms";
import { BreadcrumbsComponent } from '../components/breadcrumbs/breadcrumbs.component';
import { TableComponent } from '../components/table/table.component';


@NgModule({
  declarations: [
    UsersListComponent,
    CreateUsersComponent
  ],
  imports: [
    CommonModule,
    UsersRoutingModule,
    WebMaterialModule,
    FormsModule,
    ReactiveFormsModule,
    BreadcrumbsComponent,
    TableComponent
  ],
  bootstrap: [CreateUsersComponent]

})
export class UsersModule { }
