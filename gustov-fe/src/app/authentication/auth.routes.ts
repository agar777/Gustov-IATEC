import { Route } from "@angular/router";
import { ForgotPasswordComponent } from "./forgot-password/forgot-password.component";
import { ConfirmEmailComponent } from "./confirm-email/confirm-email.component";
import { LockScreenComponent } from "./lock-screen/lock-screen.component";
import { LogoutComponent } from "./logout/logout.component";
import { ResetPasswordComponent } from "./reset-password/reset-password.component";
import { SignInComponent } from "./sign-in/sign-in.component";
import { SignUpComponent } from "./sign-up/sign-up.component";

export const AUTH_ROUTE: Route[] = [
  // {
  //   path: "",
  //   redirectTo: "signin",
  //   pathMatch: "full",
  // },
  {path: '', component: SignInComponent},
  {path: 'sign-up', component: SignUpComponent},
  {path: 'forgot-password', component: ForgotPasswordComponent},
  {path: 'reset-password', component: ResetPasswordComponent},
  {path: 'lock-screen', component: LockScreenComponent},
  {path: 'confirm-email', component: ConfirmEmailComponent},
  {path: 'logout', component: LogoutComponent}
    
];
