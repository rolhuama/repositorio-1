export class BaseResponse<T>  {
    success!: boolean;
    statusCode!: number;
    message!: string;
    data!: T;
}
