import React from 'react';
import { Link } from 'react-router-dom';

const NotFoundPage = () => {
    return (
        <>
            <h1>Pagina não encontrada</h1>
            <Link to = "/">Home </Link>
        </>
    );
};

export default NotFoundPage;