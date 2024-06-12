import axios from "axios";

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
    const query = convertObjectToQuery(filter);
    const url = `${baseURL}/employee${query}`;
    return axios.get(url).then((response) => response.data);
};

export const createEmployee = (newEmployee) => {
    const url = `${baseURL}/employee`;
    return axios.post(url, { ...newEmployee });
};

export const updateEmployee = (updateEmployee) => {
    const url = `${baseURL}/employee/${updateEmployee.id}`;
    return axios.put(url, { ...updateEmployee });
};

export const deleteEmployee = (id) => {
    const url = `${baseURL}/employee/${id}`;
    return axios.delete(url);
};
