import { Injectable } from '@angular/core';
import { Status } from './status';

@Injectable({
  providedIn: 'root'
})
export class StatusService {

  url = 'https://localhost:7272/api/Status/GetAllStatuses';
  constructor() { }
}
