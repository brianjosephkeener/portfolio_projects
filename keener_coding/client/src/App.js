import Index from './views/Index';
import 'bootstrap/dist/css/bootstrap.min.css';
import './App.css'
import Button from 'react-bootstrap/Button';
import ParticleShow from './ParticleShow';

const App = () => {
  return (
    <div>
    <Index></Index>
    <ParticleShow></ParticleShow>
    </div>
  );
};

export default App;
