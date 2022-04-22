import SessionPresenter from "../presenters/Session";
import { IRepositories } from "./interfaces";

export default (repository: IRepositories) => {
  return {
    session: new SessionPresenter(repository.session)
  }
};