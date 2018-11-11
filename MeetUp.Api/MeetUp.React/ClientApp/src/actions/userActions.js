import { LOGIN, REGISTER, LOGIN_ERROR, LOG_OUT } from "./types";
import axios from "axios";
import { push } from "connected-react-router";

export const login = (username, password) => async dispatch => {
  let error = 0;
  let loginData = {
    username: username,
    password: password
  };
  let token;
  const res = await axios
    .post(`http://localhost:3029/api/User/Login`, loginData)
    .catch(function(e) {
      error = 1;
    })
    .then(function(result) {
      if (error !== 1) {
        token = result.data.token;
        localStorage.setItem("token", token);
        localStorage.setItem("userId", result.data.id);
      }
    });

  if (error !== 0) {
    dispatch({
      type: LOGIN_ERROR,
      payload: "Wrong username or password"
    });
  } else {
    dispatch({
      type: LOGIN,
      payload: {
        data: token,
        error: "",
        auth: true
      }
    });
    dispatch(push("/meetups"));
  }
};

export const registerUser = user => async dispatch => {
  let error = 0;
  const res = await axios
    .post(`http://localhost:3029/api/User/Register`, user)
    .catch(function(e) {
      error = 1;
    });

  if (error !== 0) {
    dispatch({
      type: LOGIN_ERROR,
      payload: "Error while creating account"
    });
  } else {
    dispatch({
      type: REGISTER,
      payload: {
        data: res.data,
        error: ""
      }
    });
    dispatch(push("/"));
  }
};

export const logout = () => async dispatch => {
  if (localStorage.getItem("token")) {
    dispatch({
      type: LOG_OUT,
      payload: {
        error: "",
        data: "",
        auth: false
      }
    });
    dispatch(push("/"));
  }
};
