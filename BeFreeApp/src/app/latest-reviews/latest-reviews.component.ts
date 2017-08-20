import { Component, OnInit } from '@angular/core';
import { Review } from "../review";
import { Router } from "@angular/router";
import { ReviewService } from "../review.service";

@Component({
  selector: 'latest-reviews',
  templateUrl: './latest-reviews.component.html',
  styleUrls: ['./latest-reviews.component.css']
})
export class LatestReviewsComponent implements OnInit {
  reviews: Review[];

  constructor(
    private router: Router,
    private reviewService: ReviewService) { }

  getReviews(): void {
    this.reviewService.getReviews().then(reviews => this.reviews = reviews);
  }

  ngOnInit(): void {
    this.getReviews();
  }
}
