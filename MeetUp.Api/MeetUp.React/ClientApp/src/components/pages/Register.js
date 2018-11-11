import React, { Component } from "react";
import { Link } from "react-router-dom";
import { connect } from "react-redux";
import PropTypes from "prop-types";
import { registerUser } from "../../actions/userActions";

class Register extends Component {
  state = {
    name: "",
    surname: "",
    email: "",
    password: "",
    confirmPassword: "",
    username: "",
    error: ""
  };

  registerAccount = () => {
    const { email, password, confirmPassword, username, name, surname } = this.state;

    let newUser = {
      email: email,
      password: password,
      name: name,
      surname: surname,
      username: username
    };

    let nameRegex = /[A-Za-z0-9]+/gmy;

    if (
      !nameRegex.test(username) ||
      username.length < 3 ||
      password.length < 6
    ) {
      this.setState({ error: "Wrong length of username or/and password." });
      return;
    } else {
      this.setState({ error: "" });
    }

    if(password !== confirmPassword){
      this.setState({ error: "Passwords must match!" });
      return;
    }else{
      this.setState({error: ""});
    }

    this.props.registerUser(newUser);
  };

  onInputChange = e => this.setState({ [e.target.name]: e.target.value });

  render() {
    return (
      <div>
        <div className="container mt-5">
          <div className="row main">
            <div className="main-login main-center">
              <form className="form-horizontal" method="post" action="#">
              <div className="form-group">
                  <label htmlFor="name" className="cols-sm-2 control-label">
                    Name
                  </label>
                  <div className="cols-sm-10">
                    <div className="input-group">
                      <span className="input-group-addon">
                        <i className="fa fa-users fa" aria-hidden="true" />
                      </span>
                      <input
                        type="text"
                        className="form-control"
                        id="name"
                        placeholder="Enter your Name"
                        onChange={this.onInputChange}
                        value={this.state.name}
                        name="name"
                      />
                    </div>
                  </div>
                </div>
                
                <div className="form-group">
                  <label htmlFor="surname" className="cols-sm-2 control-label">
                    Surname
                  </label>
                  <div className="cols-sm-10">
                    <div className="input-group">
                      <span className="input-group-addon">
                        <i className="fa fa-users fa" aria-hidden="true" />
                      </span>
                      <input
                        type="text"
                        className="form-control"
                        id="surname"
                        placeholder="Enter your Surname"
                        onChange={this.onInputChange}
                        value={this.state.surname}
                        name="surname"
                      />
                    </div>
                  </div>
                </div>
                
                <div className="form-group">
                  <label htmlFor="email" className="cols-sm-2 control-label">
                    Your Email
                  </label>
                  <div className="cols-sm-10">
                    <div className="input-group">
                      <span className="input-group-addon">
                        <i className="fa fa-envelope fa" aria-hidden="true" />
                      </span>
                      <input
                        type="text"
                        className="form-control"
                        id="email"
                        placeholder="Enter your Email"
                        onChange={this.onInputChange}
                        value={this.state.email}
                        name="email"
                      />
                    </div>
                  </div>
                </div>

                <div className="form-group">
                  <label htmlFor="username" className="cols-sm-2 control-label">
                    Username
                  </label>
                  <div className="cols-sm-10">
                    <div className="input-group">
                      <span className="input-group-addon">
                        <i className="fa fa-users fa" aria-hidden="true" />
                      </span>
                      <input
                        type="text"
                        className="form-control"
                        id="username"
                        placeholder="Enter your Username"
                        onChange={this.onInputChange}
                        value={this.state.username}
                        name="username"
                      />
                    </div>
                  </div>
                </div>

                <div className="form-group">
                  <label htmlFor="password" className="cols-sm-2 control-label">
                    Password
                  </label>
                  <div className="cols-sm-10">
                    <div className="input-group">
                      <span className="input-group-addon">
                        <i className="fa fa-lock fa-lg" aria-hidden="true" />
                      </span>
                      <input
                        type="password"
                        className="form-control"
                        id="password"
                        placeholder="Enter your Password"
                        onChange={this.onInputChange}
                        value={this.state.password}
                        name="password"
                      />
                    </div>
                  </div>
                </div>

                <div className="form-group">
                  <label htmlFor="confirm" className="cols-sm-2 control-label">
                    Confirm Password
                  </label>
                  <div className="cols-sm-10">
                    <div className="input-group">
                      <span className="input-group-addon">
                        <i className="fa fa-lock fa-lg" aria-hidden="true" />
                      </span>
                      <input
                        type="password"
                        className="form-control"
                        id="confirm"
                        placeholder="Confirm your Password"
                        onChange={this.onInputChange}
                        value={this.state.confirmPassword}
                        name="confirmPassword"
                      />
                    </div>
                  </div>
                </div>

                <div className="form-group ">
                  <button
                    type="button"
                    className="btn btn-danger btn-lg btn-block login-button"
                    onClick={this.registerAccount}
                  >
                    Register
                  </button>
                </div>
                <div className="login-register">
                  <Link to="/" className="nav-link">
                    <i className="fas fa-sign-in-alt" /> Login
                  </Link>
                </div>
              </form>
            </div>
          </div>
        </div>
        <label className="text-danger">{this.props.loginError}</label>
      </div>
    );
  }
}

Register.propTypes = {
  registerUser: PropTypes.func.isRequired,
  loginError: PropTypes.string.isRequired
};

const mapStateToProps = state => ({
  loginError: state.user.loginError
});

export default connect(
  mapStateToProps,
  { registerUser }
)(Register);
