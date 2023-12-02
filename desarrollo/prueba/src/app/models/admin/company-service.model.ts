import { ServiceType } from "../common/service-type.model";
import { Company } from "./company.model";
import { CostCenter } from "./cost-center.model";

export class CompanyService {
    id!: number;
    company!: Company;
    companyId!:number
    code!: string | null;
    description!: string;
    type!: ServiceType | null;
    typeId!:number
    costCenter!: CostCenter | null;
    costCenterCode!:string
}
