import { Component, Input } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Status } from '../status';
import { RouterModule } from '@angular/router'

@Component({
    selector: 'app-status',
    standalone: true,
    imports: [CommonModule, RouterModule],
    templateUrl: './status.component.html',
    styleUrls: ['./status.component.css']
  })
export class StatusComponent {
    @Input() status!:Status;
  
  }
