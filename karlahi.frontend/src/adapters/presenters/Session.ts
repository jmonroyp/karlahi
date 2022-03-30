import UserDto from "domains/dto/UserDto";
import { ISessionUseCase } from 'domains/useCases/interfaces/iSession';
import { ISessionPresenter } from './interfaces/iSession';

class SessionPresenter implements ISessionPresenter {

  constructor(
    private readonly useCases: ISessionUseCase
  ) {}

  async login(id: string, pw: string): Promise<string> {
    return await this.useCases.login(new UserDto({ id, pw }))
  }

  getToken(): Promise<string> {
    return this.useCases.getToken()
  }

  setToken(token: string): void {
    this.useCases.setToken(token)
  }

  removeToken(): void {
    this.useCases.removeToken()
  }

}

export default SessionPresenter