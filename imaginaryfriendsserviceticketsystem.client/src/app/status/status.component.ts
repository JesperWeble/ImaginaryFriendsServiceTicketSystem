import { Component, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TicketComponent } from '../ticket/ticket.component';
import { StatusService } from '../status.service'

@Component({
    selector: 'app-status',
    standalone: true,
    imports: [CommonModule, TicketComponent],
    templateUrl: './status.component.html',
    styleUrls: ['./status.component.css']
  })
export class StatusComponent
{
  statusService: StatusService = inject(StatusService);

  constructor() {

  }
  
}
