import React, { useEffect, useState } from 'react';
import './TipoEventosPage.css';
import Title from "../../components/Title/Title";
import MainContent from "../../components/MainContent/MainContent"
import ImageIllustrator from '../../components/ImageIllustrator/ImageIllustrator';
import Container from '../../components/Container/Container';
import eventTypeImage from '../../Assets/images/tipo-evento.svg'
import { Input, Button } from "../../components/FormComponents/FormComponents";
import api from "../../Services/Service"
import TableTp from './TableTp/TableTp';
import Notification from "../../components/Notification/Notification"
import Spinner from "../../components/Spinner/Spinner"


const TipoEventos = () => {
    // COMPONENTE DE NOTIFICACAO E SPINNER
    const [notifyUser, setNotifyUser] = useState({});
    const [showSpinner, setShowSpinner] = useState(false);

    const [titulo, setTitulo] = useState("");
    //USADO APENAS PARA TRAZER O TITULO NA EDIÇÃO (idEvento)
    const [idEvento, setIdEvento] = useState(null);
    const [frmEdit, setFrmEdit] = useState(false);
    const [tipoEventos, setTipoEventos] = useState([]);

    //ao carregar a pagina
    useEffect(() => {
        //chamar a api
        async function getTiposEventos() {
           setShowSpinner(true)
            try {
                const promise = await api.get("/TiposEvento")
                console.log(promise.data);
                setTipoEventos(promise.data);

            } catch (error) {
                setNotifyUser({
                    titleNote: "Erro",
                    textNote: `erro na API !`,
                    imgIcon: "warning",
                    imgAlt:
                        "Imagem de ilustração de sucesso. Moça segurando um balão com símbolo de confirmação ok.",
                    showMessage: true,
                });
            }
            setShowSpinner(false)
        }
        getTiposEventos();
        console.log("A API ESTÁ OK!");
    }, []);

    async function handleSubmit(e) {
        //para o submit do formulario
        e.preventDefault();
        //validar pelo menos 3 caracteres 
        if (titulo.trim().length < 3) {
            setNotifyUser({
                titleNote: "Erro",
                textNote: `O titulo deve conter mais de 3 caracteres!`,
                imgIcon: "warning",
                imgAlt:
                    "Imagem de ilustração de sucesso. Moça segurando um balão com símbolo de confirmação ok.",
                showMessage: true,
            });
            return;
        }

        try {
            const retorno = await api.post("/TiposEvento", { titulo: titulo })
            const promise = await api.get("/TiposEvento")
            setTipoEventos(promise.data);
            setNotifyUser({
                titleNote: "Sucesso",
                textNote: `Cadastrado com sucesso!`,
                imgIcon: "success",
                imgAlt:
                    "Imagem de ilustração de sucesso. Moça segurando um balão com símbolo de confirmação ok.",
                showMessage: true,
            });

            console.log(retorno.data);
            setTitulo("");

        } catch (error) {
            console.log("deu ruim na api");
            console.log(error);
        }

        //chamar a api


    }

    async function handleUpdate(e) {
        e.preventDefault();
        if (titulo.trim().length < 3) {
            setNotifyUser({
                titleNote: "Erro",
                textNote: `O titulo deve conter mais de 3 caracteres!`,
                imgIcon: "warning",
                imgAlt:
                    "Imagem de ilustração de sucesso. Moça segurando um balão com símbolo de confirmação ok.",
                showMessage: true,
            });
            return;}
        try {
            const retorno = await api.put('/TiposEvento/' + idEvento, {
                titulo: titulo
            })
            const retornoGet = await api.get("/TiposEvento")
            setTipoEventos(retornoGet.data);
            setNotifyUser({
                titleNote: "Sucesso",
                textNote: `Atualizado com sucesso!`,
                imgIcon: "success",
                imgAlt:
                    "Imagem de ilustração de sucesso. Moça segurando um balão com símbolo de confirmação ok.",
                showMessage: true,
            });
            //cancela a tela de edição
            editActionAbort();



        } catch (error) {
            alert("problemas na atualização")
        }



    }

    async function showUpdateForm(idElemento) {
        setFrmEdit(true);

        //fazer um get para trazer os dados do elemento

        try {
            const promise = await api.get(`/TiposEvento/${idElemento}`)
            console.log(promise.data);
            setTitulo(promise.data.titulo);
            setIdEvento(promise.data.idTipoEvento);

        } catch (error) {
            console.log("Deu ruim na API");
        }




    }

    function editActionAbort() {
        setFrmEdit(false);
        setTitulo("");
        setIdEvento(null);

    }

    async function handleDelete(id) {

        try {
            const retorno = await api.delete(`/TiposEvento/${id}`)
            console.log("deletado com sucesso");
            const promise = await api.get("/TiposEvento")
            setTipoEventos(promise.data);

            setNotifyUser({
                titleNote: "Sucesso",
                textNote: `Deletado com sucesso!`,
                imgIcon: "success",
                imgAlt:
                    "Imagem de ilustração de sucesso. Moça segurando um balão com símbolo de confirmação ok.",
                showMessage: true,
            });




        } catch (error) {
            console.log("deu ruim na api");
            console.log(error);
        }



    }


    return (
        <MainContent>
            <Notification {...notifyUser} setNotifyUser={setNotifyUser} />
           {showSpinner ? <Spinner/> : null}
           
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
                                    <div className='buttons-editbox'>
                                        <Button
                                            type={"submit"}
                                            name={"atualizar"}
                                            id={"atualizar"}
                                            textButton={"Atualizar"}
                                            additionalClass='button-component--middle'
                                        />
                                        <Button
                                            type={"button"}
                                            name={"cancelar"}
                                            id={"cancelar"}
                                            textButton={"Cancelar"}
                                            additionalClass='button-component--middle'
                                            manipulationFunction={editActionAbort}
                                        />
                                    </div>

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
                    <Title titleText={"Lista de Tipo de Eventos"} color='white' />
                    <TableTp
                        dados={tipoEventos}
                        fnUpdate={showUpdateForm}
                        fnDelete={handleDelete}
                    />

                </Container>

            </section>
        </MainContent>

    );
};

export default TipoEventos;



