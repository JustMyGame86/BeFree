import { Category } from "../category";

export class PropertyRating {
    public Id: string;
    public Name: string;
    public Address: string;
    public Latitude?: number;
    public Longitude?: number;
    public CategoryId: string;
    public Category: Category;

    public AverageRating: number;
    public HighestRating: number;
    public LowestRating: number;
    public NumberOfReviews: number;
}