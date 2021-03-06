import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpModule } from '@angular/http';
import { FormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { ReviewComponent } from './review/review.component';

import { ReviewService } from './review.service';
import { NewReviewComponent } from './new-review/new-review.component';
import { HomeComponent } from './home/home.component';
import { SearchComponent } from './search/search.component';
import { AlertComponent } from './alert/alert.component';
import { AlertService } from './_services/alert.service';

import { AppRoutingModule } from './app-routing.module';
import { TopPropertiesComponent } from "./top-properties/top-properties.component";
import { LatestReviewsComponent } from './latest-reviews/latest-reviews.component';
import { PropertyDetailsComponent } from './property-details/property-details.component';
import { ReviewModalComponent } from './review-modal/review-modal.component';


@NgModule({
  declarations: [
    AppComponent,
    ReviewComponent,
    NewReviewComponent,
    HomeComponent,
    SearchComponent,
    AlertComponent,
    TopPropertiesComponent,
    LatestReviewsComponent,
    PropertyDetailsComponent,
    ReviewModalComponent
  ],
  imports: [
    BrowserModule,
    HttpModule,
    FormsModule,
    AppRoutingModule
  ],
  providers: [ReviewService, AlertService],
  bootstrap: [AppComponent]
})
export class AppModule { }
