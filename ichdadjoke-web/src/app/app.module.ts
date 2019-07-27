import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatButtonModule, MatCheckboxModule, MatMenuModule, MatToolbarModule, MatIconModule, MatCardModule
  , MatDividerModule, MatListModule, MatExpansionModule, MatInputModule, MatDialogModule } from '@angular/material';
import { JokesComponent } from './jokes/jokes.component';
import { SearchComponent } from './search/search.component';
import { DialogContentComponent } from './dialog-content/dialog-content.component';

@NgModule({
  declarations: [
    AppComponent,
    JokesComponent,
    SearchComponent,
    DialogContentComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    ReactiveFormsModule,
    MatButtonModule,
    MatCheckboxModule,
    MatMenuModule,
    MatToolbarModule,
    MatIconModule,
    MatCardModule,
    MatDividerModule,
    MatListModule,
    MatExpansionModule,
    MatInputModule,
    MatDialogModule ],
  providers: [],
  bootstrap: [AppComponent],
  entryComponents: [DialogContentComponent]
})
export class AppModule { }
