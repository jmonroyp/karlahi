import { IUserDto } from '../../dto/UserDto'

export interface ISessionUseCase {
  login(userDTO: IUserDto): Promise<string>
  getToken(): Promise<string>
  setToken(token: string): void
  removeToken(): void
}