import { FETCH_USERS, ADD_USER, EDIT_USER, DELETE_USER } from "./types";
const API_BASE_URL = 'https://localhost:5001/api/';

const PESSOA_API_BASE_URL = API_BASE_URL + 'Pessoa';

export const fetchUsers = () => dispatch => {
    fetch(PESSOA_API_BASE_URL)
        .then(res => res.json())
        .then(users => {
            users = users.map(user => {
                const { pessoaId,
                    ativado,
                    nome,
                    sobreNome,
                    pseudonimo,
                    sexo,
                    dataNascimento,
                    celular,
                    email,
                    cpf,
                    rg,
                    endereco } = user;
                return {
                    pessoaId,
                    ativado,
                    nome,
                    sobreNome,
                    pseudonimo,
                    sexo,
                    dataNascimento,
                    celular,
                    email,
                    cpf,
                    rg,
                    endereco
                };
            });
            dispatch({
                type: FETCH_USERS,
                payload: users
            });
        })
        .catch(err => console.log(err));
};

export const addEditUsers = (userData) => dispatch => {
    var url = PESSOA_API_BASE_URL;
    var meth = 'POST';
    var id = userData[0].pessoaId;
    if (id != 0) {
        meth = 'PUT';
        url += '/' + userData[0].pessoaId
    }

    const headers = new Headers();
    headers.append('Content-Type', 'application/json');
    const requestOptions = {
        method: meth,
        headers,
        body: JSON.stringify(userData[0])
    };
    const request = new Request(url, requestOptions);
    fetch(request);
    //var newUserData = fetch(request).then(function (response) {
    //    return response.json();
    //    }).then(function (data) {
    //        console.log(data)
    //    });

    if (id != 0) {
        dispatch({
            type: EDIT_USER,
            payload: userData
        });
    } else {
        dispatch({
            type: ADD_USER,
            payload: userData
        });
    }
};

export const removeUsers = (usersNameArr) => dispatch => {
    const url = PESSOA_API_BASE_URL + '/Delete';
    const headers = new Headers();
    headers.append('Content-Type', 'application/json');
    const requestOptions = {
        method: 'POST',
        headers,
        body: JSON.stringify(usersNameArr)
    };
    const request = new Request(url, requestOptions);
    fetch(request);
    dispatch({
        type: DELETE_USER,
        payload: usersNameArr
    });
};
