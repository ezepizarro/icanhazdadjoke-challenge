import { Component, OnInit } from '@angular/core';
import { JokeService } from '../joke-service.service';
import Joke from '../Joke';

@Component({
  selector: 'app-jokes',
  templateUrl: './jokes.component.html',
  styleUrls: ['./jokes.component.css']
})
export class JokesComponent implements OnInit {
  response: Joke = new Joke();

  constructor(private jokeService: JokeService) { }

  ngOnInit() {
    this.jokeService.getRandomJoke()
    .subscribe((data: Joke) => {
      console.log(data);
      this.response = data;
    });
  }
}
