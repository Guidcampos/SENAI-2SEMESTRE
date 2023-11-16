import React, { useState } from 'react';
import './TipoEventosPage.css';
import Title from "../../components/Title/Title";
import MainContent from "../../components/MainContent/MainContent"
import ImageIllustrator from '../../components/ImageIllustrator/ImageIllustrator';
import Container from '../../components/Container/Container';
import eventTypeImage from '../../Assets/images/tipo-evento.svg'
import { Input, Button } from "../../components/FormComponents/FormComponents";
import api from "../../Services/Service"
import TableTp from './TableTp/TableTp';

const TipoEventos = () => {
    const [titulo, setTitulo] = useState("");
    const [frmEdit, setFrmEdit] = useState(false);
    const [tipoEventos, setTipoEventos] = useState ([
        {idTipoEvento: "123", titulo: "Show"},
        {idTipoEvento: "321", titulo: "Show 2"},
        {idTipoEvento: "567", titulo: "Show 3"}
    
    ]);


    async function handleSubmit(e) {
         //para o submit do formulario
         e.preventDefault();
         //validar pelo menos 3 caracteres 
         if (titulo.trim().length < 3) {
             alert("O titulo deve ter no minimo 3 caracteres")
             return;
         }
 
         try {
             const retorno = await api.post("/TiposEvento", {titulo:titulo})
             console.log("Cadastrado com sucesso");
             console.log(retorno.data);
             setTitulo("");
 
         } catch (error) {
           console.log("deu ruim na api");  
           console.log(error);  
         }
 
         //chamar a api
 
 
     }

    function handleUpdate() {
        alert("Bora atualizar")
    }

    function showUpdateForm () {
        alert("MOSTRAR MENU DE ATUALIZACAO")
    }
   
    function editActionAbort () {
        alert("cancelar edição")
    }

    function handleDelete () {
        alert("DELETAR")

    }


    return (
        <MainContent>
            {/* CADASTRO DE TIPO DE USUARIOS  */}
            <section className='cadastro-evento-section'>

                <Container>
                    <div className='cadastro-evento__box'>
                        <Title titleText="Tipos Eventos" />
                        <ImageIllustrator
                            alterText={"????"}
                            imageRender={eventTypeImage}
                        />
                        <form className='ftipo-evento' onSubmit={frmEdit ? handleUpdate : handleSubmit}>

                            {!frmEdit ?
                                // CADASTRAR
                                (
                                    <>
                                        <Input
                                            type={"text"}
                                            id={"titulo"}
                                            name={"titulo"}
                                            value={titulo}
                                            required={"required"}
                                            placeholder={"Título"}
                                            manipulationFunction={(e) => {
                                                setTitulo(e.target.value)
                                            }}
                                        />
                                        <Button
                                            type={"submit"}
                                            name={"cadastrar"}
                                            id={"cadastrar"}
                                            textButton={"Cadastrar"}
                                        />
                                    </>)

                                :

                                // ATUALIZAR
                                (<>
                                </>)}


                            {/* <Input
                                    
                                    type={"text"}
                                    id={"titulo"}
                                    name={"titulo"}
                                    value={""}
                                    required={"required"}
                                    placeholder={"Título"}
    
                                /> */}

                        </form>

                    </div>
                </Container>

            </section>

            {/* LISTAGEM DE TIPO DE USARIOS  */}
            <section className="lista-eventos-section">
                <Container>
                    <Title titleText={"Lista de Tipo de Eventos"} color='white'/>
                    <TableTp 
                        dados = {tipoEventos}
                        fnUpdate={showUpdateForm}
                        fnDelete={handleDelete}
                    />                

                </Container>
                                
            </section>                        
        </MainContent>

    );
};

export default TipoEventos;



