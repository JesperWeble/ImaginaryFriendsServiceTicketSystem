import { Component, Input } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Status } from '../status'
import { Ticket } from '../ticket'
import { RouterModule } from '@angular/router'
import { TicketComponent } from '../ticket/ticket.component';

@Component({
  selector: 'app-status',
  standalone: true,
  imports: [CommonModule, RouterModule, TicketComponent],
  templateUrl: './status.component.html',
  styleUrls: ['./status.component.css']
})
export class StatusComponent
{
  @Input() status!: Status;
  @Input() ticketList!: Ticket[];
}
