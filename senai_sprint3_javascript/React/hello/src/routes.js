import React from 'react';
//import dos componentes de rotas
import { BrowserRouter, Routes, Route } from 'react-router-dom';
import HomePage from './Pages/HomePage/HomePage';
import LoginPage from './Pages/LoginPage/LoginPage';
import ProdutoPage from './Pages/ProdutosPage/ProdutosPage';


//import das paginas

const Rotas = () => {
    return (
        //criar a estrutura de rotas
        <BrowserRouter>
            <Routes>
                <Route element = {<HomePage/>} path='/' exact />
                <Route element = {<LoginPage/>} path='/login'/>
                <Route element = {<ProdutoPage/>} path='/produtos'/>
            </Routes>


        </BrowserRouter>
    );
};

export default Rotas;