import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Horse } from '../models/horse';

@Injectable({
  providedIn: 'root'
})
export class HorseService {
  private http: HttpClient;

  constructor(http: HttpClient) {
    this.http = http;
   }

  public getHorses(): Observable<Horse[]> {
    return this.http.get<Horse[]>("https://localhost:5002/api/horse");
  }

  public addHorse(horse: Horse): Observable<Horse> {
    return this.http.post<Horse>("https://localhost:5002/api/horse", horse);
  }

  public deleteHorse(id: number): Observable<unknown> {
    return this.http.delete(`${"https://localhost:5002/api/horse"}/${id}`);
  }

  public updateHorse(horse: Horse): Observable<Horse> {
    return this.http.put<Horse>(`${"https://localhost:5002/api/horse"}/${horse.id}`, horse);
  }
}
