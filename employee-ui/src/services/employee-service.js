import axios from "axios";

import {
    getEmployeeListMock,
    createEmployeeMock,
    updateEmployeeMock,
    deleteEmployeeMock,
    getEmploymentTypesMock
} from './employee-service-mock';

const mockServices = true;
const baseURL = 'http://localhost:5163'

const convertObjectToQuery =(obj) => {
    let values = [];
    for (let prop in obj) {
        if(obj[prop]) {
            values.push(`${prop}='${obj[prop]}'`);
        }
    }
    return encodeURI("?" + values.join("&"));
  }

export const getEmployeeList = (filter) => {
    if(mockServices) {
        return getEmployeeListMock();
    }

    const query = convertObjectToQuery(filter);
    const url = `${baseURL}/employee${query}`;
    return axios.get(url).then((response) => response.data);
};

export const createEmployee = (newEmployee) => {
    if(mockServices) {
        return createEmployeeMock(newEmployee);
    }

    const url = `${baseURL}/employee`;
    return axios.post(url, { ...newEmployee });
};

export const updateEmployee = (updateEmployee) => {
    if(mockServices) {
        return updateEmployeeMock(updateEmployee);
    }

    const url = `${baseURL}/employee/${updateEmployee.id}`;
    return axios.put(url, { ...updateEmployee });
};

export const deleteEmployee = (id) => {
    if(mockServices) {
        return deleteEmployeeMock(id);
    }

    const url = `${baseURL}/employee/${id}`;
    return axios.delete(url);
};

export const getEmploymentTypes = () => {
    if(mockServices) {
        return getEmploymentTypesMock();
    }

    const url = `${baseURL}/employmenttype`;
    return axios.get(url).then((response) => response.data);
};
