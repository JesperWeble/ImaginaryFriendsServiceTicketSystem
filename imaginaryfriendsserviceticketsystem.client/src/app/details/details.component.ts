import { Component, inject } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { CommonModule } from '@angular/common';
import { TicketService } from '../ticket.service';
import { CustomerDto, FullTicketInfoDto, LevelDto, SlaDto, UserDto } from '../fullticketinfodto';

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
  ticket: FullTicketInfoDto | undefined;
  user: UserDto | undefined;
  customer: CustomerDto | undefined;
  level: LevelDto | undefined;
  sla: SlaDto | undefined;

  constructor() {
    const ticketId = Number(this.route.snapshot.params['id']);
    this.ticketService.getFullTicketById(ticketId).then(ticket => {
      this.ticket = ticket;
      this.customer = ticket.customer;
      this.sla = this.customer.sla;
      this.user = ticket.user;
      this.level = ticket.level;
    });
  }
}
