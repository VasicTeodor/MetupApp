import { createStore, applyMiddleware, compose } from "redux";
import { connectRouter, routerMiddleware } from "connected-react-router";
import thunk from "redux-thunk";
import createHistory from "history/createBrowserHistory";
import rootReducer from "./reducers/index";

export const history = createHistory();

const initialState = {};
const middleware = [thunk, routerMiddleware(history)];

const store = createStore(
  connectRouter(history)(rootReducer),
  initialState,
  compose(applyMiddleware(...middleware))
);

export default store;

//window.__REDUX_DEVTOOLS_EXTENSION__ && window.__REDUX_DEVTOOLS_EXTENSION__()
