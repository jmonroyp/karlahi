import { ISessionRepository } from '@domains/useCases/repository-interfaces/iSession'

export default interface IRepositories {
  session: ISessionRepository
}