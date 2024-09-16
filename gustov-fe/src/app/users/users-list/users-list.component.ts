import {Component, OnInit, ViewChild} from '@angular/core';
import {UsersService} from "../../core/services/users.service";
import {MatTableDataSource} from "@angular/material/table";
import {MatPaginator} from "@angular/material/paginator";
import { User } from '../../core/models/user.model';
import { MessageService } from 'primeng/api';
import { Router } from '@angular/router';
import { AlertService } from '../../core/services/alert.service';

@Component({
  selector: 'app-users-list',
  templateUrl: './users-list.component.html',
  styleUrl: './users-list.component.scss'
})
export class UsersListComponent implements OnInit{

  columns: string[] = [
    'Nº',
    'name',
    'lastName',
    'email',
    'address',
    'role.name',
    'actions'
  ];

  dataSource!: MatTableDataSource<User>;
  @ViewChild(MatPaginator, { static: true }) paginator!: MatPaginator;

  constructor(private userService: UsersService,
    private alertService: AlertService,
    private router: Router
  ) {
  }

  ngOnInit() {
    this.getAll();
  }

  getAll() {
    this.userService.getAll().subscribe((data)=>{
      this.dataSource = new MatTableDataSource<User>(data);
      this.dataSource.paginator = this.paginator;
    })
  }

  update(userId:any){
    this.router.navigate(['/users/edit/',userId]);
  }

  delete(userId:any){
    this.alertService.confirmAction("Delete").then(result=>{
      if (result.isConfirmed) {
        this.userService.delete(userId).subscribe(data=>{
          this.alertService.showSuccessMessage("Successfully deleted",()=>{
            this.getAll();
          });
        }) 
      }
    })    
  }

}
