import infrastructures from './Infraestructures';
import repositories from './Repositories';
import presenters from './Presenters';
import IPresenters from './interfaces';

const cInfrastructures = infrastructures();
const cRepositories = repositories(cInfrastructures);
const cPresenters = presenters(cRepositories)

export default { 
    session: cPresenters.session
} as IPresenters;