export class CompanyRequest {
    id!: number;
    legalName!: string;
    commercialName!: string;
    fiscalAddress!: string;
    taxIdentificationNumber!: string;
    economicSector!: string | null;
    country!: string;
    costCenter!: string | null;
    costCenterCode!: string 
    isInterCompany!: boolean;
    isActive!: boolean;
}
