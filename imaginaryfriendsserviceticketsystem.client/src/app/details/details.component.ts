import { Component, Input, input } from '@angular/core';
import { Ticket } from '../ticket';

@Component({
  selector: 'app-details',
  standalone: true,
  imports: [],
  templateUrl: './details.component.html',
  template: `

  `,
  styleUrl: './details.component.css'
})
export class DetailsComponent {
  @Input() Ticket!: Ticket;
}
