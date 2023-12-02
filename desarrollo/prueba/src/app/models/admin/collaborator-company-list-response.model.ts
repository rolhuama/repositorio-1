import { CollaboratorCompany } from "./collaborator-company.model";

export class CollaboratorCompanyListResponse extends CollaboratorCompany {

    legalName!: string;
    commercialName!: string;
    clientPosition!: string;
}
