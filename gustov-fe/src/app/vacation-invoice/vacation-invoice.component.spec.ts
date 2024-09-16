import { ComponentFixture, TestBed } from '@angular/core/testing';

import { VacationInvoiceComponent } from './vacation-invoice.component';

describe('VacationInvoiceComponent', () => {
  let component: VacationInvoiceComponent;
  let fixture: ComponentFixture<VacationInvoiceComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [VacationInvoiceComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(VacationInvoiceComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
