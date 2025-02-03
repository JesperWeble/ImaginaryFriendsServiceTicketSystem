import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { StatusComponent } from '../status/status.component';

@Component({
  selector: 'app-ticket',
  standalone: true,
  imports: [CommonModule, StatusComponent],
  template: `
    <p>
      ticket works!
    </p>
  `,
  styleUrl: './ticket.component.css'
})
export class TicketComponent {

}
