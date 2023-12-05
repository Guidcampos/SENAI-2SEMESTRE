import React, { useContext, useEffect, useState } from "react";
import Header from "../../components/Header/Header";
import MainContent from "../../components/MainContent/MainContent";
import Title from "../../components/Title/Title";
import Table from "../EventosAlunoPage/TableEva/TableEva";
import Container from "../../components/Container/Container";
import { Select, Select1 } from "../../components/FormComponents/FormComponents";
import Spinner from "../../components/Spinner/Spinner";
import Modal from "../../components/Modal/Modal";
import api from "../../Services/Service";

import "./EventosAlunoPage.css";
import { UserContext } from "../../context/AuthContext";
import Toggle from "../../components/Toggle/Toggle";

const EventosAlunoPage = () => {
  // state do menu mobile
  const [exibeNavbar, setExibeNavbar] = useState(false);
  const [eventos, setEventos] = useState([]);
  // select mocado
  const [quaisEventos, setQuaisEventos] = useState([
    { value: "1", text: "Todos os eventos" },
    { value: "2", text: "Meus eventos" },
  ]);

  const [tipoEvento, setTipoEvento] = useState("1"); //código do tipo do Evento escolhido
  const [showSpinner, setShowSpinner] = useState(false);
  const [showModal, setShowModal] = useState(false);

  // recupera os dados globais do usuário
  const { userData, setUserData } = useContext(UserContext);

  useEffect(() => {

    async function loadEventsType() {
      setShowSpinner(true);


      try {

        if (tipoEvento === "1") {
          const retornoEventos = await api.get("/Evento");
          const retorno = await api.get(`/PresencasEvento/ListarMinhas/${userData.userId}`)

          const dadosMarcados = verificaPresenca(retornoEventos.data, retorno.data)
          setEventos(retornoEventos.data)
        } else {
          let arrEventos = [];
          const retorno = await api.get(`/PresencasEvento/ListarMinhas/${userData.userId}`)

          retorno.data.forEach((element) => {
            arrEventos.push({...element.evento, situacao : element.situacao})
          });

          setEventos(arrEventos)
        }

      } catch (error) {
        console.log(error);
      }
      setShowSpinner(false);
    }

    loadEventsType();

  }, [tipoEvento, userData.userId]);

  const verificaPresenca = (arrAllEvents, eventsUser) => {
    for (let x = 0; x < arrAllEvents.length; x++) {
      for (let i = 0; i < eventsUser.length; i++) {
        if (arrAllEvents[x].idEvento === eventsUser[i].idEvento) {
          arrAllEvents[x].situacao = true;
          break;

        }

      }
    }
    return arrAllEvents;
  }

  // toggle meus eventos ou todos os eventos
  function myEvents(tpEvent) {
    setTipoEvento(tpEvent);
  }

  async function loadMyComentary(idComentary) {
    return "????";
  }

  const showHideModal = () => {
    setShowModal(showModal ? false : true);
  };

  const commentaryRemove = () => {
    alert("Remover o comentário");
  };

  function handleConnect() {
    alert("Desenvolver a função conectar evento");

    
  }
  return (
    <>
      {/* <Header exibeNavbar={exibeNavbar} setExibeNavbar={setExibeNavbar} /> */}

      <MainContent>
        <Container>
          <Title titleText={"Eventos"} additionalClass="custom-title" />

          <Select1
            id="id-tipo-evento"
            name="tipo-evento"
            required={true}
            option={quaisEventos} // aqui o array dos tipos
            manipulationFunction={(e) => myEvents(e.target.value)} // aqui só a variável state
            defaultValue={tipoEvento}
            additionalClass="select-tp-evento"
          />
          <Table
            dados={eventos}
            fnConnect= {handleConnect}
            fnShowModal={() => {
              showHideModal();
            }}

          />
        </Container>
      </MainContent>

      {/* SPINNER -Feito com position */}
      {showSpinner ? <Spinner /> : null}

      {showModal ? (
        <Modal
          userId={userData.userId}
          showHideModal={showHideModal}
          fnDelete={commentaryRemove}

        />
      ) : null}
    </>
  );
};

export default EventosAlunoPage;
