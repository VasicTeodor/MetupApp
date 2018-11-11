import {
  GET_MEETUP,
  DELETE_MEETUP,
  ADD_MEETUP,
  GET_MEETUPS,
  SHOW_ERROR,
  GOING_ON_MEETUP,
  NOT_GOING_ON_MEETUP,
  EDIT_MEETUP
} from "./types";
import axios from "axios";
import { push } from "connected-react-router";

export const getMeetups = () => async dispatch => {
  if (localStorage.getItem("token")) {
    let error = 0;
    const res = await axios
      .get("http://localhost:3029/api/MeetUp/GetAllMeetups", {
        headers: {
          Authorization: "Bearer " + localStorage.getItem("token")
        }
      })
      .catch(function(e) {
        error = 1;
      });

    if (error !== 0) {
      dispatch({
        type: SHOW_ERROR,
        payload: "Error while getting meetups from db."
      });
    } else {
      dispatch({
        type: GET_MEETUPS,
        payload: {
          data: res.data,
          error: ""
        }
      });
    }
  }
};

export const getMeetup = id => async dispatch => {
  if (localStorage.getItem("token")) {
    let error = 0;
    const res = await axios
      .get(`http://localhost:3029/api/MeetUp/GetMeetup?id=${id}`, {
        headers: {
          Authorization: "Bearer " + localStorage.getItem("token")
        }
      })
      .catch(function(e) {
        error = 1;
      });

    if (error !== 0) {
      dispatch({
        type: SHOW_ERROR,
        payload: "Error while getting meetup."
      });
    } else {
      dispatch({
        type: GET_MEETUP,
        payload: {
          data: res.data,
          error: ""
        }
      });
    }
  }
};

export const deleteMeetup = id => async dispatch => {
  if (localStorage.getItem("token")) {
    let error = 0;
    await axios
      .delete(`http://localhost:3029/api/MeetUp/DeleteMeetup?id=${id}`, {
        headers: {
          Authorization: "Bearer " + localStorage.getItem("token")
        }
      })
      .catch(function(e) {
        error = 1;
      });

    if (error !== 0) {
      dispatch({
        type: SHOW_ERROR,
        payload: "Error while canceling meetup"
      });
    } else {
      dispatch({
        type: DELETE_MEETUP,
        payload: {
          data: id,
          error: "",
          success: `Meetup with id: ${id} canceled!`
        }
      });
    }
  }
};

export const addMeetup = meetup => async dispatch => {
  if (true) {
    let error = 0;
    await axios
      .post("http://localhost:3029/api/MeetUp/AddMeetup", meetup, {
        headers: {
          Authorization: "Bearer " + localStorage.getItem("token")
        }
      })
      .catch(function(e) {
        error = 1;
      });

    if (error !== 0) {
      dispatch({
        type: SHOW_ERROR,
        payload: "Error while saving meetup"
      });
    } else {
      dispatch({
        type: ADD_MEETUP,
        payload: {
          data: meetup,
          error: "",
          success: "Meetup saved to db!"
        }
      });
      dispatch(push("/meetups"));
    }
  }
};

export const editMeetup = meetup => async dispatch => {
  if (localStorage.getItem("token")) {
    let error = 0;
    const res = await axios
      .put("http://localhost:3029/api/MeetUp/UpdateMeetup", meetup, {
        headers: {
          Authorization: "Bearer " + localStorage.getItem("token")
        }
      })
      .catch(function(e) {
        error = 1;
      });

    if (error !== 0) {
      dispatch({
        type: SHOW_ERROR,
        payload: "Error while updating meetup"
      });
    } else {
      dispatch({
        type: EDIT_MEETUP,
        payload: {
          data: res.data,
          error: "",
          success: `Mettup ${meetup.title} updated!`
        }
      });
      dispatch(push("/meetups"));
    }
  }
};

export const goingOnMeetup = model => async dispatch => {
  if (true) {
    let error = 0;
    await axios
      .put("http://localhost:3029/api/MeetUp/GoingToMeetup", model, {
        headers: {
          Authorization: "Bearer " + localStorage.getItem("token")
        }
      })
      .catch(function(e) {
        error = 1;
      });

    if (error !== 0) {
      dispatch({
        type: SHOW_ERROR,
        payload: "Error while saving meetup"
      });
    } else {
      dispatch({
        type: GOING_ON_MEETUP,
        payload: {
          error: "",
          success: ""
        }
      });
      dispatch(push("/meetups"));
    }
  }
};

export const notGoingOnMeetup = model => async dispatch => {
  if (true) {
    let error = 0;
    await axios
      .put("http://localhost:3029/api/MeetUp/CancelGoingToMeetup", model, {
        headers: {
          Authorization: "Bearer " + localStorage.getItem("token")
        }
      })
      .catch(function(e) {
        error = 1;
      });

    if (error !== 0) {
      dispatch({
        type: SHOW_ERROR,
        payload: "Error while updating meetup"
      });
    } else {
      dispatch({
        type: NOT_GOING_ON_MEETUP,
        payload: {
          error: "",
          success: ""
        }
      });
      dispatch(push("/meetups"));
    }
  }
};
