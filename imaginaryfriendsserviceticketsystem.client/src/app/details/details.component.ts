import { Component, inject, Input } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { CommonModule } from '@angular/common';
import { Ticket } from '../ticket';
import { TicketService } from '../ticket.service';

@Component({
  selector: 'app-details',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './details.component.html',
  styleUrl: './details.component.css'
})
export class DetailsComponent {
  route: ActivatedRoute = inject(ActivatedRoute);
  ticketService = inject(TicketService);
  ticket: Ticket | undefined;

  constructor() {
    const ticketId = Number(this.route.snapshot.params['id']);
    this.ticketService.getTicketById(ticketId).then(ticket => {
      this.ticket = ticket;
    });
  }
}
