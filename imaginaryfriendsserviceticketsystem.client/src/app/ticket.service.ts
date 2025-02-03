import { Injectable } from '@angular/core';
import { Ticket } from './ticket';

@Injectable({
  providedIn: 'root'
})
export class TicketService {
  url = 'https://localhost:7272/api/';
  constructor() { }

  async getAllTickets(): Promise<Ticket[]> {
    const response = await fetch(`${this.url}/GetAllTickets`);
    return await response.json() ?? [];
  }

  async getTicketById(id: number): Promise<Ticket> {
    const response = await fetch(`${this.url}/getticketbyid?id=${id}`);
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
