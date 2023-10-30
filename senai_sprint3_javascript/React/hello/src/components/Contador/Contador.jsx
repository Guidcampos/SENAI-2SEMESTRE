import React, { Fragment, useState} from "react";
import './Contador.css';

const Contador = () => {
    
    const [contador, setContador] = useState(0);

    function handleIncrementar() {
        setContador(contador + 1);
        
    }

    return (
        <>
        <p>{contador}</p>
        <button onClick={handleIncrementar}>Incrementar</button>
        </>
    );
}

export default Contador;