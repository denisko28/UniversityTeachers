import React, { Component } from 'react';
import { DataViewContent } from '../components/DataViewContent';

export class PositionsDataView extends Component {
  static displayName = PositionsDataView.name;
  static columns = [
    "id",
    "name",
    "salaryPerHour"
  ];

  constructor(props) {
    super(props);
    this.state = { dataRows: [], loading: true };
  }

  componentDidMount() {
    this.populatePositionsData();
  }

  render() {
    return <DataViewContent title="Дані про посади" 
      description="В даній таблиці можна спостерігати дані про посади в межах університету" 
      dataRows={this.state.dataRows} columns={PositionsDataView.columns} 
      loading={this.state.loading}/>;
  }

  async populatePositionsData() {
    const response = await fetch('position');
    let data = await response.json();
    this.setState({ dataRows: data, loading: false });
  }
}
