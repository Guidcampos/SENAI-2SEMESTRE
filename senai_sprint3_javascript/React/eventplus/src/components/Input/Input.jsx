
import './Input.css';

const Input = (props) => {
   
    return (
        <div>
            <input
                type={props.tipo}
                placeholder={props.dicaCampo}
                id={props.id}
                name={props.nome}
                value={props.valor}
                // Encapsular a função em uma arrow function para não executar na montagem/renderização do componente
                onChange={(e) => { props.fnAltera(e.target.value) }}
            />


            <span>{props.valor}</span>
        </div>
    );
};

export default Input;