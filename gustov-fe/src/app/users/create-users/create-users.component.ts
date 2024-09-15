import { Component, OnDestroy, OnInit } from '@angular/core';
import { UsersService } from '../../core/services/users.service';
import { RoleService } from '../../core/services/role.service';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Validators } from 'ngx-editor';
import { Role } from '../../core/models/role.model';
import { MessageService } from 'primeng/api';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-create-users',
  templateUrl: './create-users.component.html',
  styleUrl: './create-users.component.scss'
})
export class CreateUsersComponent implements OnInit{

  protected form: FormGroup;
  protected roles: Role[];
  userId: any;

  constructor( 
    private userService: UsersService,
    private roleService: RoleService,
    private fb: FormBuilder,
    private messageService: MessageService,
    private router: Router,
    private activatedRoute: ActivatedRoute
  ) {
    
  }
  ngOnInit(): void {
    this.activatedRoute.paramMap.subscribe(data=>{
      this.userId = data.get('userId');
    })
    
    this.formControl();
    this.roleList();
    if (this.userId) {
      this.getById();
    }
    
  }

  formControl() {
    this.form = this.fb.group({
      id:[0],
      name:['',Validators.required],
      lastName:['',Validators.required],
      address:['',[Validators.required]],
      roleId:['', Validators.required],
      email:['', [Validators.required]],
      password:['', Validators.required]
    })
  }

  roleList() {
    this.roleService.getAll().subscribe(data=>{
      this.roles = data;
    })
  }

  getById(){
    this.userService.getById(this.userId).subscribe(data=>{
      this.form.patchValue({
        ...data
      })
    })
  }

  save() {
    const request = this.userId
      ? this.userService.update(this.userId, this.form.value)
      : this.userService.save(this.form.value);
  
      request.subscribe(data => {
      this.router.navigate(['/users'])
      this.messageService.add({
        severity: 'success',
        summary: 'Éxito',
        detail: 'Successfully registered',
        key: 'success',
        life: 3000
      });
    },
    error => {
      this.messageService.add({
        severity: 'error',
        summary: 'Error',
        detail: error.error,
        key: 'error',
        life: 3000
      });
    }
  );
  }

}
