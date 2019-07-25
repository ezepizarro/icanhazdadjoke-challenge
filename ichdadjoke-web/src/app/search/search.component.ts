import { Component, OnInit } from '@angular/core';
import { JokeService } from '../joke-service.service';
import { FormGroup, FormControl, FormArray, FormBuilder } from '@angular/forms';
import SearchResponse from '../SearchResponse';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.css']
})
export class SearchComponent implements OnInit {
  response: SearchResponse = new SearchResponse();

  constructor(private jokeService: JokeService, private formBuilder: FormBuilder) {
    this.form = this.formBuilder.group({
      searchInput: new FormControl(''),
    });
   }

  step = 0;
  value = 'Clear me';
  form: FormGroup;

  onSubmit(form) {
    this.jokeService.searchJokes(form.searchInput)
    .subscribe((data: SearchResponse) => {
      console.log(data);
      this.response = data;
    });
  }

  public highlight(joke, term) {
    return joke.replace(new RegExp(term, 'gi'), match => {
        return '<span class="highlightText">' + match + '</span>';
    });
  }

  setStep(index: number) {
    this.step = index;
  }

  nextStep() {
    this.step++;
  }

  prevStep() {
    this.step--;
  }

  ngOnInit() {
  }

}
