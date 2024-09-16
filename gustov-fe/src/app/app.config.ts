import { ApplicationConfig } from '@angular/core';
import { provideRouter } from '@angular/router';

import { routes } from './app.routes';
import { provideClientHydration } from '@angular/platform-browser';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';
import {HTTP_INTERCEPTORS, HttpClientModule, provideHttpClient, withInterceptorsFromDi} from "@angular/common/http";
import { HttpInterceptor } from './core/interceptors/http.interceptor';
import { JwtInterceptor } from './core/interceptors/jwt.interceptor';
import { MessageService } from 'primeng/api';
import { ToastModule } from 'primeng/toast';

export const appConfig: ApplicationConfig = {
    providers: [
      provideHttpClient(withInterceptorsFromDi()),
      provideRouter(routes),
      provideClientHydration(),
      provideAnimationsAsync(),
      {provide: HTTP_INTERCEPTORS, useClass: HttpInterceptor, multi:true},
      {provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi:true},
      HttpClientModule,
      MessageService,
      ToastModule
    ]
};
