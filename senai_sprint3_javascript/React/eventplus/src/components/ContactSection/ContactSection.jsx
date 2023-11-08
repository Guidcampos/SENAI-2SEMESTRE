import React from 'react';
import './ContactSection.css'
import Title from '../Title/Title';
import contatoMap from '../../Assets/images/contato-map.png'


const ContactSection = () => {
    return (
        <section className='contato'>
            <Title titleText={"Contato"} />

            <div className='contato__endereco-box'>
                <img
                    src={contatoMap}
                    alt=""
                    className='contato__img-map'
                />

                <p>
                    Rua Niterói, 180 - Centro <br />
                    Sao Caetano do sul - SP <br />
                    <a
                        href="tel: +55114225200"
                        className='contato__telefone'
                        
                    >(11)4225-200</a>
                </p>


            </div>

        </section>
    );
};

export default ContactSection;