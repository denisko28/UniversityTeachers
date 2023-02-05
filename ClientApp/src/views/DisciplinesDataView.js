import React, { Component } from 'react';
import { DataViewContent } from '../components/DataViewContent';

export class DisciplinesDataView extends Component {
  static displayName = DisciplinesDataView.name;
  static columns = [
    "id",
    "name"
  ];

  constructor(props) {
    super(props);
    this.state = { dataRows: [], loading: true };
  }

  componentDidMount() {
    this.populateDisciplinesData();
  }

  render() {
    return <DataViewContent title="Дані про дисципліни" 
      description="В даній таблиці можна спостерігати дані про дисципліни університету" 
      dataRows={this.state.dataRows} columns={DisciplinesDataView.columns} 
      loading={this.state.loading}/>;
  }

  async populateDisciplinesData() {
    const response = await fetch('discipline');
    let data = await response.json();
    this.setState({ dataRows: data, loading: false });
  }
}
