export class Review {
    constructor(
        public Id: string,
        public PropertyId: string,
        public Rating: number,
        public RatedOn: Date,
        public Comment: string) { }
}