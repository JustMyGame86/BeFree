import { Component, OnInit } from '@angular/core';
import { ParamMap, ActivatedRoute, Router } from "@angular/router";

import { ReviewService } from "../review.service";
import { Property } from "../property";

import 'rxjs/add/operator/switchMap';
import { Review } from "../review";
import { PropertyRating } from "../_models/propertyrating";

@Component({
  selector: 'app-property-details',
  templateUrl: './property-details.component.html',
  styleUrls: ['./property-details.component.css']
})
export class PropertyDetailsComponent implements OnInit {
  currentpage: number = 1;
  propertyid: string;
  property: PropertyRating = null;
  reviews: Review[];

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private service: ReviewService) { }

  getLabelColour(): string {
    if (this.property.AverageRating < 3.5)
      return "warning";
    if (this.property.AverageRating < 2)
      return "success";
  }
  nextPage() {
    this.currentpage++;
    this.getReviews();
  }

  previousPage() {
    if (this.currentpage == 1)
      return;
    this.currentpage--;
    this.getReviews();
  }

  loadDetails() {
    this.service.getPropertyRating(this.propertyid).then(r => this.property = r);
    this.getReviews();
  }

  getReviews() {
    this.service.getReviewsByProperty(this.propertyid, this.currentpage).then(r => this.reviews = r);
  }

  ngOnInit() {
    this.route.params.subscribe(params => {
      this.propertyid = params['id']; // (+) converts string 'id' to a number

      this.loadDetails();
    });
  }

}
