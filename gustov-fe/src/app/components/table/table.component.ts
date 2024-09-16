import { Component, EventEmitter, Input, Output, TemplateRef } from '@angular/core';
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
  @Input() customActions!: TemplateRef<any>;

  constructor() {   
    
  }

  getColumnName(column: string): string {
    const parts = column.split('.');
    const lastPart = parts[parts.length - 1];
    return this.capitalize(lastPart);
  }

  capitalize(word: string): string {
    return word.charAt(0).toUpperCase() + word.slice(1);
  }

  getDynamicProperty(element: any, path: string): any {
    if (!element || !path) return '';
    const keys = path.split('.');
    let value = element;
    for (const key of keys) {
      if (value[key] === undefined) {
        return '';
      }
      value = value[key];
    }
    return value;
  }

}
