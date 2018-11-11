import React, { Component } from "react";
import Meetup from "./Meetup";
import { connect } from "react-redux";
import PropTypes from "prop-types";
import { getMeetups } from "../../actions/meetupActions";

class Meetups extends Component {
  state = {
    error: "",
    success: ""
  };

  componentDidMount() {
    this.props.getMeetups();
  }

  render() {
    const { meetups } = this.props;
    return (
      <React.Fragment>
        <div className="row-mdb-10 text-center">
          <label className="text-danger">{this.props.error}</label>
          <label className="text-success">{this.props.success}</label>
        </div>
        <h1 className="display-4 mb-2">
          <span className="text-danger">Meetup</span> List
        </h1>
        {meetups.map(meetup => (
          <Meetup key={meetup.id} meetup={meetup} />
        ))}
      </React.Fragment>
    );
  }
}

Meetups.propTypes = {
  meetups: PropTypes.array.isRequired,
  getMeetups: PropTypes.func.isRequired
};

const mapStateToProps = state => ({
  meetups: state.meetup.meetups,
  error: state.meetup.error,
  success: state.meetup.success
});

export default connect(
  mapStateToProps,
  { getMeetups }
)(Meetups);
