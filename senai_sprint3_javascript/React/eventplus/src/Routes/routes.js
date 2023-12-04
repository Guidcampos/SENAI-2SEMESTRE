import React from 'react';
//import dos componentes de rotas
import { BrowserRouter, Routes, Route } from 'react-router-dom';
import HomePage from '../pages/HomePage/HomePage';
import EventosPage from '../pages/EventosPage/EventosPage';
import EventosAlunoPage from '../pages/EventosAlunoPage/EvetosAlunoPage';
import TipoEventos from '../pages/TipoEventosPage/TipoEventosPage';
import LoginPage from '../pages/LoginPage/LoginPage';
import TesdePage from '../pages/TestePage/TestePage';
import Header from '../components/Header/Header';
import Footer from '../components/Footer/Footer';
import { PrivateRoute } from '../Routes/PrivateRoute'

//import das paginas

const Rotas = () => {
    return (
        //criar a estrutura de rotas
        <BrowserRouter>
            <Header />
            <Routes>
                <Route element={<HomePage />} path='/' exact />

                <Route
                    path='/tipo-eventos'
                    element={
                        <PrivateRoute redirectTo='/'>
                            <TipoEventos />
                        </PrivateRoute>}
                />

                <Route
                    path='/eventos'
                    element={
                        <PrivateRoute redirectTo='/'>
                            <EventosPage />
                        </PrivateRoute>}
                />

                <Route
                    path='/eventos-aluno'
                    element={
                        <PrivateRoute redirectTo='/'>
                            <EventosAlunoPage />
                        </PrivateRoute>}
                />

                <Route element={<LoginPage />} path='/login' />
                <Route element={<TesdePage />} path='/teste' />

            </Routes>
            <Footer />


        </BrowserRouter>
    );
};

export default Rotas;

