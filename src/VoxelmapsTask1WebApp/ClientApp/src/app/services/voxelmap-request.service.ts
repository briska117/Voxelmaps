import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { catchError, tap, retry } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class VoxelmapRequestService {

  private header = new HttpHeaders({});

  constructor(private http: HttpClient) { }


  private getHeaders() {
    this.header = new HttpHeaders({
      'Content-Type': 'application/json',
      'Access-Control-Allow-Origin': '*'
    });
  }

  public getServer(urlFunction: string, uriBaseAlt: string = ''): Observable<any> {
    this.getHeaders();
    const options = { headers: this.header };
    // console.log(this.header);
    return this.http.get<any>(urlFunction, options).pipe(
      tap((resp: any) => {
        if (resp != null) {
          return resp;
        } else {
          this.handleError<any>();
        }
      }),
      catchError(this.handleError<any>(urlFunction))
    );
  }

  public postServer(urlFunction: string, entity: any): Observable<any> {
    this.getHeaders();
    const options = { headers: this.header };
    return this.http.post<any>(urlFunction, entity, options).pipe(
      tap((resp: any) => {
        if (resp != null) {
          return resp;
        } else {
          this.handleError<any>();
        }
      }),
      catchError(this.handleError<any>(urlFunction))
    );
  }

  private handleError<T>(operation = 'operation', result?: T) {
    // this.changeMessage.next(false);
    return (error: any): Observable<T> => {

      return of(error as T);
    };
  }


}
