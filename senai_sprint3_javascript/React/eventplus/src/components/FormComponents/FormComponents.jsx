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

export const Button = ({ id, name, type, additionalClass = "", textButton, manipulationFunction }) => {
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

export const Select = ({
    option = [],
    name,
    id,
    required,
    additionalClass,
    manipulationFunction = "",
    defaultValue



}) => {
    return (
        <select
            name={name}
            id={id}
            required={required}
            className={`input-component ${additionalClass}`}
            onChange={manipulationFunction}
            value={defaultValue}
        >
            <option value="">Selecione</option>
            {option.map((opt) => {
                return (
                    <option key={opt.idTipoEvento} value={opt.idTipoEvento}>{opt.titulo}</option>
                )

            })}
        </select>

    );
}
export const Select1 = ({
    option = [],
    name,
    id,
    required,
    additionalClass,
    manipulationFunction = "",
    defaultValue



}) => {
    return (
        <select
            name={name}
            id={id}
            required={required}
            className={`input-component ${additionalClass}`}
            onChange={manipulationFunction}
            value={defaultValue}
        >
            <option value="">Selecione</option>
            {option.map((opt) => {
                return (
                    <option key={opt.value} value={opt.value}>{opt.text}</option>
                )

            })}
        </select>

    );
}

