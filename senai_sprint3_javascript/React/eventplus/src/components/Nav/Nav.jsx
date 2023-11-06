import React from 'react';
import './Nav.css'
import { Link } from 'react-router-dom';
import logoMobile from '../../Assets/images/logo-white.svg'
import logoDesktop from '../../Assets/images/logo-pink.svg'

const Nav = ({setExibeNavbar, exibeNavbar}) => {
    return (
        <nav className= { `navbar ${exibeNavbar ? "exibeNavbar" : ""}`}>
            <span className='navbar__close ' onClick={() => setExibeNavbar(false)}>x</span>
            <Link to="/">
                <img src={window.innerWidth >= 992 ? logoDesktop : logoMobile}
                    className='eventlogo__logo-image '
                    alt="Event plus Logo"
                />
            </Link>

            <div className='navbar__items-box'>
                <Link to="/" className='navbar__item'>Home</Link>
                <Link to="/tipo-eventos" className='navbar__item'>Tipo Eventos</Link>
                <Link to="/eventos" className='navbar__item'>Eventos</Link>
                <Link to="/login" className='navbar__item'>Login</Link>
            </div>

        </nav>
    );
};

export default Nav;