import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { VacationService } from '../core/services/vacation.service';
import { Vacation } from '../core/models/vacation.model';
import { WebMaterialModule } from '../webmaterial.module';

@Component({
  selector: 'app-vacation-invoice',
  standalone: true,
  imports: [WebMaterialModule],
  templateUrl: './vacation-invoice.component.html',
  styleUrl: './vacation-invoice.component.scss'
})
export class VacationInvoiceComponent implements OnInit {

  invoice: Vacation;

  constructor(
    public dialogRef: MatDialogRef<VacationInvoiceComponent>,
    @Inject(MAT_DIALOG_DATA) protected data:any,
    private vacationService: VacationService
  ) {
    
  }

  ngOnInit(): void {
    this.getById();
  }

  getById() {
    this.vacationService.getById(this.data.requestId).subscribe(data=>{
        this.invoice = data;
    })
  }

  printDiv(divId: string) {
    const printContent = document.getElementById(divId)?.innerHTML;
    if (printContent) {
        const originalContent = document.body.innerHTML;
        document.body.innerHTML = printContent;
        window.print();
        document.body.innerHTML = originalContent;        
    }
  }
}
