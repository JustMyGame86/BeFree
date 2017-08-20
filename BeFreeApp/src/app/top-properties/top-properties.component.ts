import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { ReviewService } from '../review.service';
import { Property } from "../property";

@Component({
  selector: 'top-properties',
  templateUrl: './top-properties.component.html',
  styleUrls: ['./top-properties.component.css']
})
export class TopPropertiesComponent implements OnInit {
  properties: Property[];
  numberofproperties: number = 5;

  constructor(
    private router: Router,
    private reviewService: ReviewService) { }

  getProperties(): void {
    this.reviewService.getTopProperties(this.numberofproperties).then(properties => this.properties = properties);
  }

  ngOnInit(): void {
    this.getProperties();
  }

}
