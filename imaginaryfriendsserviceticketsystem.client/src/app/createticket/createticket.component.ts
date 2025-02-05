import { Component, OnInit, ChangeDetectorRef, AfterViewInit, inject } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { CustomerService } from '../customer.service';
import { Customer } from '../customer';
import { TicketDto } from '../ticketdto';
import { TicketService } from '../ticket.service';

@Component({
  selector: 'app-createticket',
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './createticket.component.html',
  styleUrl: './createticket.component.css'
})
export class CreateticketComponent implements OnInit, AfterViewInit {
  ticketService: TicketService = inject(TicketService);
  ticketAddForm = new FormGroup({
    title: new FormControl(''),
    description: new FormControl(''),
    customerId: new FormControl(1),
    statusId: new FormControl(1),
    levelId: new FormControl(1)
  });

  customers: Customer[] = [];

  constructor(
    private customerService: CustomerService,
    private cdr: ChangeDetectorRef
  ) { }

  ngOnInit() {
    this.customerService.getAllCustomers().then((data) => {
      this.customers = data;
    });
  }

  ngAfterViewInit() {
    this.cdr.detectChanges(); // Move detectChanges to ngAfterViewInit
  }

  onSubmit() {  
    const formValue = this.ticketAddForm.value;
    const newTicketDto = this.createTicketDto(formValue);
    if (newTicketDto == null) {
      console.log("");
      return;
    }
    this.ticketService.createTicket(newTicketDto);
  }

  private createTicketDto(formValue: any): TicketDto | null {
    if (!formValue.title || !formValue.description || formValue.customerId == null || formValue.statusId == null || formValue.levelId == null) {
      return null;
    }
    return {
      title: formValue.title,
      description: formValue.description,
      customerId: formValue.customerId,
      statusId: formValue.statusId,
      levelId: formValue.levelId
    };
  }
}

