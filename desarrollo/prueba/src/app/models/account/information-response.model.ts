import { UserResponse } from "../auth/user-response.model";
import { RegisterRequest } from "./register-request.model";

export class InformationResponse extends RegisterRequest {
    collaboratorId!: number;
    user: UserResponse= new UserResponse()
}
