import React, { useContext } from 'react';
import { ThemeContext } from '../../context/ThemeContext';



const MeusPedidosPage = () => {
    const {theme} = useContext(ThemeContext);
  
    return (
        <>
        <h1> Meus pedidos</h1>
        <span>Tema atual: {theme}</span>
        </>

    );
};

export default MeusPedidosPage;