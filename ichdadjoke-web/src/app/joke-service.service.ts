import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { timer, of } from 'rxjs';
import { switchMap, catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class JokeService {
  constructor(private httpClient: HttpClient) { }

  public getRandomJoke() {
    return timer(0, 10000)
        .pipe(
           switchMap(_ => this.httpClient.get('https://localhost:44388/api/Jokes')),
           catchError(error => of(`Bad request: ${error}`))
        );
  }
}
