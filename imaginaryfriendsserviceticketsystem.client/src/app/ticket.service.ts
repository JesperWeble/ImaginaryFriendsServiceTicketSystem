import { Injectable } from '@angular/core';
import { Ticket } from './ticket';

@Injectable({
  providedIn: 'root'
})
export class TicketService {
  url = 'http://localhost:7272/api/ticket';
  constructor() { }

  async getAllTickets(): Promise<Ticket[]> {
    const response = await fetch(`${this.url}/GetAllTickets`);
    return await response.json() ?? [];
  }

  async getTicket(id: number): Promise<Ticket> {
    const response = await fetch(`${this.url}/GetTicketById/${id}`);
    return await response.json() ?? [];
  }

  async createTicket(ticket: Ticket): Promise<Ticket> {
    const response = await fetch(`${this.url}/AddTicket`, {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json'
      },
      body: JSON.stringify(ticket)
    });
    return await response.json() ?? [];
  }

  async updateTicket(ticket: Ticket): Promise<Ticket> {
    const response = await fetch(`${this.url}/UpdateTicket`, {
      method: 'PUT',
      headers: {
        'Content-Type': 'application/json'
      },
      body: JSON.stringify(ticket)
    });
    return await response.json() ?? [];
  }

  async deleteTicket(id: number): Promise<Ticket> {
    const response = await fetch(`${this.url}/DeleteTicket/${id}`, {
      method: 'DELETE'
    });
    return await response.json() ?? [];
  }
}
