import React, { useContext } from 'react';
import "./ImportantePage.css"
import { ThemeContext } from '../../context/ThemeContext';



const ImportantePage = () => {
    const { theme } = useContext(ThemeContext)
    return (
        <>
        <h1>pagina de itens importantes</h1>
        <span>Tema atual: {theme}</span>
        </>

    );
};

export default ImportantePage;