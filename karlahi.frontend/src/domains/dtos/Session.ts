import { ISession } from './interfaces';

export default class SessionDto implements ISession {
    constructor() {
        this.token = '';
        this.username = '';
        this.isLoggedIn = false;   
    }

    setToken(token: string): SessionDto {
        this.token = token;
        return this;
    }

    setUsername(username: string): SessionDto {
        this.username = username;
        return this;
    }

    setIsLoggedIn(isLoggedIn: boolean): SessionDto {
        this.isLoggedIn = isLoggedIn;
        return this;
    }

    token: string;
    username: string;
    isLoggedIn: boolean;
}