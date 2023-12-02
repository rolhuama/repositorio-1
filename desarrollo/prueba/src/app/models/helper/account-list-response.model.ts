import { Country } from "../common/country.model";
import { Ubigeo } from "../common/ubigeo.model";
import { DocumentType } from "../common/document-type.model";

export class AccountListResponse {
    documentTypes: DocumentType[] = [];
    countries: Country[] = [];
    departments: Ubigeo[] = [];
}
