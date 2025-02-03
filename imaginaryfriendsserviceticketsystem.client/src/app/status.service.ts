import { Injectable } from '@angular/core';
import { Status } from './status';

@Injectable({
  providedIn: 'root'
})
export class StatusService {

  url = 'https://localhost:7272/api/Status/GetAllStatuses'
  constructor() { }
  async getAllStatuses(): Promise<Status[]>
  {
    const response = await fetch(this.url);
    return await response.json() ?? [];
  }
}
