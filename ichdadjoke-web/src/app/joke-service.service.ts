import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { timer, of } from 'rxjs';
import { switchMap, catchError } from 'rxjs/operators';
import SearchResponse from './SearchResponse';
import Joke from './Joke';
import { environment } from '../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class JokeService {
  constructor(private httpClient: HttpClient) { }

  public getRandomJoke() {
    return timer(0, 10000)
        .pipe(
           switchMap(_ => this.httpClient.get<Joke>( environment.apiEndpoint + '/Jokes')),
           catchError(error => of(`Bad request: ${error}`))
        );
  }

  public searchJokes(term) {
    return this.httpClient.get<SearchResponse>( environment.apiEndpoint + '/Jokes/Search?term=' + term);
  }
}
