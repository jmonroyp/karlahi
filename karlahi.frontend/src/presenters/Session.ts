import { ISession } from "../domains/dtos/interfaces";
import Login from "../domains/dtos/Login";
import { ISessionRepository } from "../repositories/interfaces";
import { ISessionPresenter } from "./interfaces";

export default class SessionPresenter implements ISessionPresenter {
  constructor(private readonly repository: ISessionRepository) {}

  async authenticate(username: string, password: string): Promise<string> {
    return await this.repository.authenticate(new Login(username, password));
  }

  getToken(): Promise<string> {
    return this.repository.getToken();
  }

  getSession(): Promise<ISession> {
    return this.repository.getSession();
  }

  setToken(token: string): void {
    this.repository.setToken(token);
  }

  async logout(): Promise<void> {
    this.repository.logout();
  }
}
