import { Component, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { RequestService } from '../../core/services/request.service';
import { VacationService } from '../../core/services/vacation.service';
import { Vacation } from '../../core/models/vacation.model';
import { Requests } from '../../core/models/requests.model';
import { AlertService } from '../../core/services/alert.service';
import { MatDialog } from '@angular/material/dialog';
import { VacationInvoiceComponent } from '../../vacation-invoice/vacation-invoice.component';

@Component({
  selector: 'app-request-list',
  templateUrl: './request-list.component.html',
  styleUrl: './request-list.component.scss'
})
export class RequestListComponent {
  columns: string[] = [
    'Nº',
    'employee.name',
    'employee.lastName',
    'employee.hireDate',
    'requestDate',
    'status',
    'actions'
  ];
  vacation: Vacation;

  dataSource!: MatTableDataSource<Requests>;
  @ViewChild(MatPaginator, { static: true }) paginator!: MatPaginator;

  constructor(
    private requestService: RequestService,
    private vacationService: VacationService,
    private alertService: AlertService,
    private dialog: MatDialog,
  ) {
  }

  ngOnInit() {
    this.getAll();
    this.vacation = new Vacation();
  }

  getAll() {
    this.requestService.getAll().subscribe((data)=>{
      this.dataSource = new MatTableDataSource<Requests>(data);
      this.dataSource.paginator = this.paginator;
    })
  }

  approveVacation(requestId: number){
    this.alertService.confirmAction("Save Information").then(result=>{
        if (result.isConfirmed) {
          this.vacationService.save(requestId).subscribe(data=>{
            this.alertService.showSuccessMessage(data.success,()=>{
              this.getAll();
            })
          },
          error => {            
            this.alertService.showErrorMessage(error.error.error)
          })        
        }
    })
  }

  vacationInvoice(requestId:number){
    const dialogRef = this.dialog.open(VacationInvoiceComponent,{
      data: {
        estado: true,
        title: 'Vacation Invoice',
        requestId: requestId
      },
    });
    dialogRef.afterClosed().subscribe((result) => {
      if (result){
        this.getAll();
      }
    });
  }

}
