import { Component } from '@angular/core';
import { OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { Review } from './review';
import { ReviewService } from './review.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
  providers: [ReviewService]
})
export class AppComponent implements OnInit {
  title = 'BeFree';


  ngOnInit(): void {
    //this.getReviews();
  }
}
