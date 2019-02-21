import React, { Component } from "react";
import { Helmet } from "react-helmet";
import "./App.css";
import logo from "./logo.svg";

class App extends Component {
  public render() {
    return (
      <div className="App">
        <Helmet>
          <meta charSet="utf-8" />
          <meta
            name="Description"
            content="Funny shit I found on the Internet"
          />
          <title>Garvik</title>
          <link rel="shortcut icon" href={require("./favicon.ico")} />
        </Helmet>
        <header className="App-header">
          <img src={logo} className="App-logo" alt="logo" />
        </header>
      </div>
    );
  }
}

export default App;
