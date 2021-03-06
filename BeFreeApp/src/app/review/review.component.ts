import { Component, OnInit } from '@angular/core';
import { Review } from "../review";
import { Router } from "@angular/router";
import { ReviewService } from "../review.service";

@Component({
  selector: 'app-review',
  templateUrl: './review.component.html',
  styleUrls: ['./review.component.css']
})
export class ReviewComponent implements OnInit {
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
