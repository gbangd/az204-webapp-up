import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, Observable, throwError } from 'rxjs';
import { ImageDimensions } from './image-dimensions';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type':  'application/json'
  })
};

export interface ImageResult{
  url:string;
}

@Injectable({
  providedIn: 'root'
})
export class TestService {

  private url: string = "https://localhost:7061/ImagesCreator";

  constructor(private http: HttpClient) { }

  generateImage(dimensions: ImageDimensions, imageName: string): Observable<ImageResult> {
    return this.http.post<ImageResult>(this.url+"/"+imageName,dimensions, httpOptions).pipe(catchError(this.handleError));
  }


  private handleError(error: HttpErrorResponse) {
    if (error.status === 0) {
      // A client-side or network error occurred. Handle it accordingly.
      console.error('An error occurred:', error.error);
    } else {
      // The backend returned an unsuccessful response code.
      // The response body may contain clues as to what went wrong.
      console.error(
        `Backend returned code ${error.status}, body was: `, error.error);
    }
    // Return an observable with a user-facing error message.
    return throwError(() => new Error('Something bad happened; please try again later.'));
  }

}
