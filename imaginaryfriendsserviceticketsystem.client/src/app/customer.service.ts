import { Injectable } from '@angular/core';
import { Customer } from './customer';

@Injectable({
  providedIn: 'root'
})
export class CustomerService {
  url = 'https://localhost:7272/api/customer';
  constructor() { }

  async getAllCustomers(): Promise<Customer[]> {
    const response = await fetch(`${this.url}/GetAllCustomers`);
    return await response.json() ?? [];
  }

  async getCustomerById(id: number): Promise<Customer> {
    const response = await fetch(`${this.url}/getcustomerbyid?id=${id}`);
    return await response.json() ?? [];
  }

  async createCustomer(customer: Customer): Promise<Customer> {
    const response = await fetch(`${this.url}/AddCustomer`, {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json'
      },
      body: JSON.stringify(customer)
    });
    return await response.json() ?? [];
  }

  async updateCustomer(customer: Customer): Promise<Customer> {
    const response = await fetch(`${this.url}/UpdateCustomer`, {
      method: 'PUT',
      headers: {
        'Content-Type': 'application/json'
      },
      body: JSON.stringify(customer)
    });
    return await response.json() ?? [];
  }

  async deleteCustomer(id: number): Promise<Customer> {
    const response = await fetch(`${this.url}/DeleteCustomer/${id}`, {
      method: 'DELETE'
    });
    return await response.json() ?? [];
  }
}
