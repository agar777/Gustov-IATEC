import { CommonModule } from '@angular/common';
import { Component, Inject, OnInit } from '@angular/core';
import { WebMaterialModule } from '../webmaterial.module';
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { MessageService } from 'primeng/api';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { RequestService } from '../core/services/request.service';
import { AlertService } from '../core/services/alert.service';

@Component({
  selector: 'app-request',
  standalone: true,
  imports: [CommonModule, WebMaterialModule, ReactiveFormsModule, FormsModule],
  providers:[MessageService],
  templateUrl: './requestVacation.component.html',
})
export class RequestVacationComponent implements OnInit {

  protected form: FormGroup;

  constructor( 
    public dialogRef: MatDialogRef<RequestVacationComponent>,
    private requestService: RequestService,
    private fb: FormBuilder,
    private alertService: AlertService,
    @Inject(MAT_DIALOG_DATA) protected data:any

  ) {
    
  }
  ngOnInit(): void {
    this.formControl();    
  }

  formControl() {
    this.form = this.fb.group({
      id:[0],
      employeeId:[this.data.employeeId],
      requestDate:['',Validators.required],
      status:['PENDING']
    })
  }

  save() {
    this.alertService.confirmAction("Save Request").then(result=>{
      if (result.isConfirmed) {
        this.requestService.save(this.form.value).subscribe(data=>{
          this.alertService.showSuccessMessage("Successfully requested",()=>{

            this.dialogRef.close(data);
          })
        },
        error => {
          this.alertService.showErrorMessage(error.error);
        })
      }
    })    
  }


}
