import { combineReducers } from "redux";
import meetupReducer from "./meetupReducer";
import userReducer from "./userReducer";

export default combineReducers({
  meetup: meetupReducer,
  user: userReducer
});
