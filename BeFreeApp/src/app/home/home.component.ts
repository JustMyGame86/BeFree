import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { Review } from '../review';
import { ReviewService } from '../review.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  title = 'BeFree';
  reviews: Review[];

  constructor(
    private router: Router,
    private reviewService: ReviewService) { }

  getReviews(): void {
    this.reviewService.getReviews().then(reviews => this.reviews = reviews);
  }

  gotoNew(): void {
    this.router.navigate(['/new']);
  }

  ngOnInit(): void {
    this.getReviews();
  }

}
