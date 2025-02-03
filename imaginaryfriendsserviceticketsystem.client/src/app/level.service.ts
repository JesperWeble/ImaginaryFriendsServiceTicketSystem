import { Injectable } from '@angular/core';
import { Level } from './level';

@Injectable({
  providedIn: 'root'
})
export class LevelService {
  url = 'https://localhost:7272/api/level';
  constructor() { }

  async getAllLevels(): Promise<Level[]> {
    const response = await fetch(`${this.url}/GetAllLevels`);
    return await response.json() ?? [];
  }

  async getLevelById(id: number): Promise<Level> {
    const response = await fetch(`${this.url}/getlevelbyid?id=${id}`);
    return await response.json() ?? [];
  }
}
