import React, { useEffect, useState } from "react";
import "./EventosPage.css";
import MainContent from "../../components/MainContent/MainContent";
import Notification from "../../components/Notification/Notification";
import Spinner from "../../components/Spinner/Spinner";
import Title from "../../components/Title/Title";
import Container from "../../components/Container/Container";
import ImageIllustrator from "../../components/ImageIllustrator/ImageIllustrator";
import eventImage from "../../Assets/images/evento.svg";
import TableEv from "../EventosPage/TableEv/TableEv";
import api from "../../Services/Service";
import { Input, Button, Select } from "../../components/FormComponents/FormComponents";
import { dateFormatDbToView1 } from "../../Utils/stringFunction";

const EventosPage = () => {
  // COMPONENTE DE NOTIFICACAO E SPINNER
  const [notifyUser, setNotifyUser] = useState({});
  const [showSpinner, setShowSpinner] = useState(false);

  //GET DOS EVENTOS E TIPO EVENTOS
  const [tipoEventos, setTipoEventos] = useState([]);
  const [eventos, setEventos] = useState([]);

  const [frmEdit, setFrmEdit] = useState(true);

  //Variaveis do evento
  const [nome, setNome] = useState("");
  const [descricao, setDescricao] = useState("");
  const [tEvento, setTEvento] = useState("");
  const [idEvento, setIdEvento] = useState(null);
  const [data, setData] = useState("");
  const [instituicao, setInstituicao] = useState([]);

  //ao carregar a pagina
  useEffect(() => {
    //chamar a api
    async function getEventos() {
      setShowSpinner(true);
      try {
        const retornoEventos = await api.get("/Evento");
        const retornoTEventos = await api.get("/TiposEvento");
        const retornoInstituicao = await api.get("/Instituicao");

        console.log(retornoTEventos.data);
        console.log(retornoEventos.data);
        setTipoEventos(retornoTEventos.data);
        setEventos(retornoEventos.data);
        setInstituicao(retornoInstituicao.data[0].idInstituicao);
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
      setShowSpinner(false);
    }
    setFrmEdit(false)
    getEventos();
    setTipoEventos([])
    console.log("A API ESTÁ OK!");
  }, []);

  async function handleSubmit(e) {
    //para o submit do formulario
    e.preventDefault();
    //validar pelo menos 3 caracteres
    if (nome.trim().length < 3) {
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
      const retornoEvento = await api.post("/Evento", {
        dataEvento: data,
        nomeEvento: nome,
        descricao: descricao,
        idTipoEvento: tEvento,
        idInstituicao: instituicao,
      });
      const retornoGet = await api.get("/Evento");
      setEventos(retornoGet.data);
      setNotifyUser({
        titleNote: "Sucesso",
        textNote: `Cadastrado com sucesso!`,
        imgIcon: "success",
        imgAlt:
          "Imagem de ilustração de sucesso. Moça segurando um balão com símbolo de confirmação ok.",
        showMessage: true,
      });

      console.log(retornoEvento.data);
      setNome("");
      setDescricao("");
      setTEvento("");
      setData("");
      setInstituicao([]);
      // setTipoEventos([]);
    } catch (error) {
      console.log("deu ruim na api");
      console.log(error);
    }

    //chamar a api
  }

  async function handleDelete(id) {
    try {
      const retorno = await api.delete(`/Evento/${id}`);
      console.log(`${retorno} deletado com sucesso`);
      const promise = await api.get("/Evento");
      setEventos(promise.data);

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

  async function showUpdateForm(idElemento) {
    setFrmEdit(true);

    //fazer um get para trazer os dados do elemento

    try {
      const retornoEventos = await api.get(`/Evento/${idElemento}`);
        // const retornoTEventos = await api.get("/TiposEvento");
      //   const retornoInstituicao = await api.get("/Instituicao");

      console.log(retornoEventos.data);
      setNome(retornoEventos.data.nomeEvento);
      setDescricao(retornoEventos.data.descricao);
      setTEvento(retornoEventos.data.tiposEvento.titulo);
      setData(retornoEventos.data.dataEvento);
      setIdEvento(retornoEventos.data.idEvento);
   
      
      //   setInstituicao(retornoEventos.data.idInstituicao);
    } catch (error) {
      console.log("Deu ruim na API");
    }

  }

  function editActionAbort() {
    setFrmEdit(false);
    setNome("");
    setDescricao("");
    setTEvento("");
    setData("");
  }

  async function handleUpdate(e) {
    e.preventDefault();
    if (nome.trim().length < 3) {
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
      const retorno = await api.put(`/Evento/${idEvento}`, {
        dataEvento: data,
        nomeEvento: nome,
        descricao: descricao,
        idTipoEvento: tEvento,
        idInstituicao: instituicao,
      });

      console.log(`${[retorno]}Atualizado com sucesso`);
      const retornoGet = await api.get("/Evento");
      setEventos(retornoGet.data);
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
      alert("problemas na atualização");
    }
  }

  return (
    <MainContent>
      <Notification {...notifyUser} setNotifyUser={setNotifyUser} />
      {showSpinner ? <Spinner /> : null}
      <section className="cadastro-evento-section ">
        <Container>
          <div className="cadastro-evento__box">
            <Title titleText="Eventos" />
            <ImageIllustrator imageRender={eventImage} alterText={"????"} />

            <form
              className="ftipo-evento"
              onSubmit={frmEdit ? handleUpdate : handleSubmit}
            >
              {!frmEdit ? (
                // CADASTRAR
                <>
                  <Input
                    type={"text"}
                    id={"nome"}
                    name={"nome"}
                    value={nome}
                    required={"required"}
                    placeholder={"Nome"}
                    manipulationFunction={(e) => {
                      setNome(e.target.value);
                    }}
                  />
                  <Input
                    type={"text"}
                    id={"descricao"}
                    name={"descricao"}
                    value={descricao}
                    required={"required"}
                    placeholder={"Descrição"}
                    manipulationFunction={(e) => {
                      setDescricao(e.target.value);
                    }}
                  />
                  {/* <Input
                    type={"text"}
                    id={"tEvento"}
                    name={"tEvento"}
                    value={tEvento}
                    required={"required"}
                    placeholder={"Tipo Evento"}
                    manipulationFunction={(e) => {
                      setTEvento(e.target.value);
                    }}
                  /> */}
                  <Select
                    option={tipoEventos}
                    name={"tEvento"}
                    id={"tEvento"}
                    manipulationFunction={(e) => {
                      setTEvento(e.target.value);
                      
                    }}

                  />
                  <Input
                    type={"date"}
                    id={"data"}
                    name={"data"}
                    value={data}
                    required={"required"}
                    placeholder={"dd/mm/aaaa"}
                    manipulationFunction={(e) => {
                      setData(e.target.value);
                    }}
                  />
                  <Button
                    type={"submit"}
                    name={"cadastrar"}
                    id={"cadastrar"}
                    textButton={"Cadastrar"}
                  />
                </>
              ) : (
                // ATUALIZAR
                <>
                  <Input
                    type={"text"}
                    id={"nome"}
                    name={"nome"}
                    value={nome}
                    required={"required"}
                    placeholder={"Nome"}
                    manipulationFunction={(e) => {
                      setNome(e.target.value);
                    }}
                  />
                  <Input
                    type={"text"}
                    id={"descricao"}
                    name={"descricao"}
                    value={descricao}
                    required={"required"}
                    placeholder={"Descrição"}
                    manipulationFunction={(e) => {
                      setDescricao(e.target.value);
                    }}
                  />
                  <Select
                    option={tipoEventos}
                    name={"tEvento"}
                    id={"tEvento"}  
                    manipulationFunction={(e) => {
                      setTEvento(e.target.value);
                    }}

                  />
                  {/* <Input
                    type={"text"}
                    id={"tEvento"}
                    name={"tEvento"}
                    value={tEvento}
                    required={"required"}
                    placeholder={"Tipo Evento"}
                    manipulationFunction={(e) => {
                      setTEvento(e.target.value);
                    }}
                  /> */}
                  <Input
                    type={"date"}
                    id={"data"}
                    name={"data"}
                    value={dateFormatDbToView1(data)}
                    required={"required"}
                    placeholder={"dd/mm/aaaa"}
                    manipulationFunction={(e) => {
                      setData(e.target.value);
                    }}
                  />

                  <div className="buttons-editbox">
                    <Button
                      type={"submit"}
                      name={"atualizar"}
                      id={"atualizar"}
                      textButton={"Atualizar"}
                      additionalClass="button-component--middle"
                    />
                    <Button
                      type={"button"}
                      name={"cancelar"}
                      id={"cancelar"}
                      textButton={"Cancelar"}
                      additionalClass="button-component--middle"
                      manipulationFunction={editActionAbort}
                    />
                  </div>
                </>
              )}
            </form>
          </div>
        </Container>
      </section>

      <section className="lista-eventos-section">
        <Container>
          <Title titleText={"Lista de Eventos"} color="white" />
          <TableEv
            dados={eventos}
            fnUpdate={showUpdateForm}
            fnDelete={handleDelete}
          />
        </Container>
      </section>
    </MainContent>
  );
};

export default EventosPage;
