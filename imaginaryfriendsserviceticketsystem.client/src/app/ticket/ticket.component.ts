import { Component, Input } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Ticket } from '../ticket'
import { RouterModule } from '@angular/router'

@Component({
  selector: 'app-ticket',
  standalone: true,
  imports: [CommonModule, RouterModule],
  templateUrl: 'ticket.component.html',
  styleUrl: './ticket.component.css'
})
export class TicketComponent
{
  @Input() ticket!: Ticket;

}
