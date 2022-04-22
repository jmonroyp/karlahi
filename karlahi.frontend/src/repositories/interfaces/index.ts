import { ILogin, ISession } from "../../domains/dtos/interfaces";

export interface ISessionRepository {
  authenticate(user: ILogin): Promise<string>;
  getToken(): Promise<string>;
  setToken(token: string): void;
  logout(): Promise<void>;
  getSession(): Promise<ISession>;

}
