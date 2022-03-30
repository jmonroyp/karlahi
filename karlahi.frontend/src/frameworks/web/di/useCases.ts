import IRepositories from './interfaces/iRepositories'
import IUseCases from './interfaces/iUseCases'
import Session from 'domains/useCases/Session'

export default (repositories: IRepositories): IUseCases => {
  return {
    session: new Session(repositories.session)
  }
}