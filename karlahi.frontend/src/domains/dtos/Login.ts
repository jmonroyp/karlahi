import { ILogin } from './interfaces';

export default class LoginDto implements ILogin {
    constructor(username: string, password: string)  {
        this.username = username;
        this.password = password;
    }

    username: string;
    password: string;
}