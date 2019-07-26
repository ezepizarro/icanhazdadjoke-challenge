import { Component, OnInit } from '@angular/core';
import { JokeService } from '../joke-service.service';
import Joke from '../Joke';
import * as signalR from '@aspnet/signalr';


@Component({
  selector: 'app-jokes',
  templateUrl: './jokes.component.html',
  styleUrls: ['./jokes.component.css']
})
export class JokesComponent implements OnInit {
  response: Joke = new Joke();
  joke: Joke = new Joke();

  constructor(private jokeService: JokeService) { }

  ngOnInit() {
    this.jokeService.getRandomJoke()
    .subscribe((data: Joke) => {
      console.log(data);
      this.response = data;
    });

    const connection = new signalR.HubConnectionBuilder()
      .configureLogging(signalR.LogLevel.Information)
      .withUrl('https://localhost:44388/joke')
      .build();

    connection.start().then(() => {
      console.log('Connected!');
    }).catch((err) => {
      return console.error(err.toString());
    });

    connection.on('BroadcastMessage', (message: string) => {
      this.joke.joke = message;
    });
  }
}
