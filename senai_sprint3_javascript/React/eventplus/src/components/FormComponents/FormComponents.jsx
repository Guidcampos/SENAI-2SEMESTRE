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