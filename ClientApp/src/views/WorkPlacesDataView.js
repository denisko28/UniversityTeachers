import React, { Component } from 'react';
import { DataViewContent } from '../components/DataViewContent';

export class WorkPlacesDataView extends Component {
  static displayName = WorkPlacesDataView.name;
  static columns = [
    "id",
    "placeName",
    "address"
  ];

  constructor(props) {
    super(props);
    this.state = { dataRows: [], loading: true };
  }

  componentDidMount() {
    this.populateWorkPlacesData();
  }

  render() {
    return <DataViewContent title="Дані про місця роботи" 
      description="В даній таблиці можна спостерігати дані про місця роботи в межах університету" 
      dataRows={this.state.dataRows} columns={WorkPlacesDataView.columns} 
      loading={this.state.loading}/>;
  }

  async populateWorkPlacesData() {
    const response = await fetch('workPlace');
    let data = await response.json();
    this.setState({ dataRows: data, loading: false });
  }
}
