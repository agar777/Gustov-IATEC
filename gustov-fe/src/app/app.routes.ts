import { Routes } from '@angular/router';
import { NotFoundComponent } from './common/not-found/not-found.component';
import { EcommerceComponent } from './dashboard/ecommerce/ecommerce.component';
import { AuthGuard } from './core/guards/auth.guard';
import { AppComponent } from './app.component';
import { AuthLayoutComponent } from './layout/app-layout/auth-layout/auth-layout.component';
import { MainLayoutComponent } from './layout/app-layout/main-layout/main-layout.component';

export const routes: Routes = [
 {
        path: '',
        component: MainLayoutComponent,
        // canActivate: [AuthGuard],
        children: [
          { path: '', redirectTo: '/dashboard', pathMatch: 'full' },

          {
              path: 'dashboard',
              loadChildren: () =>
                  import('./dashboard/dashboard.routes').then((m) => m.DASHBOARD_ROUTE),
          },
          {
            path:'users',
            loadChildren: () =>
              import('./users/users.module').then((m) => m.UsersModule),
          },
          {
            path:'employees',
            loadChildren: () =>
              import('./employees/employees.module').then((m) => m.EmployeesModule),
          },
          {
            path:'requests',
            loadChildren: () =>
              import('./request/request.module').then((m) => m.RequestModule),
          }

        ],
    },
    {
        path: 'authentication',
        component: AuthLayoutComponent,
        loadChildren: () =>
            import('./authentication/auth.routes').then((m) => m.AUTH_ROUTE),
    },
    {path: '**', component: NotFoundComponent}
];
