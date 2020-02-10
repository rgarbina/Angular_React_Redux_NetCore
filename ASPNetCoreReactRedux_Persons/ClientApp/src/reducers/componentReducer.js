import { FETCH_COMPONENT_PESSOA, FETCH_COMPONENT_CIDADE, FETCH_COMPONENT_UF, FETCH_COMPONENT_LINGUA }  from "../actions/types";

const initialState = {
    allPessoas: [],
    allCidades: [],
    allLinguas: [],
    allEstados: [],
    message: "Default",
    variant: "success"
};

export default function(state = initialState, action) {
    switch(action.type) {
        case FETCH_COMPONENT_PESSOA:
            return {
                ...state,
                allPessoas: action.payload
            }
        case FETCH_COMPONENT_CIDADE:
            return {
                ...state,
                allCidades: action.payload
            }
        case FETCH_COMPONENT_UF:
            return {
                ...state,
                allEstados: action.payload
            }
        case FETCH_COMPONENT_LINGUA:
            return {
                ...state,
                allLinguas: action.payload
            }
        default:
            return state;
    }
}