import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { FormsModule } from '@angular/forms';

import { Property } from '../property';
import { ReviewService } from '../review.service';
import { Review } from "../review";

@Component({
  selector: 'app-new-review',
  templateUrl: './new-review.component.html',
  styleUrls: ['./new-review.component.css']
})
export class NewReviewComponent implements OnInit {

  properties: Property[];
  model = new Review("", "0e3d6b27-9477-4115-a6a6-5055b3", 5, new Date(), "test");

  constructor(
    private router: Router,
    private reviewService: ReviewService) { }

  getProperties(): void {
    this.reviewService.getProperties().then(properties => this.properties = properties);
  }

  onSubmit(): void {
    this.reviewService.createReview(this.model);
  }

  update(value) {
    console.log(value);
    this.model.PropertyId = value;
  }

  ngOnInit() {
    this.getProperties();
    //this.model.Comment = "test";
  }

  get diagnostic() { return JSON.stringify(this.model); }
}
