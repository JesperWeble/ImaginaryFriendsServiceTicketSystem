import { Component, OnInit } from '@angular/core';
import { StatusComponent } from './status/status.component'
import { RouterModule, Routes } from '@angular/router';

@Component({
  standalone: true,
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css',
  imports: [StatusComponent, RouterModule]
})
export class AppComponent implements OnInit {
  ngOnInit()
  {

  }

  title = 'Imaginary Friends Service';
}
