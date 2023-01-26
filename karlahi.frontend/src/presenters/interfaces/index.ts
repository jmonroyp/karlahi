import { ISession } from "../../domains/dtos/interfaces";

export interface ISessionPresenter {
  authenticate(username: string, password: string): Promise<string>;
  getSession(): Promise<ISession>;
  setToken(token: string): void;
  logout(): Promise<void>;
}
