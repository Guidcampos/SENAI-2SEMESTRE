import React, { useState } from 'react';
import './TipoEventosPage.css';
import Title from "../../components/Title/Title";
import MainContent from "../../components/MainContent/MainContent"
import ImageIllustrator from '../../components/ImageIllustrator/ImageIllustrator';
import Container from '../../components/Container/Container';
import eventTypeImage from '../../Assets/images/tipo-evento.svg'
import { Input } from "../../components/FormComponents/FormComponents";


const TipoEventos = () => {

    const [frmEdit , setfrmEdit] = useState (false);
    function handleUpdate () {
        
    }
    function handlreSubmit () {
        
    }


    return (
        <MainContent>
            <section className='cadastro-evento-section'>

                <Container>
                    <div className='cadastro-evento__box'>
                        <Title titleText="Tipos Eventos" />
                        <ImageIllustrator
                            alterText={"????"}
                            imageRender={eventTypeImage}
                        />
                        <form onSubmit={frmEdit ? handleUpdate : handlreSubmit}>
                            <p>componente de formulario</p>
                            <Input/>
                           
                        </form>

                    </div>
                </Container>

            </section>

        </MainContent>

    );
};

export default TipoEventos;