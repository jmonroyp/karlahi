import { IInfrastructures } from "./interfaces";
import SessionRepository from "../repositories/Session";
import { IRepositories } from "./interfaces";

export default (infrastructure: IInfrastructures): IRepositories => {
  return {
    session: new SessionRepository(infrastructure.http, infrastructure.storage),
  };
};
