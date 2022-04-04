import * as React from 'react'
import * as ReactDOM from 'react-dom'
import { RecoilRoot } from 'recoil'
import Index from './components/Index'
import 'bootstrap/dist/css/bootstrap.min.css';
import './site.css';

const App = () => {
  return (
      <RecoilRoot>
        <Index />
      </RecoilRoot>
  )
}

ReactDOM.render(<App />, document.getElementById('root'))