import React from 'react';
//import dos componentes de rotas
import { BrowserRouter, Routes, Route } from 'react-router-dom';
import HomePage from './pages/HomePage/HomePage';
import EventosPage from './pages/EventosPage/EventosPage';
import TipoEventos from './pages/TipoEventosPage/TipoEventosPage';
import LoginPage from './pages/LoginPage/LoginPage';
import TesdePage from './pages/TestePage/TestePage';
import Header from './components/Header/Header';

//import das paginas

const Rotas = () => {
    return (
        //criar a estrutura de rotas
        <BrowserRouter>
            <Header/>
            <Routes>
                <Route element = {<HomePage/>} path='/' exact />
                <Route element = {<EventosPage/>} path='/eventos'/>
                <Route element = {<TipoEventos/>} path='/tipo-eventos'/>
                <Route element = {<LoginPage/>} path='/login'/>
                <Route element = {<TesdePage/>} path='/teste'/>
                
            </Routes>


        </BrowserRouter>
    );
};

export default Rotas;