import IInfrastructures from './interfaces/iInfrastructures'
import Http from  "adapters/infraestructures/Http";
import WebStorage from 'adapters/infraestructures/WebStorage'

export default (): IInfrastructures => {
  return {
    http: new Http(),
    storage: new WebStorage((window as any).sessionStorage)
  }
}