import React, { Component } from 'react';
import { DataViewContent } from '../components/DataViewContent';

export class TeachersDataView extends Component {
  static displayName = TeachersDataView.name;
  static columns = [
    "id",
    "name",
    "surname",
    "patronymic",
    "phoneNum",
    "homeAddressId",
    "workPlaceId",
    "positionId"
  ];

  static personalInfoRows = [
    { prop: "id", localizedName: "Id"},
    { prop: "name", localizedName: "Імя"},
    { prop: "surname", localizedName: "Прізвмще"},
    { prop: "patronymic", localizedName: "По батькові"},
    { prop: "phoneNum", localizedName: "Номер телефону"},
    { prop: "homeFullAddress", localizedName: "Домашня адреса"},
    { prop: "workPlaceName", localizedName: "Місце роботи"},
    { prop: "positionName", localizedName: "Посада"},
    { prop: "characteristic", localizedName: "Характеристика"}
  ]

  static coursesRows = [
    { prop: "disciplineName", localizedName: "Назва дисципліни"},
    { prop: "numOfHours", localizedName: "Кількість годин"}
  ]

  constructor(props) {
    super(props);
    this.state = { dataRows: [], loading: true };
  }

  componentDidMount() {
    this.populateTeachersData();
  }

  render() {
    return <DataViewContent title="Дані про викладачів" 
      description="В даній таблиці можна спостерігати дані про всіх викладачів університету" 
      dataRows={this.state.dataRows} columns={TeachersDataView.columns} loading={this.state.loading} 
      onRowClick={(id) => this.getTeacherModalData(id)}/>;
  }

  async getTeacherModalData(id) {
    const personalInfoResponse = await fetch('teacher/full/' + id);
    const personalInfoData = await personalInfoResponse.json();
    const coursesResponse = await fetch('teacher/disciplines/' + id);
    const coursesData = await coursesResponse.json();
    let modalContent = (
      <div>
        <h5>Персональна інформація:</h5>
        <table className="table table-striped" style={{whiteSpace: "pre-line"}} aria-labelledby="tabelLabel">
          <thead>
          </thead>
          <tbody>
            {TeachersDataView.personalInfoRows.map((row, index) => {
              var value = String(personalInfoData[row.prop]).replace("\\n", "\n\n");
              return <tr key={index}>
                <td style={{color: "#6c6c6c"}}>{row.localizedName + ": "}</td>
                <td>{value}</td>
              </tr>
            })}
          </tbody>
        </table>
        <h5>Курси викладача:</h5>
        <table className="table table-striped" style={{whiteSpace: "pre-line"}} aria-labelledby="tabelLabel">
          <thead>
            <tr>
              {TeachersDataView.coursesRows.map((row, index) => 
                <th key={index}>{row.localizedName}</th>
              )}
            </tr>
          </thead>
          <tbody>
            {coursesData.map(course => 
              <tr key={course.disciplineName}>
                {TeachersDataView.coursesRows.map((row, index) => <td key={index}>{course[row.prop]}</td>)}
              </tr>
            )}
          </tbody>
        </table>
      </div>
    );
    
    return modalContent;
  }

  async populateTeachersData() {
    const response = await fetch('teacher');
    let data = await response.json();
    data = data.map((element) => {
      element.phoneNum = "+" + element.phoneNum;
      return element;
    });
    this.setState({ dataRows: data, loading: false });
  }
}
