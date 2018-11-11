import React, { Component } from "react";
import PropTypes from "prop-types";
import { connect } from "react-redux";
import {
  getMeetup,
  goingOnMeetup,
  notGoingOnMeetup
} from "../../actions/meetupActions";

class ViewMeetup extends Component {
  state = {
    date: "",
    lecture: {},
    createdBy: {},
    maxVisitors: 0,
    currentVisitorsCount: 0,
    from: "",
    to: "",
    address: {},
    title: "",
    id: 0,
    error: "",
    visitors: [],
    going: false
  };

  mapStateToProps = state => ({
    meetup: state.meetup.meetup,
    error: state.meetup.error,
    success: state.meetup.success
  });

  componentWillReceiveProps(nextProps, nextState) {
    const {
      date,
      lecture,
      createdBy,
      maxVisitors,
      currentVisitorsCount,
      from,
      to,
      address,
      id,
      title,
      visitors
    } = nextProps.meetup;

    let arry = nextProps.meetup.visitors;

    if (arry !== [] || arry !== null) {
      for (let i = 0; i < arry.length; i++) {
        if (JSON.stringify(arry[i].userId) === localStorage.getItem("userId")) {
          this.setState({ going: true });
          break;
        }
      }
    }

    this.setState({
      date: date.substring(0, date.indexOf("T")),
      lecture,
      createdBy,
      maxVisitors,
      currentVisitorsCount,
      from,
      to,
      address,
      id,
      title,
      visitors
    });
  }

  componentDidMount() {
    const { id } = this.props.match.params;
    this.props.getMeetup(id);
  }

  navigateBack = () => {
    this.props.history.push("/meetups");
  };

  setGoing = () => {
    if (
      parseInt(this.state.currentVisitorsCount, 10) <
      parseInt(this.state.maxVisitors, 10)
    ) {
      this.setState({ error: "" });

      let model = {
        meetupId: this.state.id,
        userId: localStorage.getItem("userId")
      };

      this.props.goingOnMeetup(model);
    } else {
      this.setState({ error: "Maximum visitors count is reached." });
    }
  };

  cancelGoing = () => {
    let model = {
      meetupId: this.state.id,
      userId: localStorage.getItem("userId")
    };

    this.props.notGoingOnMeetup(model);
  };

  render() {
    const {
      date,
      lecture,
      maxVisitors,
      currentVisitorsCount,
      from,
      to,
      address,
      title
    } = this.state;

    const notGoing = (
      <button className="btn btn-danger" onClick={this.cancelGoing}>
        NOT GOING
      </button>
    );

    const going = (
      <button className="btn btn-success mr-2" onClick={this.setGoing}>
        GOING
      </button>
    );

    return (
      <React.Fragment>
        <div className="container text-center">
          <div className="row justify-content-center mb-4">
            <h1 className="display-2 text-center">{title}</h1>
          </div>
          <div className="row justify-content-center mb-2">
            <div className="col text-capitalize ">
              <p className="text-secondary text-sm-center">
                Location: {address.street + ", " + address.number}
              </p>
            </div>
            <div className="col text-capitalize text-sm-center">
              <p className="text-secondary">
                Date: {date + "," + from + " - " + to}
              </p>
            </div>
            <div className="col text-capitalize text-sm-center">
              <p className="text-secondary">
                Visitors:
                {currentVisitorsCount + "/" + maxVisitors}
              </p>
            </div>
          </div>
          <div className="row justify-content-center mb-2">
            <p
              className="text-center lead"
              style={{ fontSize: "25px", fontWeight: "600" }}
            >
              {lecture.topic}
            </p>
          </div>
          <div className="row justify-content-center mb-4">
            <div className="col">
              <p className="text-secondary" />
            </div>
            <div className="col">
              <p className="text-secondary">
                Name of lecturer: {lecture.lecturer}
              </p>
            </div>
          </div>
          <label className="text-danger">{this.state.error}</label>
          <div className="row justify-content-center">
            <button className="btn btn-dark mr-2" onClick={this.navigateBack}>
              BACK
            </button>
            {this.state.going ? notGoing : going}
          </div>
        </div>
      </React.Fragment>
    );
  }
}

ViewMeetup.propTypes = {
  meetup: PropTypes.object.isRequired,
  getMeetup: PropTypes.func.isRequired,
  goingOnMeetup: PropTypes.func.isRequired,
  notGoingOnMeetup: PropTypes.func.isRequired,
  error: PropTypes.string.isRequired
};

const mapStateToProps = state => ({
  meetup: state.meetup.meetup,
  error: state.meetup.error,
  success: state.meetup.success
});

export default connect(
  mapStateToProps,
  { getMeetup, goingOnMeetup, notGoingOnMeetup }
)(ViewMeetup);
