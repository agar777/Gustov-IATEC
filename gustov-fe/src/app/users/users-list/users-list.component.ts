import {Component, OnInit, ViewChild} from '@angular/core';
import {UsersService} from "../../core/services/users.service";
import {MatTableDataSource} from "@angular/material/table";
import {MatPaginator} from "@angular/material/paginator";
import { User } from '../../core/models/user.model';

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
    'role',
    'actions'
  ];

  dataSource!: MatTableDataSource<User>;
  @ViewChild(MatPaginator, { static: true }) paginator!: MatPaginator;

  constructor(private userService: UsersService) {
  }

  ngOnInit() {
    this.usersList();
  }

  usersList() {
    this.userService.getAll().subscribe((data)=>{
      this.dataSource = new MatTableDataSource<User>(data);
      this.dataSource.paginator = this.paginator;
    })
  }

}
