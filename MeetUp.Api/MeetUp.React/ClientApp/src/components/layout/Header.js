import React, { Component } from "react";
import PropTypes from "prop-types";
import { Link } from "react-router-dom";
import { connect } from "react-redux";
import { logout } from "../../actions/userActions";

class Header extends Component {
  state = {
    logedin: true
  };

  signOut = () => {
    this.props.logout();
    localStorage.removeItem("token");
  };

  render() {
    const { branding } = this.props;

    const logedInUser = (
      <div>
        <ul className="navbar-nav mr-auto">
          <li className="nav-item">
            <Link to="/meetups" className="nav-link">
              <i className="fas fa-home" /> Home
            </Link>
          </li>
          <li className="nav-item">
            <Link to="/meetup/add" className="nav-link">
              <i className="fas fa-plus" /> Add
            </Link>
          </li>
          <li className="nav-item">
            <Link to="/about" className="nav-link">
              <i className="fas fa-question" /> About
            </Link>
          </li>
          <li className="nav-item" style={{ cursor: "pointer" }}>
            <a className="nav-link" onClick={this.signOut}>
              <i className="fas fa-sign-out-alt" /> LogOut
            </a>
          </li>
        </ul>
      </div>
    );

    const notLogedInUser = (
      <div>
        <ul className="navbar-nav mr-auto">
          <li className="nav-item">
            <Link to="/about" className="nav-link">
              <i className="fas fa-question" /> About
            </Link>
          </li>
        </ul>
      </div>
    );

    return (
      <nav className="navbar navbar-expand-sm navbar-dark bg-danger mb-3 py-0">
        <div className="container">
          <p className="navbar-brand" style={{ cursor: "context-menu" }}>
            {branding}
          </p>
          {this.props.isAuth || localStorage.getItem("token")
            ? logedInUser
            : notLogedInUser}
        </div>
      </nav>
    );
  }
}

Header.defaultProps = {
  branding: "Meetup App"
};

Header.propTypes = {
  branding: PropTypes.string.isRequired,
  token: PropTypes.string.isRequired,
  loginError: PropTypes.string.isRequired,
  isAuth: PropTypes.bool.isRequired,
  logout: PropTypes.func.isRequired
};

const mapStateToProps = state => ({
  token: state.user.token,
  loginError: state.user.loginError,
  isAuth: state.user.isAuth
});

export default connect(
  mapStateToProps,
  { logout }
)(Header);
