import React, { Component } from "react";
import PropTypes from "prop-types";
import { connect } from "react-redux";
import { addMeetup } from "../../actions/meetupActions";
import "rc-time-picker/assets/index.css";
import moment from "moment";
import TimePicker from "rc-time-picker";

class AddMeetup extends Component {
  state = {
    lecturer: "",
    topic: "",
    date: "",
    from: "",
    to: "",
    maxVisitors: 0,
    street: "",
    houseNmb: "",
    title: "",
    eror: ""
  };

  createNewMeetup = () => {
    const {
      lecturer,
      title,
      date,
      topic,
      from,
      to,
      maxVisitors,
      street,
      houseNmb
    } = this.state;

    let nameRegex = /[A-Za-z]* {1}[A-Za-z]*/gmy;
    if (!nameRegex.test(lecturer) || lecturer === "") {
      this.setState({ eror: "Please enter valid format of lecturer name." });
      return;
    }

    let titleRegex = /([A-Za-z]* *)*/gmy;
    if (!titleRegex.test(title) || title === "") {
      this.setState({ eror: "Wrong format of meetup title." });
      return;
    }

    if (parseInt(maxVisitors, 10) < 5) {
      this.setState({ eror: "Minimum count of visitors is 5." });
      return;
    }

    let streetRegex = /([A-Za-z]* *){1,5}/gmy;
    if (!streetRegex.test(street) || title === "") {
      this.setState({ eror: "Wrong format of street name." });
      return;
    }

    let houseNumbRegex = /[0-9]*[a-z]{0,2}/gmy;
    if (!houseNumbRegex.test(houseNmb) || houseNmb === "") {
      this.setState({ eror: "Please enter valid house number." });
      return;
    }

    if (date === "") {
      this.setState({ eror: "Please enter valid date." });
      return;
    }

    if (from === "") {
      this.setState({ eror: "Please confirm starting time." });
      return;
    }

    if (to === "") {
      this.setState({ eror: "Please confirm ending time." });
      return;
    }

    this.setState({ eror: "" });

    let newMeetup = {
      lecturer: lecturer,
      title: title,
      topic: topic,
      date: date + "T00:00:00.0000000-00:00",
      from: from,
      to: to,
      maxVisitors: maxVisitors,
      street: street,
      houseNmb: houseNmb,
      creatorId: localStorage.getItem("userId")
    };

    this.props.addMeetup(newMeetup);
  };

  onInputChange = e => {
    this.setState({ [e.target.name]: e.target.value });
  };

  fromTimeChanged = value => {
    const str = "HH:mm";
    this.setState({ from: value && value.format(str) });
  };

  toTimeChanged = value => {
    const str = "HH:mm";
    let time = value && value.format(str);
    this.setState({ to: time });
  };

  render() {
    const {
      lecturer,
      title,
      date,
      topic,
      maxVisitors,
      street,
      houseNmb
    } = this.state;

    return (
      <React.Fragment>
        <section
          className="mbr-section form1 cid-qv5ApHdm7c mbr-parallax-background"
          id="form1-4t"
          data-rv-view="6091"
        >
          <div
            className="mbr-overlay"
            style={{ opacity: "0.7", backgroundColor: "rgb(239, 239, 239)" }}
          />
          <div className="container">
            <div className="row justify-content-center">
              <div className="title col-12 col-lg-8">
                <h2 className="mbr-section-title align-center pb-3 mbr-fonts-style display-3">
                  Create New Meetup
                </h2>
                <h3 className="mbr-section-subtitle align-center mbr-light pb-3 mbr-fonts-style display-6">
                  Easily add location and title for your next big meetup and you
                  are done.
                </h3>
              </div>
            </div>
          </div>

          <div className="container">
            <div className="row justify-content-center">
              <div className="media-container-column col-lg-8">
                <div data-form-alert="" hidden="" className="mb-2">
                  Thanks for using meetup app!
                </div>

                <div className="mbr-form">
                  <input
                    type="hidden"
                    value="zypvuJwT5KMQquXH5P7z1kbVzZYx4spH7EbXqjpRz4uHbzVCqnxURBZWR7Db9BUcscS7AuriG9xE9t+GjwKi3yb6j2qt59zaVksZzC0atXyPG9QjrlZhuwl9+30+9vFx"
                  />
                  <div className="row row-sm-offset">
                    <div className="col-md-4 multi-horizontal">
                      <div className="form-group">
                        <label
                          className="form-control-label mbr-fonts-style display-7"
                          htmlFor="lecturer-form1-4t"
                        >
                          Name of lecturer
                        </label>
                        <input
                          onChange={this.onInputChange}
                          type="text"
                          className="form-control"
                          name="lecturer"
                          value={lecturer}
                          required=""
                          id="lecturer-form1-4t"
                        />
                      </div>
                    </div>
                    <div className="col-md-4 multi-horizontal">
                      <div className="form-group">
                        <label
                          className="form-control-label mbr-fonts-style display-7"
                          htmlFor="title-form1-4t"
                        >
                          Title
                        </label>
                        <input
                          onChange={this.onInputChange}
                          type="text"
                          className="form-control"
                          name="title"
                          value={title}
                          required=""
                          id="title-form1-4t"
                        />
                      </div>
                    </div>
                    <div className="col-md-4 multi-horizontal">
                      <div className="form-group">
                        <label
                          className="form-control-label mbr-fonts-style display-7"
                          htmlFor="maxVisitors-form1-4t"
                        >
                          Max visitors count
                        </label>
                        <input
                          onChange={this.onInputChange}
                          type="text"
                          className="form-control"
                          name="maxVisitors"
                          value={maxVisitors}
                          id="maxVisitors-form1-4t"
                        />
                      </div>
                    </div>
                  </div>
                  <div className="row row-sm-offset">
                    <div className="col-md-4 multi-horizontal">
                      <div className="form-group">
                        <label
                          className="form-control-label mbr-fonts-style display-7"
                          htmlFor="street-form1-4t"
                        >
                          Street
                        </label>
                        <input
                          onChange={this.onInputChange}
                          type="text"
                          className="form-control"
                          name="street"
                          value={street}
                          required=""
                          id="street-form1-4t"
                        />
                      </div>
                    </div>
                    <div className="col-md-4 multi-horizontal">
                      <div className="form-group">
                        <label
                          className="form-control-label mbr-fonts-style display-7"
                          htmlFor="houseNmb-form1-4t"
                        >
                          House number
                        </label>
                        <input
                          onChange={this.onInputChange}
                          type="text"
                          className="form-control"
                          name="houseNmb"
                          value={houseNmb}
                          required=""
                          id="houseNmb-form1-4t"
                        />
                      </div>
                    </div>
                    <div className="col-md-4 multi-horizontal">
                      <div className="form-group">
                        <label
                          className="form-control-label mbr-fonts-style display-7"
                          htmlFor="date-form1-4t"
                        >
                          Date
                        </label>
                        <input
                          onChange={this.onInputChange}
                          type="date"
                          className="form-control"
                          name="date"
                          value={date}
                          id="date-form1-4t"
                        />
                      </div>
                    </div>
                  </div>
                  <div className="row row-sm-offset">
                    <div className="col-md-5 multi-horizontal ml-5">
                      <div className="form-group">
                        <label
                          className="form-control-label mbr-fonts-style display-7"
                          htmlFor="hours-form1-4t"
                        >
                          From
                        </label>
                        <TimePicker
                          showSecond={false}
                          defaultValue={moment()}
                          className="form-control"
                          onChange={this.fromTimeChanged}
                        />
                      </div>
                    </div>
                    <div className="col-md-5 multi-horizontal">
                      <div className="form-group">
                        <label
                          className="form-control-label mbr-fonts-style display-7"
                          htmlFor="minutes-form1-4t"
                        >
                          To
                        </label>
                        <TimePicker
                          showSecond={false}
                          defaultValue={moment()}
                          className="form-control"
                          onChange={this.toTimeChanged}
                        />
                      </div>
                    </div>
                  </div>
                  <div className="form-group">
                    <label
                      className="form-control-label mbr-fonts-style display-7"
                      htmlFor="message-form1-4t"
                    >
                      About the lecture:
                    </label>
                    <textarea
                      onChange={this.onInputChange}
                      type="text"
                      className="form-control"
                      name="topic"
                      value={topic}
                      rows="7"
                      id="message-form1-4t"
                    />
                  </div>
                  <div className="col text-center">
                    <label className="text-danger">{this.state.eror}</label>
                    <label className="text-success">{this.props.success}</label>
                  </div>
                  <span className="input-group-btn">
                    <button
                      onClick={this.createNewMeetup}
                      className="btn btn-primary btn-form display-4"
                    >
                      CREATE MEETUP
                    </button>
                  </span>
                </div>
              </div>
            </div>
          </div>
        </section>
      </React.Fragment>
    );
  }
}

AddMeetup.propTypes = {
  addMeetup: PropTypes.func.isRequired,
  error: PropTypes.string.isRequired
};

const mapStateToProps = state => ({
  error: state.meetup.error,
  success: state.meetup.success
});

export default connect(
  mapStateToProps,
  { addMeetup }
)(AddMeetup);
