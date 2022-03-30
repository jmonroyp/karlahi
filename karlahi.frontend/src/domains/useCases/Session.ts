import { ISessionUseCase } from './interfaces/iSession'
import { ISessionRepository } from './repository-interfaces/iSession'
import { IUserDto } from '../dto/UserDto'

class SessionUseCase implements ISessionUseCase {

  constructor(
    private readonly sessionRepo: ISessionRepository
  ) {}

  async login(userDTO: IUserDto): Promise<string> {
    const token = await this.sessionRepo.login(userDTO)
    this.setToken(token)
    return token
  }

  getToken(): Promise<string> {
    return this.sessionRepo.getToken()
  }

  setToken(token: string): void {
    this.sessionRepo.setToken(token)
  }

  removeToken(): void {
    this.sessionRepo.removeToken()
  }

}

export default SessionUseCase;