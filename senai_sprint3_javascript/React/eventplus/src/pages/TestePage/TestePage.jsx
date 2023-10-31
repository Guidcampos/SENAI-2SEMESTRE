import React from 'react';
import './TestePage.css';
import Input from '../../components/Input/Input';
import Button from '../../components/Button/Button';
import Header from '../../components/Header/Header';

const TestePage = () => {
    return (
        <div>
            <Header/>
            <Input/>
            <Input/>
            <Button/>
        </div>
    );
};

export default TestePage;