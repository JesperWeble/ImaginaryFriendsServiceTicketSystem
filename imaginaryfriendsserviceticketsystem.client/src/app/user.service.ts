import { Injectable } from '@angular/core';
import { User } from './user';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  url = 'https://localhost:7272/api/user';
  constructor() { }

  async getAllUsers(): Promise<User[]> {
    const response = await fetch(`${this.url}/GetAllUsers`);
    return await response.json() ?? [];
  }

  async getUserById(id: number): Promise<User> {
    const response = await fetch(`${this.url}/getuserbyid?id=${id}`);
    return await response.json() ?? [];
  }

  async createUser(user: User): Promise<User> {
    const response = await fetch(`${this.url}/AddUser`, {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json'
      },
      body: JSON.stringify(user)
    });
    return await response.json() ?? [];
  }

  async updateUser(user: User): Promise<User> {
    const response = await fetch(`${this.url}/UpdateUser`, {
      method: 'PUT',
      headers: {
        'Content-Type': 'application/json'
      },
      body: JSON.stringify(user)
    });
    return await response.json() ?? [];
  }


  async deleteUser(id: number): Promise<User> {
    const response = await fetch(`${this.url}/DeleteUser/${id}`, {
      method: 'DELETE'
    });
    return await response.json() ?? [];
}
