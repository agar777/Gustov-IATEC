import { Component, Input } from '@angular/core';
import { WebMaterialModule } from '../../webmaterial.module';
import { MatPaginator } from '@angular/material/paginator';
import { CommonModule } from '@angular/common';

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
  constructor() {   
    
  }

  isObject(value: any): boolean {
    return typeof value === 'object' && value !== null;
  }

  formatObject(obj: any): string {
    return obj.name
  }

}
