import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { timer, of } from 'rxjs';
import { switchMap, catchError } from 'rxjs/operators';
import SearchResponse from './SearchResponse';
import Joke from './Joke';

@Injectable({
  providedIn: 'root'
})
export class JokeService {
  constructor(private httpClient: HttpClient) { }

  public getRandomJoke() {
    return timer(0, 10000)
        .pipe(
           //switchMap(_ => this.httpClient.get('https://localhost:44388/api/Jokes')),
           switchMap(_ => this.httpClient.get<Joke>('https://ichdadjokeapi.azurewebsites.net/api/Jokes')),
           catchError(error => of(`Bad request: ${error}`))
        );
  }

  public searchJokes(term) {
    //return this.httpClient.get('https://localhost:44388/api/Jokes/Search?term=' + term);
    return this.httpClient.get<SearchResponse>('https://ichdadjokeapi.azurewebsites.net/api/Jokes/Search?term=' + term);
  }
}
