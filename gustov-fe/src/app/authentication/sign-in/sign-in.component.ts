import { Component } from '@angular/core';
import { FormsModule, FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { RouterLink, Router } from '@angular/router';
import { NgIf } from '@angular/common';
import { AuthenticationService } from '../../core/services/authentication.service';
import { TokenStorageService } from '../../core/storages/token-storage.service';
import { finalize } from 'rxjs';
import { WebMaterialModule } from '../../webmaterial.module';
import { MessageService } from 'primeng/api';

@Component({
    selector: 'app-sign-in',
    standalone: true,
    imports: [RouterLink,FormsModule, ReactiveFormsModule, NgIf, WebMaterialModule],
    templateUrl: './sign-in.component.html',
    styleUrl: './sign-in.component.scss',
    providers: [MessageService]

})
export class SignInComponent {

    public loading:boolean = false;
    constructor(
        private fb: FormBuilder,
        private router: Router,
        private authService: AuthenticationService,
        private token: TokenStorageService,
        private messageService: MessageService
    ) {
        this.authForm = this.fb.group({
            username: ['', [Validators.required]],
            password: ['', [Validators.required, Validators.minLength(6)]],
        });
    }

    hide = true;

    authForm: FormGroup;

    onSubmit() {
        this.loading = true;
        this.authService.login(this.authForm.value)
        .pipe(
            finalize(() => {
              this.authForm.markAsPristine();
            })
          )
        .subscribe(
            data=>{
                this.token.saveToken(data.token);
                this.token.saveUser(data.user);
                this.router.navigate(['dashboard'])
                this.messageService.add({ severity: 'success', 
                    summary: 'Exito', 
                    detail: 'Inicio de sesión exitoso',
                    key: 'success',
                    life: 3000 });
            },
            error=>{
                this.loading = false;                              
                this.messageService.add({ severity: 'error',
                    summary: 'Error', 
                    detail: error.error, 
                    key: 'error', life: 3000 });
            }
        );
        
    }

}