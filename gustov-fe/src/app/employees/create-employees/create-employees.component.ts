import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { EmployeeService } from '../../core/services/employee.service';
import { MessageService } from 'primeng/api';
import { ActivatedRoute, Router } from '@angular/router';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-create-employees',
  templateUrl: './create-employees.component.html',
  styleUrl: './create-employees.component.scss'
})
export class CreateEmployeesComponent implements OnInit{
  protected form: FormGroup;
  employeeId: any;

  constructor( 
    private employeeService: EmployeeService,
    private fb: FormBuilder,
    private messageService: MessageService,
    private router: Router,
    private activatedRoute: ActivatedRoute,
    private datePipe: DatePipe,

  ) {
    
  }
  ngOnInit(): void {
    this.activatedRoute.paramMap.subscribe(data=>{
      this.employeeId = data.get('employeeId');
    })
    
    this.formControl();
    if (this.employeeId) {
      this.getById();
    }
    
  }

  formControl() {
    this.form = this.fb.group({
      id:[0],
      name:['',Validators.required],
      lastName:['',Validators.required],
      address:['',[Validators.required]],
      hireDate:['', Validators.required],
    })
  }

  getById(){
    this.employeeService.getById(this.employeeId).subscribe(data=>{
      this.form.patchValue({
        ...data
      })
    })
  }

  save() {
    const request = this.employeeId
      ? this.employeeService.update(this.employeeId, this.form.value)
      : this.employeeService.save(this.form.value);
  
      request.subscribe(data => {
      this.router.navigate(['/employees'])
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
function moment(fecha_inicio: Date) {
  throw new Error('Function not implemented.');
}

