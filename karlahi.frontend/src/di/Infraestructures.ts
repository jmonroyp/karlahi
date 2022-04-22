import Http from "../infraestructures/Http";
import { IInfrastructures } from "./interfaces";
import WebStorage from "../infraestructures/WebStorage";

// const infraestructures = () => {
//   return {
//     http: new Http(),
//     storage: new WebStorage((window as any).sessionStorage),
//   } as IInfrastructures;
// };

export default (): IInfrastructures => {
  return {
    http: new Http(),
    storage: new WebStorage((window as any).sessionStorage),
  };
};

// export default infraestructures;
