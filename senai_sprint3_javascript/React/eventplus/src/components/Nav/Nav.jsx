import React from 'react';
import './Nav.css'
import { Link } from 'react-router-dom';
import logoMobile from '../../Assets/images/images/logo-white.svg'
import logoDesktop from '../../Assets/images/images/logo-pink.svg'

const Nav = () => {
    return (
        <nav className='navbar'>
            <span className='navbar__close'></span>
            <Link to = "/">
                <img src={window.innerHeight >= 992 ? logoDesktop : logoMobile} className='eventlogo__logo-image' alt="Event plus Logo" />
            </Link>

            <div className='navbar__items-box'>
                <Link to = "/">Home</Link>
                <Link to = "/tipo-eventos">Tipo Eventos</Link>
                <Link to = "/eventos">Eventos</Link>
                <Link to = "/login">Login</Link>
            </div>

        </nav>
    );
};

export default Nav;