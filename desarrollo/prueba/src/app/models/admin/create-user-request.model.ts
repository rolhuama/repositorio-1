export class CreateUserRequest {
    userName!: string;
    email!: string;
    roleId!: string;
    lockoutEnabled!: boolean;
}
