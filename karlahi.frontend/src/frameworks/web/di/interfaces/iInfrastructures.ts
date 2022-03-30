import { IHttp } from "adapters/infraestructures/interfaces/iHttp";
import { IStorage } from "adapters/infraestructures/interfaces/iStorage";

export default interface IInfrastructures {
  http: IHttp
  storage: IStorage,
}