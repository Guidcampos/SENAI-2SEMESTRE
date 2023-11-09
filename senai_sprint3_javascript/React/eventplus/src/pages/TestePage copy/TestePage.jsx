import React, { useState } from 'react';
import './TestePage.css';
import Input from '../../components/Input/Input';
import Button from '../../components/Button/Button';


const TestePage = () => {
    const [total, setTotal] = useState();
    const [n1, setN1] = useState();
    const [n2, setN2] = useState();

    function handleCalcular(e) {
        e.preventDefault();
        setTotal(parseFloat(n1) + parseFloat(n2))
    }

    return (
        <div>
            <form onSubmit={handleCalcular}>
                <h1>Calculadora</h1>
                <br />
                <Input tipo="number" id="numero1" dicaCampo="Insira o primeiro numero" nome="numero1" valor={n1} fnAltera={setN1} />
                <br />
                <Input tipo="number" id="numero2" dicaCampo="Insira o segundo numero" nome="numero2" valor={n2} fnAltera={setN2} />
                <br />
                <Button textoBotao="Somar" tipo="submit" />

                <p>Resultado: <strong>{total}</strong></p>

            </form>
        </div>
    );
};

export default TestePage;