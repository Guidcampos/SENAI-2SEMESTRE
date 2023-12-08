import  axios  from "axios";

const apiPort = "5000";
const localApi = `http://localhost:${apiPort}/api`
const externalApi = 'https://eventapiguidcampos.azurewebsites.net/api';


const api = axios.create({
    // baseURL: localApi
    baseURL: externalApi
});

export default api;