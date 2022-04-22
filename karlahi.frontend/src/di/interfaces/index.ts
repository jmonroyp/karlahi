import { IHttp } from "../../infraestructures/interfaces/iHttp";
import { IStorage } from "../../infraestructures/interfaces/iStorage";
import { ISessionPresenter } from "../../presenters/interfaces";
import { ISessionRepository } from "../../repositories/interfaces";

export interface IRepositories {
  session: ISessionRepository;
}

export interface IInfrastructures {
  http: IHttp;
  storage: IStorage;
}

export default interface IPresenters {
  session: ISessionPresenter;
}
