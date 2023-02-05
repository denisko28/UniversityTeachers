import React, { Component } from "react";
import { Button, Modal, ModalBody, ModalFooter, ModalHeader } from "reactstrap";

export class DataViewContent extends Component {
  constructor(props) {
    super(props);
    this.state = { dataRows: [], loading: true, modalShow: false, modalData: null };
  }

  componentDidUpdate(prevProps, prevState) {
    if (prevProps.dataRows !== this.props.dataRows) {
      this.setState({ dataRows: this.props.dataRows });
    }

    if (prevProps.loading !== this.props.loading) {
      this.setState({ loading: this.props.loading });
    }
  }

  async rowClickHandler(rowId) {
    if(this.props.onRowClick) {
        let modalData = await this.props.onRowClick(rowId);
        this.setState({ 
            modalShow: true, 
            modalData: modalData 
        });
    }
  }

  toggleModal(show) {
    this.setState({ modalShow: show });
  }

  renderTable(dataRows, columns) {
    return (
      <table className="table table-striped" aria-labelledby="tabelLabel">
        <thead>
          <tr>
            {columns.map((column) => (
              <th key={column}>
                {column.charAt(0).toUpperCase() + column.slice(1)}
              </th>
            ))}
          </tr>
        </thead>
        <tbody>
          {dataRows.map((row) => (
            <tr key={row.id} onClick={() => this.rowClickHandler(row.id)}>
              {columns.map((column) => (
                <td key={column}>{row[column]}</td>
              ))}
            </tr>
          ))}
        </tbody>
      </table>
    );
  }

  render() {
    let contents = this.state.loading ? (
      <p>
        <em>Loading...</em>
      </p>
    ) : (
      this.renderTable(this.state.dataRows, this.props.columns)
    );

    return (
      <div>
        <h1 id="tabelLabel">{this.props.title}</h1>
        <p>{this.props.description}</p>
        <Modal size="lg" centered isOpen={this.state.modalShow}>
          <ModalHeader toggle={() => this.toggleModal(false)}>Детальна інформація</ModalHeader>
          <ModalBody>
            {this.state.modalData}
          </ModalBody>
          <ModalFooter>
            <Button color="secondary" onClick={() => this.toggleModal(false)}>Закрити</Button>
          </ModalFooter>
        </Modal>
        {contents}
      </div>
    );
  }
}
