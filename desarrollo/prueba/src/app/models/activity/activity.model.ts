import { Collaborator } from "../admin/collaborator.model";
import { CompanyService } from "../admin/company-service.model";
import { Company } from "../admin/company.model";
import { ActivityType } from "../common/activity-type.model";
import { ActivityDetail } from "./activity-detail.model";

export class Activity {
    id!: number;
    collaborator: Collaborator= new Collaborator;;
    startDate!: string | null;
    endDate!: string | null;
    durationHours!: number | null;
    durationDays!: number | null;
    durationMonths!: number | null;
    description!: string;
    activityType: ActivityType = new ActivityType;
    companyService: CompanyService = new CompanyService;
    status!: string;
    notifiesHR: boolean = false;
    coordinatesWithClient: boolean = false;
    company: Company = new Company;
    observation!: string;
    ticketCode!: string;
    order!: number;
    week!: number | null;
    detail: ActivityDetail[] = [];

}
