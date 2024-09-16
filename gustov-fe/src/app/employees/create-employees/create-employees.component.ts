import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { EmployeeService } from '../../core/services/employee.service';
import { MessageService } from 'primeng/api';
import { ActivatedRoute, Router } from '@angular/router';
import { DatePipe } from '@angular/common';
import { AlertService } from '../../core/services/alert.service';

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
    private alertService: AlertService,
    private router: Router,
    private activatedRoute: ActivatedRoute,    
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
    this.alertService.confirmAction("Save Information").then(result=>{
      if (result.isConfirmed){
        const request = this.employeeId
        ? this.employeeService.update(this.employeeId, this.form.value)
        : this.employeeService.save(this.form.value);
    
        request.subscribe(data => {
          this.alertService.showSuccessMessage("Successfully registered",()=>{
            this.router.navigate(['/employees']);            
          });
        },
        error => {
          this.alertService.showErrorMessage(error.error);
        });  
      }
    })
  }
}

