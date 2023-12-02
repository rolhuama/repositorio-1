import { Activity } from "./activity.model";

export class ActivityDetail {
    id!: string;
    activity: Activity = new Activity;
    week!: number;
    year!: number;
    month!: number;
    day!: number;
    dayName!: string;
    hours!: number;
    date!: string;
}
