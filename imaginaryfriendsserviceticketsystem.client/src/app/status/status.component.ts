import { Component, Input } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Status } from '../status';
import { TicketComponent } from '../ticket/ticket.component';
import { RouterModule } from '@angular/router'

@Component({
    selector: 'app-status',
    standalone: true,
    imports: [CommonModule, TicketComponent, RouterModule],
    templateUrl: './status.component.html',
    styleUrls: ['./status.component.css']
  })
export class StatusComponent
{
    @Input() status!:Status;
  
  }
