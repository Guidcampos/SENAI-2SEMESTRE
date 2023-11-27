import React, { useContext } from 'react';
import "./Nav.css"
import { Link } from 'react-router-dom';
import { ThemeContext } from '../../context/ThemeContext';


const Nav = () => {
    const {theme, setTheme} = useContext(ThemeContext)
    const alter = (theme === "light" ? "dark" : "light")

    function AlterarTheme() {

        setTheme (theme === "light" ? "dark": "light")
       
       }
    
    return (
        <nav>
            <Link to= "/">Home</Link> | &nbsp;
            <Link to= "/produtos">Produtos</Link> | &nbsp;
            <Link to= "/importante">Importantes</Link> | &nbsp;
            <Link to= "/meus-pedidos">Meus Pedidos</Link> | &nbsp;
            <Link to= "/login">Login</Link> | &nbsp;
            <button onClick={AlterarTheme}>{alter}</button>
        </nav>
          
          
    );
};

export default Nav;