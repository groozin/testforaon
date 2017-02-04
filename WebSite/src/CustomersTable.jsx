import React from 'react'
import {Table, Column, Cell} from 'fixed-data-table';

export default class CustomersTable extends React.Component {
  constructor(props) {
    super(props);

    this.state = {
      myTableData: [
        {name: 'Rylan', orders: 0},
        {name: 'Amelia', orders: 0},
        {name: 'Estevan', orders: 1},
        {name: 'Florence', orders: 0},
        {name: 'Tressa', orders: 1},
      ],
    };
  }

  render() {
    return (
      <Table
        rowsCount={this.state.myTableData.length}
        rowHeight={50}
        headerHeight={50}
        width={400}
        maxHeight={500}>
        <Column
          header={<Cell>Customer</Cell>}
          cell={props => (
            <Cell {...props}>
              {this.state.myTableData[props.rowIndex].name}
            </Cell>
          )}
          width={200}
        />
        <Column
          header={<Cell>Number of orders</Cell>}
          cell={props => (
            <Cell {...props}>
              {this.state.myTableData[props.rowIndex].orders}
            </Cell>
          )}
          width={200}
        />
      </Table>
    );
  }
}