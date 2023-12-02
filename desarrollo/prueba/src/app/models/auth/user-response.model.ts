export class UserResponse {
    id!: string
    name!: string | null;
    email!: string;
    familyName!: string | null;
    givenName!: string | null;
    picture!: string | null;
    role!: string;
    isRegistered!: boolean | null;
    personId!: string
    position!: string;
    tokenCreated!: string;
    tokenExpires!: string;
}
