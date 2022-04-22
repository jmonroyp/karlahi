import { ISessionRepository } from "./interfaces";
import { IHttp } from "../infraestructures/interfaces/iHttp";
import { IStorage } from "../infraestructures/interfaces/iStorage";
import { ILogin, ISession } from "../domains/dtos/interfaces";
import SessionDto from "../domains/dtos/Session";

export default class SessionRepository implements ISessionRepository {
  constructor(
    private readonly http: IHttp,
    private readonly storage: IStorage
  ) {}

  async authenticate(user: ILogin): Promise<string> {
    const response = await this.http.request({
      method: "POST",
      url: "http://localhost:5000/authentication/authenticate",
      headers: {
        "Content-Type": "application/json",
        "Access-Control-Allow-Origin": "*",
      },
      body: {
        username: user.username,
        password: user.password,
      },
    });

    const token = response?.token ? response.token : "";
    if (token !== "") {
      this.storage.set("token", token);
      this.storage.set("username", response.username);
    }

    return token;
  }

  getToken(): Promise<string> {
    return this.storage.get("token");
  }

  async getSession(): Promise<ISession> {
    const session = new SessionDto();
    session.token = await this.storage.get("token");
    session.username = await this.storage.get("username");
    session.isLoggedIn = session.token !== "";
    return session;
  }

  setToken(token: string): void {
    this.storage.set("token", token);
  }

  async logout(): Promise<void> {
    await this.storage.remove("token");
    await this.storage.remove("username");
  }
}
