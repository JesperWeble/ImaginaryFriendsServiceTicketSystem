import { Component, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Status } from '../status';
import { StatusComponent } from '../status/status.component';
import { StatusService } from '../status.service';
import { Ticket } from '../ticket';
import { TicketComponent } from '../ticket/ticket.component';
import { TicketService } from '../ticket.service';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [CommonModule, StatusComponent, TicketComponent],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent
{
  statusList: Status[] = [];
  statusService: StatusService = inject(StatusService);
  ticketList: Ticket[] = [];
  ticketService: TicketService = inject(TicketService);
  ticketsByStatus: { [key: number]: Ticket[] } = {};

  constructor()
  {
    this.statusService.getAllStatuses().then((statusList: Status[]) => {
      this.statusList = statusList;
    })
    this.ticketService.getAllTickets().then((ticketList:Ticket[]) => {
      this.ticketList = ticketList;
      this.divideTicketsByStatus();
    })
  }

  divideTicketsByStatus() {
    this.ticketsByStatus = this.ticketList.reduce((acc, ticket) => {
      if (!acc[ticket.statusId]) {
        acc[ticket.statusId] = [];
      }
      acc[ticket.statusId].push(ticket);
      return acc;
    }, {} as { [key: number]: Ticket[] });
  }
}
