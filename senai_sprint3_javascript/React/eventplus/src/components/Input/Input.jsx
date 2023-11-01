import React, { useState } from 'react';
import './Input.css';

const Input = (props) => {
    const [meuValor, setMeuValor] = useState ();
    return (
        <div>
            <input type={props.tipo} placeholder={props.dicaCampo} id={props.id} name={props.nome} value={props.valor} 
            onChange={(e) => {
               props.fnAltera(e.target.value)
            }}
           />
            

            <span>{props.valor}</span>
        </div>
    );
};

export default Input;