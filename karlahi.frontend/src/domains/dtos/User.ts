import { IUser } from './interfaces';

export default class UserDto implements IUser {
    constructor() {
        this.id = 0;
        this.name = '';
        this.email = '';
        this.password = '';
        this.createdAt = new Date();
        this.updatedAt = new Date();
    }

    id: number;
    name: string;
    email: string;
    password: string;
    createdAt: Date;
    updatedAt: Date;
}