import { Route } from "@angular/router";
import { CrmComponent } from "./crm/crm.component";
import { EcommerceComponent } from "./ecommerce/ecommerce.component";
import { HelpDeskComponent } from "./help-desk/help-desk.component";
import { LmsComponent } from "./lms/lms.component";
import { ProjectManagementComponent } from "./project-management/project-management.component";
import {AuthGuard} from "../core/guards/auth.guard";


export const DASHBOARD_ROUTE: Route[] = [
  {path: '', canActivate:[AuthGuard] ,component: EcommerceComponent},
  {path: 'crm', canActivate:[AuthGuard] ,component: CrmComponent},
  {path: 'project-management', canActivate:[AuthGuard] ,component: ProjectManagementComponent},
  {path: 'lms', canActivate:[AuthGuard] ,component: LmsComponent},
  {path: 'help-desk', canActivate:[AuthGuard] ,component: HelpDeskComponent},

];

