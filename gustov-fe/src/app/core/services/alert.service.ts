import { Injectable } from '@angular/core';
import { MessageService } from 'primeng/api';
import Swal from 'sweetalert2';

@Injectable({
  providedIn: 'root'
})
export class AlertService {

  constructor(
    private messageService: MessageService
  ) {}

  confirmAction(confirmButtonText: string) {
    return Swal.fire({
      title: "Are you sure?",
      text: "You won't be able to revert this!",
      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#3085d6',
      cancelButtonColor: '#d33',
      confirmButtonText: confirmButtonText
    });
    
  }

  showSuccessMessage(text: string,callback: () => void) {
    this.messageService.add({
        severity: 'success',
        summary: 'Éxito',
        detail: text,
        key: 'success',
        life: 3000
      });
      setTimeout(callback, 1000)
  }

  showErrorMessage(text: string) {
    this.messageService.add({
        severity: 'error',
        summary: 'Error',
        detail: text,
        key: 'error',
        life: 3000
      });
  }
}
