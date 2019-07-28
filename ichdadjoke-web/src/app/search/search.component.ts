import { Component, OnInit } from '@angular/core';
import { JokeService } from '../joke-service.service';
import { FormGroup, FormControl, FormArray, FormBuilder } from '@angular/forms';
import SearchResponse from '../SearchResponse';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';
import { DialogContentComponent } from '../dialog-content/dialog-content.component';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.css']
})
export class SearchComponent implements OnInit {
  response: SearchResponse = new SearchResponse();

  constructor(private jokeService: JokeService, private formBuilder: FormBuilder, private dialog: MatDialog) {
    this.form = this.formBuilder.group({
      searchInput: new FormControl(''),
    });
   }

  step = -1;
  form: FormGroup;
  lastDialogResult: string;

  openDialog() {
    const dialogRef = this.dialog.open(DialogContentComponent);

    dialogRef.afterClosed().subscribe(result => {
      this.lastDialogResult = result;
    });
  }

  onSubmit(form) {
    this.jokeService.searchJokes(form.searchInput)
    .subscribe((data: SearchResponse) => {
      console.log(data);
      if (data.longJokes.length === 0 && data.mediumJokes.length === 0
        && data.shortJokes.length === 0 ) {
        this.openDialog();
      }
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
