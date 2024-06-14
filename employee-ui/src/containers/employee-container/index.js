import { useEffect, useState } from 'react';
import Button from '@mui/material/Button';

import EmployeeTable from '../../components/employee-table';
import EmployeeForm from '../../components/employee-form';

import { getEmployeeList } from '../../services/employee-service';

import './employee-container.css';

function EmployeeContainer() {
  const [employeeList, setEmployeeList] = useState([]);
  const [selectedEmployee, setSelectedEmployee] = useState(null);

  const [isLoading, setIsLoading] = useState(false);

  useEffect(() => {
    searchEmployees();
  }, []);

  const searchEmployees = () => {
    setIsLoading(true);
    const filter = {
      
    };

    getEmployeeList(filter).then(response => {
      setEmployeeList(response);
      setIsLoading(false);
    });
  }

  return (
    <div className="employeeContainer">
      <div className="filterContainer">
        <div className="titleContainer">
          <span><b>Employee List</b></span>
          <Button disabled={isLoading} variant="contained" onClick={() => setSelectedEmployee({})}>Add New Employee</Button>
        </div>
      </div>
      <div className="tableContainer">
        <EmployeeTable employeeList={employeeList} refreshData={searchEmployees} setSelectedEmployee={setSelectedEmployee} isLoading={isLoading} />
      </div>
      {selectedEmployee && <EmployeeForm employeeData={selectedEmployee} handleClose={() => setSelectedEmployee(null)} refreshData={searchEmployees}/>}
    </div>
  );
}

export default EmployeeContainer;
