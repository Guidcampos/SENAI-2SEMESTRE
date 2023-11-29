import React, { useContext, useState } from "react";
import ImageIllustrator from "../../components/ImageIllustrator/ImageIllustrator";
import logo from "../../Assets/images/logo-pink.svg";
import { Input, Button } from "../../components/FormComponents/FormComponents";
import LoginImage from "../../Assets/images/login.svg"
import  api  from '../../Services/Service';
import {UserContext, userDecodeToken} from '../../context/AuthContext'


import "./LoginPage.css";


const LoginPage = () => {

    const [user, setUser] = useState({ email: "adm@adm.com", senha: "adm123" })
    const {userData, setUserData} = useContext(UserContext)

   async function handleSubmit(e) {
        e.preventDefault();
        
        if (user.email.length >=3 && user.senha.length >= 3) {
            //chama a api
            try {
                const promise = await api.post("/Login", {
                    email: user.email,
                    senha: user.senha
                })
                
               
                const userFullToken = userDecodeToken(promise.data.token)
             
                setUserData(userFullToken) //guardar os dados decodificados na variavel global
                
                console.log("Dados Globais");
                console.log(userData);
                localStorage.setItem("token", JSON.stringify(userFullToken))
            } catch (error) {
                alert("Email ou senha invalidos")
            }
        }
        else {
            alert("Preencha os campos corretamente")
        }
        
        

    }

    return (


        <div className="layout-grid-login">
            <div className="login">
                <div className="login__illustration">
                    <div className="login__illustration-rotate"></div>
                    <ImageIllustrator
                        imageRender={LoginImage}
                        altText="Imagem de um homem em frente de uma porta de entrada"
                        additionalClass="login-illustrator "
                    />
                </div>

                <div className="frm-login">
                    <img src={logo} className="frm-login__logo" alt="" />

                    <form className="frm-login__formbox" onSubmit={handleSubmit}>
                        <Input
                            additionalClass="frm-login__entry"
                            type="email"
                            id="login"
                            name="login"
                            required={true}
                            value={user.email}
                            manipulationFunction={(e) => {
                                setUser({
                                    ...user,
                                    email: e.target.value.trim()
                                })
                            }}
                            placeholder="Username"
                        />
                        <Input
                            additionalClass="frm-login__entry"
                            type="password"
                            id="senha"
                            name="senha"
                            required={true}
                            value={user.senha}
                            manipulationFunction={(e) => {
                                setUser({
                                    ...user,
                                    senha: e.target.value.trim()
                                })
                            }}
                            placeholder="****"
                        />

                        <a href="" className="frm-login__link">
                            Esqueceu a senha?
                        </a>

                        <Button
                            textButton="Login"
                            id="btn-login"
                            name="btn-login"
                            type="submit"
                            additionalClass="frm-login__button"

                        />
                    </form>
                </div>
            </div>
        </div>
    );
};

export default LoginPage;
