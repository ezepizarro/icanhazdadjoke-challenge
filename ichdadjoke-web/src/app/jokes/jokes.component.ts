import { Component, OnInit } from '@angular/core';
import { JokeService } from '../joke-service.service';

@Component({
  selector: 'app-jokes',
  templateUrl: './jokes.component.html',
  styleUrls: ['./jokes.component.css']
})
export class JokesComponent implements OnInit {
  response;

  constructor(private jokeService: JokeService) { }

  ngOnInit() {
    this.jokeService.getRandomJoke()
    .subscribe((data) => {
      console.log(data);
      this.response = data;
    });
  }
}
