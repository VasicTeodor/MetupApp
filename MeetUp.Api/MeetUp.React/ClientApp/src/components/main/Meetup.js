import React, { Component } from "react";
import { Link } from "react-router-dom";
import PropTypes from "prop-types";
import { connect } from "react-redux";
import { deleteMeetup } from "../../actions/meetupActions";

class Meetup extends Component {
  state = {
    showMeetupInfo: false
  };

  onDeleteClick = id => {
    this.props.deleteMeetup(id);
  };

  render() {
    const { id, title, date, address, createdById } = this.props.meetup;
    const { showMeetupInfo } = this.state;
    const { key } = this.props;

    const myMeetup = (
      <React.Fragment>
        <i
          className="fas fa-times"
          style={{ cursor: "pointer", float: "right", color: "red" }}
          onClick={this.onDeleteClick.bind(this, id)}
        />
        <Link to={`meetup/edit/${id}`}>
          <i
            className="fas fa-pencil-alt"
            style={{
              cursor: "pointer",
              float: "right",
              color: "black",
              marginRight: "1rem"
            }}
          />
        </Link>
      </React.Fragment>
    );

    return (
      <div key={key} className="card card-body mb-3">
        <h4>
          {title}
          <i
            onClick={() =>
              this.setState({
                showMeetupInfo: !this.state.showMeetupInfo
              })
            }
            className="fas fa-sort-down"
            style={{ cursor: "pointer" }}
          />
          {JSON.stringify(createdById) === localStorage.getItem("userId") ? (
            myMeetup
          ) : (
            <React.Fragment />
          )}
          <Link to={`meetup/view/${id}`}>
            <i
              className="fas fa-search-plus"
              style={{
                cursor: "pointer",
                float: "right",
                color: "black",
                marginRight: "1rem"
              }}
            />
          </Link>
        </h4>
        {showMeetupInfo ? (
          <ul className="list-group">
            <li className="list-group-item">Date of meetup: {date}</li>
            <li className="list-group-item">
              Location: {address.street + ", " + address.number}
            </li>
          </ul>
        ) : null}
      </div>
    );
  }
}

Meetup.propTypes = {
  meetup: PropTypes.object.isRequired,
  deleteMeetup: PropTypes.func.isRequired,
  isAuth: PropTypes.bool.isRequired
};

const mapStateToProps = state => {
  isAuth: state.user.isAuth;
};

export default connect(
  mapStateToProps,
  { deleteMeetup }
)(Meetup);
