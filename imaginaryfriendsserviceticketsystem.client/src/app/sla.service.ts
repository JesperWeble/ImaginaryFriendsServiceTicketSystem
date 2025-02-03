import { Injectable } from '@angular/core';
import { Sla } from './sla';

@Injectable({
  providedIn: 'root'
})
export class SlaService {
  url = 'https://localhost:7272/api/sla';
  constructor() { }

  async getAllSlas(): Promise<Sla[]> {
    const response = await fetch(`${this.url}/GetAllSlas`);
    return await response.json() ?? [];
  }

  async getSlaById(id: number): Promise<Sla> {
    const response = await fetch(`${this.url}/getslabyid?id=${id}`);
    return await response.json() ?? [];
  }
}
