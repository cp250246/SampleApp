import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { User } from '../Types/user';
import {Album} from "../Types/album";
import {Photo} from '../Types/photo';

@Injectable()
export class DataService {

  private baseUrl: string = "http://localhost:5001/api";

  constructor(private http: HttpClient) { }

  public getUsers(): Observable<User[]>{
    return this.http.get<User[]>(`${this.baseUrl}/user`).pipe(map((res)=> res));
  }

  public getAlbums(userId): Observable<Album[]>{
    return this.http.get<Album[]>(this.baseUrl + `/album/${userId}`).pipe(map((res)=> res));
  }

  public getPhotos(albumId): Observable<Photo[]>{
    return this.http.get<Photo[]>(this.baseUrl + `/photo/${albumId}`).pipe(map((res)=> res));
  }
}
