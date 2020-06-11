import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { User } from '../Types/user';

@Injectable()
export class DataService {

  private baseUrl: string = "http://localhost:5001/api";

  constructor(private http: HttpClient) { }

  public getUsers(): Observable<User[]>{
    return this.http.get<User[]>(this.baseUrl + "/user").pipe(map((res)=> res));
  }
}