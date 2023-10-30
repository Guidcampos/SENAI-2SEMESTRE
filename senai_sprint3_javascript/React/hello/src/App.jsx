import './App.css';
import Titulo from './components/Titulo/Titulo';
import Card from './components/CardEvento/Card-evento';
import Contador from './components/Contador/Contador';

function App() {
  return (
    <div className="App">
      <h1>Hello React</h1>
      <Titulo texto = "Guilherme"/>
      <Card tituloDoEvento = "Event+" texto = "Evento sobre javascript que será na próxima semana" textoLink = "Conectar" desabilitar={false}/>
      <Card tituloDoEvento = "Event-" texto = "Evento sobre C# que será na próxima semana" textoLink = "Conectar" desabilitar={true}/>
      <Contador/>
   
    </div>
  );
}

export default App;