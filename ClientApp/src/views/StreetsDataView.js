import React, { Component } from 'react';
import { DataViewContent } from '../components/DataViewContent';

export class StreetsDataView extends Component {
  static displayName = StreetsDataView.name;
  static columns = [
    "id",
    "streetName"
  ];

  constructor(props) {
    super(props);
    this.state = { dataRows: [], loading: true };
  }

  componentDidMount() {
    this.populateStreetsData();
  }

  render() {
    return <DataViewContent title="Дані про вулиці" 
      description="В даній таблиці можна спостерігати дані про вулиці, що містяться в базі даних" 
      dataRows={this.state.dataRows} columns={StreetsDataView.columns} 
      loading={this.state.loading}/>;
  }

  async populateStreetsData() {
    const response = await fetch('street');
    let data = await response.json();
    this.setState({ dataRows: data, loading: false });
  }
}
