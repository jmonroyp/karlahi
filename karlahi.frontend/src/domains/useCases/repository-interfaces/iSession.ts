import { IUserDto } from '../../dto/UserDto'

export interface ISessionRepository {
  login(userDTO: IUserDto): Promise<string>
  getToken(): Promise<string>
  setToken(token: string): void
  removeToken(): void
}