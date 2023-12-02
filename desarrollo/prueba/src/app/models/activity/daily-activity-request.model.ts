import { Activity } from "./activity.model";
import { Period } from "./period.model";

export class DailyActivityRequest {
    userId!: string;
    companyId!: number;
    period: Period = new Period;
    weekNumber!: number;
    activities!: Activity[];
}
