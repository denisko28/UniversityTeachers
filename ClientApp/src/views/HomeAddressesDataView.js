import React, { Component } from 'react';
import { DataViewContent } from '../components/DataViewContent';

export class HomeAddressesDataView extends Component {
  static displayName = HomeAddressesDataView.name;
  static columns = [
    "id",
    "streetId",
    "building",
    "flatNum"
  ];

  constructor(props) {
    super(props);
    this.state = { dataRows: [], loading: true };
  }

  componentDidMount() {
    this.populateHomeAddressesData();
  }

  render() {
    return <DataViewContent title="Дані про місця роботи" 
      description="В даній таблиці можна спостерігати дані про місця роботи в межах університету" 
      dataRows={this.state.dataRows} columns={HomeAddressesDataView.columns} 
      loading={this.state.loading}/>;
  }

  async populateHomeAddressesData() {
    const response = await fetch('homeAddress');
    let data = await response.json();
    this.setState({ dataRows: data, loading: false });
  }
}
