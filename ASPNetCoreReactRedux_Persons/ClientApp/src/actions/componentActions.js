import { FETCH_COMPONENT_PESSOA, FETCH_COMPONENT_CIDADE, FETCH_COMPONENT_UF, FETCH_COMPONENT_LINGUA } from "./types";
const API_BASE_URL = 'https://localhost:44375/api/';
const COMPONENT_API_BASE_URL = API_BASE_URL + 'Component/';

export const fetchUF = () => dispatch => {
    fetch(COMPONENT_API_BASE_URL + 'Estados')
        .then(res => res.json())
        .then(ufs => {
            ufs = ufs.map(uf => {
                const { text, value } = uf;
                return {
                    label:text, value
                };
            });
            dispatch({
                type: FETCH_COMPONENT_UF,
                payload: ufs
            });
        })
        .catch(err => console.log(err));
};

export const fetchCidade = (uf) => dispatch => {
    fetch(COMPONENT_API_BASE_URL + 'Cidades' + '/' + uf)
        .then(res => res.json())
        .then(cidades => {
            cidades = cidades.map(cidade => {
                const { text, value } = cidade;
                return {
                    label: text, value
                };
            });
            dispatch({
                type: FETCH_COMPONENT_CIDADE,
                payload: cidades
            });
        })
        .catch(err => console.log(err));
};

export const fetchPessoa = () => dispatch => {
    fetch(COMPONENT_API_BASE_URL + "Pessoas")
        .then(res => res.json())
        .then(pessoas => {
            pessoas = pessoas.map(pessoa => {
                const { text, value } = pessoa;
                return {
                    label: text, value
                };
            });
            dispatch({
                type: FETCH_COMPONENT_PESSOA,
                payload: pessoas
            });
        })
        .catch(err => console.log(err));
};

export const fetchLingua = () => dispatch => {
    fetch(COMPONENT_API_BASE_URL + "Linguas")
        .then(res => res.json())
        .then(linguas => {
            linguas = linguas.map(lingua => {
                const { text, value } = lingua;
                return {
                    label: text, value
                };
            });
            dispatch({
                type: FETCH_COMPONENT_LINGUA,
                payload: linguas
            });
        })
        .catch(err => console.log(err));
};