import { LOGIN, REGISTER, LOGIN_ERROR, LOG_OUT } from "../actions/types";

const initialState = {
  token: "",
  isAuth: false,
  loginError: ""
};

export default function(state = initialState, action) {
  switch (action.type) {
    case LOGIN:
      return {
        ...state,
        loginError: action.payload.error,
        token: action.payload.data,
        isAuth: action.payload.auth
      };
    case REGISTER:
      return {
        ...state,
        loginError: action.payload.error
      };
    case LOGIN_ERROR:
      return {
        ...state,
        loginError: action.payload
      };
    case LOG_OUT:
      return {
        ...state,
        loginError: action.payload.error,
        token: action.payload.data,
        isAuth: action.payload.auth
      };
    default:
      return state;
  }
}
