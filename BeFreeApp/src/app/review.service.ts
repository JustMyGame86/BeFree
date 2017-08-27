import { Injectable } from '@angular/core';
import { Headers, Http } from '@angular/http';

import 'rxjs/add/operator/toPromise';

import { Review } from './review';
import { Property } from './property';
import { PropertyRating } from "./_models/propertyrating";

@Injectable()
export class ReviewService {
    private baseUrl = 'http://localhost:52863/api';

    private reviewUrl = this.baseUrl + '/review';
    private createReviewUrl = this.reviewUrl + '/create';

    private propertyUrl = this.baseUrl + '/property';


    constructor(private http: Http) { }

    getReviews(): Promise<Review[]> {
        return this.http.get(this.reviewUrl)
            .toPromise()
            .then(response => {
                //console.log(response.json().results);
                return response.json().results as Review[];
            })
            .catch(this.handleError);
    }

    getReviewsByProperty(propertyid: string, page: number = 1, sort: string = "ratedon#desc"): Promise<Review[]> {
        return this.http.get(this.reviewUrl + '/property?id=' + propertyid + '&page=' + page.toString() + '&sort=' + sort)
            .toPromise()
            .then(response => {
                //console.log(response.json().results);
                return response.json().results as Review[];
            })
            .catch(this.handleError);
    }

    getProperties(): Promise<Property[]> {
        return this.http.get(this.propertyUrl)
            .toPromise()
            .then(response => {
                return response.json().results as Property[];
            })
            .catch(this.handleError);
    }

    getProperty(id: string): Promise<Property> {
        return this.http.get(this.propertyUrl + '/' + id)
            .toPromise()
            .then(response => {
                console.log(response.json().results);
                return response.json().results as Property[];
            })
            .catch(this.handleError);
    }

    getPropertyRating(id: string): Promise<PropertyRating> {
        return this.http.get(this.propertyUrl + '/rating?propertyid=' + id)
            .toPromise()
            .then(response => {
                console.log(response.json().results);
                return response.json().results as Property[];
            })
            .catch(this.handleError);
    }

    getTopProperties(n: number): Promise<PropertyRating[]> {
        return this.http.get(this.propertyUrl + '/topratings?n=' + n.toString())
            .toPromise()
            .then(response => {
                return response.json().results as Property[];
            })
            .catch(this.handleError);
    }

    createReview(review: Review): Promise<boolean> {
        return this.http.post(this.createReviewUrl, review).toPromise().then(response => true).catch(response => false);
    }

    private handleError(error: any): Promise<any> {
        console.error('An error occurred', error); // for demo purposes only
        return Promise.reject(error.message || error);
    }
}