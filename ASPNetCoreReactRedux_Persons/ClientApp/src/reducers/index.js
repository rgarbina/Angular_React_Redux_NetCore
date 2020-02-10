import { combineReducers } from 'redux';
import userReducer from './userReducer';
import utilReducer from './utilReducer';
import componentReducer from './componentReducer';

export default combineReducers({
    users: userReducer,
    utils: utilReducer,
    components: componentReducer,
});