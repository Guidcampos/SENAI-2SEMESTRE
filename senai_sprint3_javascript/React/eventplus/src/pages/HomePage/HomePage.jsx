import React, { useEffect, useState } from 'react';
import './HomePage.css'
import Title from '../../components/Title/Title';
import Banner from '../../components/Banner/Banner';
import VisionSection from '../../components/VisionSection/VisionSection';
import MainContent from '../../components/MainContent/MainContent'
import ContactSection from '../../components/ContactSection/ContactSection'
import NextEvent from '../../components/NextEvent/NextEvent'
import Container from '../../components/Container/Container'
import { Axios } from 'axios';

const HomePage = () => {

    useEffect( () => {
        //chamar a api
       async function getProximosEventos() {
            try {
                const promise = await Axios.get('https://localhost:7118/api/Evento/ListarProximos')
                console.log(promise.data)
                setNextEvents(promise.data)
            } catch (error) {
                alert("Deu ruim na API")
            }
            
        }
    },[]

    );

    //FAKE MOCK -- API MOCADA
    const [nextEvents, setNextEvents] = useState([
        { id: 1, title: 'Evento teste', descricao: "Evento para testar os cards", data: "10/11/2023" },
        { id: 2, title: 'Evento teste 2', descricao: "Segundo Evento para testar os cards", data: "11/11/2023" }

    ]);




    return (
        <MainContent>
            <Banner />

            <section className='proximos-eventos'>
                <Container>
                    <Title titleText={"Próximos Eventos"} />
                    <div className="events-box">

                        {
                            nextEvents.map((e) => {
                                return (
                                    <NextEvent
                                        idEvento={e.id}
                                        title={e.title}
                                        description={e.descricao}
                                        eventDate={e.data}

                                    />)
                            })
                        }



                    </div>

                </Container>

            </section>

            <VisionSection />
            <ContactSection />

        </MainContent>
    );
};

export default HomePage;