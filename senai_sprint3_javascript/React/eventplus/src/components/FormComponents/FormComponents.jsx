import React from 'react';
import './FormComponents.css'

export const Input = ({
    type,
    id,
    value,
    required,
    additionalClass = "",
    placeholder,
    name,
    manipulationFunction
}) => {
    return (
        <input
            type={type}
            id={id}
            name={name}
            value={value}
            required={required}
            placeholder={placeholder}
            className={`input-component ${additionalClass} `}
            onChange={manipulationFunction}
            autoComplete='off'
        />
    );
}

export const Button = ({id, name, type, additionalClass = "", textButton, manipulationFunction}) => {
    return (
        <button 
            id={id}
            name={name}
            type={type}
            className={`button-component ${additionalClass}`}
            onClick={manipulationFunction}
        >
            {textButton}</button>
    );
}
        
            
            