import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { JokesComponent } from './jokes/jokes.component';
import { SearchComponent } from './search/search.component';


const routes: Routes = [
  {path: 'jokes', component: JokesComponent},
  {path: 'search', component: SearchComponent},
  {path: '', redirectTo: '/jokes', pathMatch: 'full'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
