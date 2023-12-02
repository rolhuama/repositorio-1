import { Company } from "../admin/company.model";

export class ActivityType {
    id!: number;
    code!: string;
    description!: string;
    company!:Company | null
    companyId!:number
}
