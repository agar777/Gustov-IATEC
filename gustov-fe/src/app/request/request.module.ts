import { NgModule } from '@angular/core';
import { CommonModule, DatePipe } from '@angular/common';

import { RequestRoutingModule } from './request-routing.module';
import { RequestListComponent } from './request-list/request-list.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BreadcrumbsComponent } from '../components/breadcrumbs/breadcrumbs.component';
import { TableComponent } from '../components/table/table.component';
import { WebMaterialModule } from '../webmaterial.module';


@NgModule({
  declarations: [
    RequestListComponent,
  ],
  imports: [
    CommonModule,
    RequestRoutingModule,
    WebMaterialModule,
    FormsModule,
    ReactiveFormsModule,
    BreadcrumbsComponent,
    TableComponent,
  ],
  providers: [DatePipe]

})
export class RequestModule { }
