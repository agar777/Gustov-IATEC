import { Component, EventEmitter, Input, Output } from '@angular/core';
import { WebMaterialModule } from '../../webmaterial.module';
import { MatPaginator } from '@angular/material/paginator';
import { CommonModule } from '@angular/common';
import { User } from '../../core/models/user.model';

@Component({
  selector: 'app-table',
  standalone: true,
  imports: [CommonModule,WebMaterialModule],
  templateUrl: './table.component.html',
  styleUrl: './table.component.scss'
})
export class TableComponent {

  @Input() dataSource:any;
  @Input() paginator:MatPaginator;
  @Input() columns:any;
  @Output()delete:EventEmitter<any> = new EventEmitter<any>();
  @Output()update:EventEmitter<any> = new EventEmitter<any>();
  
  constructor() {   
    
  }

  isObject(value: any): boolean {
    return typeof value === 'object' && value !== null;
  }

  formatObject(obj: any): string {
    return obj.name
  }

  edit(id:any){
    this.update.emit(id);
  }
  
  destroy(id:any){
    this.delete.emit(id);
  }

}
