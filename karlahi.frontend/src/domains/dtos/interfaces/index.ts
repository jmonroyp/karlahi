export interface IUser {
    id: number;
    name: string;
    email: string;
    password: string;
    createdAt: Date;
    updatedAt: Date;
}

export interface ILogin {
    username: string;
    password: string;
}

export interface IRegister {
    email: string;
    password: string;
    name: string;
} 

export interface ISession {
    token: string;
    username: string;
    isLoggedIn: boolean;
}

