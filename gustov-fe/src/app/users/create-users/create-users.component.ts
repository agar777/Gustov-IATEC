import { Component, OnDestroy, OnInit } from '@angular/core';
import { UsersService } from '../../core/services/users.service';
import { RoleService } from '../../core/services/role.service';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Validators } from 'ngx-editor';
import { Role } from '../../core/models/role.model';

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
  ) {
    
  }
  ngOnInit(): void {
    this.formControl();
    this.roleList();
  }

  formControl() {
    this.form = this.fb.group({
      Name:['',Validators.required],
      LastName:['',Validators.required],
      Address:['',[Validators.required]],
      RoleId:['', Validators.required],
      Email:['', [Validators.required]],
      Password:['']
    })
  }

  roleList() {
    this.roleService.getAll().subscribe(data=>{
      this.roles = data;
    })
  }

  save(){
    if (this.userId) {
      this.userService.update(this.userId,this.form.value).subscribe(data=>{
      
      })
    }else{
      this.userService.save(this.form.value).subscribe(data=>{
        
      })
    }
  }

}
