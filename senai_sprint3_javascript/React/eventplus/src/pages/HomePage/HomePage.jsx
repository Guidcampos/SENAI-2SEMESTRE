import React from 'react';
import './HomePage.css'
import Title from '../../components/Title/Title';
import Banner from '../../components/Banner/Banner';
import VisionSection from '../../components/VisionSection/VisionSection';
import MainContent from '../../components/MainContent/MainContent'
import ContactSection from '../../components/ContactSection/ContactSection'
import NextEvent from '../../components/NextEvent/NextEvent'
import Container from '../../components/Container/Container'

const HomePage = () => {
    return (
        <MainContent>
            <Banner />

            <section className='proximos-eventos'>
                <Container>
                    <Title titleText={"Próximos Eventos"} />
                    <div className="events-box">

                        <NextEvent
                            title={"Evento X"}
                            description={"Evento legal"}
                            eventDate={"14/11/2023"}

                        />
                      

                    </div>

                </Container>

            </section>

            <VisionSection />
            <ContactSection />

        </MainContent>
    );
};

export default HomePage;