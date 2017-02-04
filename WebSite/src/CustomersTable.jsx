import React from "react";
import { Table, Column, Cell } from "fixed-data-table";
import axios from "axios";
import { config } from "./config.js"

export default class CustomersTable extends React.Component {
  constructor(props) {
    super(props);

    this.state = {
      customersOrders: []
    };
  }

  componentDidMount() {
    this.serverRequest = axios
      .get(config.customersEndpointUrl)
      .then(result => {
        this.setState({ customersOrders: result.data });
      });
  }

  render() {
    return (
      <Table
        rowsCount={this.state.customersOrders.length}
        rowHeight={50}
        headerHeight={50}
        width={400}
        maxHeight={500}
      >
        <Column
          header={<Cell>Customer</Cell>}
          cell={props => (
            <Cell {...props}>
              {this.state.customersOrders[props.rowIndex].name}
            </Cell>
          )}
          width={200}
        />
        <Column
          header={<Cell>Number of orders</Cell>}
          cell={props => (
            <Cell {...props}>
              {this.state.customersOrders[props.rowIndex].numberOfOrders}
            </Cell>
          )}
          width={200}
        />
      </Table>
    );
  }
}
