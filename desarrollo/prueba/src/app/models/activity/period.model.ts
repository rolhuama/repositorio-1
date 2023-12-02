import { MasterDetailTable } from "../common/master-detail-table.model";

export class Period {
    id!: string;
    year!: number;
    month!: number;
    description!: string;
    stateMasterTable!: MasterDetailTable | null;
    state!: string;
    maximumHours!: number;
    startDate!: string;
    endDate!: string;
}
