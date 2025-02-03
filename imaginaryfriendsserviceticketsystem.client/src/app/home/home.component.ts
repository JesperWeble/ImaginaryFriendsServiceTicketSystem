import { Component, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { StatusComponent } from '../status/status.component';
import { Status } from '../status';
import { StatusService } from '../status.service';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [CommonModule, StatusComponent],
  template: `
    <p>
      home works!
    </p>
  `,
  styleUrl: './home.component.css'
})
export class HomeComponent {

}
