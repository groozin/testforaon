import React, { Component } from "react";
import CustomersTable from "./CustomersTable";
import logo from "./Logo_Aon_Corporation.svg";
import "fixed-data-table/dist/fixed-data-table.css";
import "./App.css";

class App extends Component {
  render() {
    return (
      <div className="App">
        <header className="App-header">
          <section>
            <img src={logo} className="App-logo" alt="logo" />
            <h2>Shop for future life benefits</h2>
          </section>
          <nav>
            Sales opportunities
          </nav>
        </header>
        <section className="App-intro">
          <article>
            <p>
              For potential sale, see the table below. It lists customers who ordered from our site 0 or 1 time.
            </p>
            <CustomersTable />
          </article>
        </section>
      </div>
    );
  }
}

export default App;
