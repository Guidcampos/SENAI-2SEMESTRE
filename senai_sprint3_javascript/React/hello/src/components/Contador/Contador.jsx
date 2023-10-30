import React, { Fragment, useState} from "react";
import './Contador.css';

const Contador = () => {
    
    const [contador, setContador] = useState(0);

    function handleDecrementar() {
       
        setContador(contador > 0 ? contador - 1 : 0)
    //     if(contador > 0){
    //     setContador(contador - 1);
    // }
    }


    function handleIncrementar() {
        setContador(contador + 1);
        
    }

    return (
        <>
        <p>{contador}</p>
        <button onClick={ () => {handleIncrementar()}}>Incrementar</button>
        <button onClick={ () => {handleDecrementar()}}>Decrementar</button>
        </>
    );
}

export default Contador;