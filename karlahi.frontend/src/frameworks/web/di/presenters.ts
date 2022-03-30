import IUseCases from './interfaces/iUseCases'
import SessionPresenter from '@adapters/presenters/Session'

export default (useCases: IUseCases) => {
  return {
    session: new SessionPresenter(useCases.session)
  }
}