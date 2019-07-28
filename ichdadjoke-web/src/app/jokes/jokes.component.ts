import { Component, OnInit } from '@angular/core';
import { JokeService } from '../joke-service.service';
import Joke from '../Joke';
import * as signalR from '@aspnet/signalr';
import { environment } from '../../environments/environment';


@Component({
  selector: 'app-jokes',
  templateUrl: './jokes.component.html',
  styleUrls: ['./jokes.component.css']
})
export class JokesComponent implements OnInit {
  response: Joke = new Joke();
  joke: Joke = {
    id: "",
    joke: "Waiting for SignalR message..",
    status: 0
  }
  
  constructor(private jokeService: JokeService) { }

  ngOnInit() {
    this.jokeService.getRandomJoke()
    .subscribe((data: Joke) => {
      console.log(data);
      this.response = data;
    });

    const connection = new signalR.HubConnectionBuilder()
      .configureLogging(signalR.LogLevel.Information)
      .withUrl(environment.apiSignalREndpoint)
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
