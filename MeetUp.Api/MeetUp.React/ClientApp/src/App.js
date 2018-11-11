import React, { Component } from "react";
import { BrowserRouter as Router, Route, Switch } from "react-router-dom";
import Meetups from "./components/main/Meetups";
import AddMeetup from "./components/main/AddMeetup";
import ViewMeetup from "./components/main/ViewMeetup";
import Header from "./components/layout/Header";
import About from "./components/pages/About";
import NotFound from "./components/pages/NotFound";
import Login from "./components/pages/Login";
import Register from "./components/pages/Register";
import EditMeetup from "./components/main/EditMeetup";

import { PrivateRoute } from "./components/auth/requireAuth";

import { Provider } from "react-redux";
import store, { history } from "./store";

import { ConnectedRouter } from "connected-react-router";

import "bootstrap/dist/css/bootstrap.min.css";
import "./App.css";

class App extends Component {
  render() {
    return (
      <Provider store={store}>
        <ConnectedRouter history={history}>
          <div className="App">
            <Header branding="Meetup App" />
            <div className="container">
              <Switch>
                <Route exact path="/" component={Login} />
                <Route exact path="/register" component={Register} />
                <PrivateRoute exact path="/meetup/add" component={AddMeetup} />
                <PrivateRoute
                  exact
                  path="/meetup/view/:id"
                  component={ViewMeetup}
                />
                <PrivateRoute
                  exact
                  path="/meetup/edit/:id"
                  component={EditMeetup}
                />
                <Route exact path="/add" component={AddMeetup} />
                <PrivateRoute exact path="/meetups" component={Meetups} />
                <Route exact path="/about" component={About} />
                <Route component={NotFound} />
              </Switch>
            </div>
          </div>
        </ConnectedRouter>
      </Provider>
    );
  }
}

export default App;
