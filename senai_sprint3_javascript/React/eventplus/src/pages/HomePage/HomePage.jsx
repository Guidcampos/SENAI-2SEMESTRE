import React, { useEffect, useState } from 'react';
import './HomePage.css'
import Title from '../../components/Title/Title';
import Banner from '../../components/Banner/Banner';
import VisionSection from '../../components/VisionSection/VisionSection';
import MainContent from '../../components/MainContent/MainContent'
import ContactSection from '../../components/ContactSection/ContactSection'
import NextEvent from '../../components/NextEvent/NextEvent'
import Container from '../../components/Container/Container'
import  api  from '../../Services/Service';

const HomePage = () => {
    const [nextEvents, setNextEvents] = useState([]);

    useEffect( () => {
        //chamar a api
       async function getProximosEventos() {
            try {
                const promise = await api.get( "/Evento/ListarProximos")
                console.log(promise.data);
                setNextEvents(promise.data);
                
            } catch (error) {
                alert("Deu ruim na API")
            }
        }
        getProximosEventos();
        console.log("A HOME FOI MONTADA!");
    },[]);

   




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
                                        idEvento={e.idEvento}
                                        title={e.nomeEvento}
                                        description={e.descricao}
                                        eventDate={e.dataEvento}

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