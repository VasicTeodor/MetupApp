import React, { Component } from "react";
import { Link } from "react-router-dom";
import { connect } from "react-redux";
import PropTypes from "prop-types";
import { login } from "../../actions/userActions";

class Login extends Component {
  state = {
    username: "",
    password: "",
    error: ""
  };

  signIn = () => {
    const { username, password } = this.state;

    if (username === "" || password === "") {
      this.setState({ error: "You must enter username and password!" });
      return;
    } else {
      this.setState({ error: "" });
    }

    this.props.login(username, password);
  };

  onInputChange = e => this.setState({ [e.target.name]: e.target.value });

  render() {
    return (
      <div className="row text-center">
        <div className="col-12 text-center">
          <div className="col-md-3 form-signin mx-auto d-block mt-5">
            <h1 className="h3 mb-3 font-weight-normal">Please sign in</h1>
            <label htmlFor="inputEmail" className="sr-only">
              Username
            </label>
            <input
              id="inputUsername"
              className="form-control mt-3"
              placeholder="Username"
              required={true}
              autoFocus={true}
              value={this.state.username}
              onChange={this.onInputChange}
              name="username"
            />
            <label htmlFor="inputPassword" className="sr-only">
              Password
            </label>
            <input
              type="password"
              id="inputPassword"
              className="form-control mt-3"
              placeholder="Password"
              required={true}
              vaue={this.state.password}
              onChange={this.onInputChange}
              name="password"
            />
            <button
              className="btn btn-lg btn-danger btn-block mt-3"
              onClick={this.signIn}
            >
              Sign in
            </button>
            <label className="text-danger">{this.props.loginError}</label>
            <label className="text-danger">{this.state.error}</label>
            <Link to="/register" className="nav-link">
              <i className="fas fa-plus" /> Register
            </Link>
            <p className="mt-5 mb-3 text-muted">&copy; ItEngine Internship 2018</p>
          </div>
        </div>
      </div>
    );
  }
}

Login.propTypes = {
  login: PropTypes.func.isRequired,
  loginError: PropTypes.string.isRequired,
  isAuth: PropTypes.bool.isRequired
};

const mapStateToProps = state => ({
  loginError: state.user.loginError,
  isAuth: state.user.isAuth
});

export default connect(
  mapStateToProps,
  { login }
)(Login);
