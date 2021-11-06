import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Better } from '../models/better';

@Injectable({
  providedIn: 'root'
})
export class BetterService {
  private http: HttpClient;

  constructor(http: HttpClient) {
    this.http = http;
   }

  public getBetters(): Observable<Better[]> {
    return this.http.get<Better[]>("https://localhost:5002/api/better");
  }

  public addBetter(better: Better): Observable<Better> {
    return this.http.post<Better>("https://localhost:5002/api/better", better);
  }

  public deleteBetter(id: number): Observable<unknown> {
    return this.http.delete(`${"https://localhost:5002/api/better"}/${id}`);
  }

  public updateBetter(better: Better): Observable<Better> {
    return this.http.put<Better>(`${"https://localhost:5002/api/better"}/${better.id}`, better);
  }

  public getHorseBetters(horseId: number): Observable<Better[]> {
    return this.http.get<Better[]>(`${"https://localhost:5002/api/better/horse"}/${horseId}`);
  }
}
