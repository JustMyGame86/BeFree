import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { HomeComponent } from './home/home.component';
import { ReviewComponent } from './review/review.component';
import { SearchComponent } from './search/search.component';
import { NewReviewComponent } from './new-review/new-review.component';
import { PropertyDetailsComponent } from './property-details/property-details.component';

const routes: Routes = [
    { path: '', redirectTo: '/home', pathMatch: 'full' },
    { path: 'home', component: HomeComponent },
    { path: 'detail/:id', component: ReviewComponent },
    { path: 'search', component: SearchComponent },
    { path: 'new', component: NewReviewComponent },
    { path: 'property/:id', component: PropertyDetailsComponent }
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class AppRoutingModule { }