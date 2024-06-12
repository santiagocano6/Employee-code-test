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
  const [searchBy, setSearchBy] = useState('0');
  const [searchValue, setSearchValue] = useState('');
  const [own, setOwn] = useState(false);
  const [love, setLove] = useState(false);
  const [wanted, setWanted] = useState(false);

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

  const onSaveEmployee = (employeeData) => {
    
  }

  return (
    <div className="employeeContainer">
      <div className="filterContainer">
        <div className="titleContainer">
          <span><b>Employee List</b></span>
          <Button variant="contained" onClick={() => setSelectedEmployee({})}>Add New Employee</Button>
        </div>
      </div>
      <div className="tableContainer">
        <EmployeeTable employeeList={employeeList} refreshData={searchEmployees} setSelectedEmployee={setSelectedEmployee}/>
      </div>
      {selectedEmployee && <EmployeeForm employeeData={selectedEmployee} handleClose={() => setSelectedEmployee(null)} saveEmployee={onSaveEmployee}/>}
    </div>
  );
}

export default EmployeeContainer;
