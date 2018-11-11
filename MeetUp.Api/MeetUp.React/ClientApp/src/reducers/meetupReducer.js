import {
  GET_MEETUPS,
  DELETE_MEETUP,
  ADD_MEETUP,
  GET_MEETUP,
  EDIT_MEETUP,
  SHOW_ERROR
} from "../actions/types";

const initialState = {
  error: "",
  success: "",
  meetup: {},
  meetups: []
};

export default function(state = initialState, action) {
  switch (action.type) {
    case GET_MEETUPS:
      return {
        ...state,
        error: action.payload.error,
        success: "",
        meetups: action.payload.data
      };
    case GET_MEETUP:
      return {
        ...state,
        error: action.payload.error,
        success: "",
        meetup: action.payload.data
      };
    case ADD_MEETUP:
      return {
        ...state,
        error: action.payload.error,
        success: action.payload.success,
        meetups: [action.payload.data, ...state.meetups]
      };
    case SHOW_ERROR:
      return {
        ...state,
        success: "",
        error: action.payload
      };
    case EDIT_MEETUP:
      return {
        ...state,
        error: action.payload.error,
        success: action.payload.success,
        meetups: state.meetups.map(
          meetup =>
            meetup.id === action.payload.data.id
              ? (meetup = action.payload.data)
              : meetup
        )
      };
    case DELETE_MEETUP:
      return {
        ...state,
        error: action.payload.error,
        success: action.payload.success,
        meetups: state.meetups.filter(
          meetup => meetup.id !== action.payload.data
        )
      };
    default:
      return state;
  }
}
