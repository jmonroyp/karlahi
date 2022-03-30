import { ISessionRepository } from 'domains/useCases/repository-interfaces/iSession';
import { IUserDto } from 'domains/dto/UserDto';
import { IHttp } from '../infraestructures/interfaces/iHttp';
import { IStorage } from '../infraestructures/interfaces/iStorage';

class SessionRepository implements ISessionRepository {

  constructor(
    private readonly http: IHttp,
    private readonly storage: IStorage
  ) {}

  async login(userDTO: IUserDto): Promise<string> {
    const response = await this.http.request({
      method: 'POST',
      url: 'http://localhost:5000/authentication/authenticate',
      headers: {
        'Content-Type': 'application/json',
        'Access-Control-Allow-Origin': '*'
      },
      body: {
        username: userDTO.username,
        password: userDTO.password
      }
    })

    return response?.token ? response.token : '';
  }

  getToken(): Promise<string> {
    return this.storage.get('token')
  }

  setToken(token: string): void {
    this.storage.set('token', token)
  }

  removeToken(): void {
    this.storage.remove('token')
  }

}

export default SessionRepository