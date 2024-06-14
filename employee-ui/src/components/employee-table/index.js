import Table from '@mui/material/Table';
import TableBody from '@mui/material/TableBody';
import TableCell from '@mui/material/TableCell';
import TableContainer from '@mui/material/TableContainer';
import TableHead from '@mui/material/TableHead';
import TableRow from '@mui/material/TableRow';
import Paper from '@mui/material/Paper';
import DeleteOutlinedIcon from '@mui/icons-material/DeleteOutlined';
import EditOutlinedIcon from '@mui/icons-material/EditOutlined';

import Loader from '../loader';
import { deleteEmployee } from '../../services/employee-service';

import { formatDateToDDMMYYYY } from '../../utils/date-utils';

import './employee-table.css';

function EmployeeTable({ employeeList, refreshData, setSelectedEmployee, isLoading }) {
  const onDeleteEmployee = (id) => {
    deleteEmployee(id).then(() => refreshData());
  };

  return (
    <TableContainer component={Paper} className="tableContainer" >
      <Table className="table">
        <TableHead>
          <TableRow>
            <TableCell>First Name</TableCell>
            <TableCell>Last Name</TableCell>
            <TableCell>E-mail</TableCell>
            <TableCell>Employment type</TableCell>
            <TableCell>Joined</TableCell>
            <TableCell></TableCell>
          </TableRow>
        </TableHead>
        <TableBody>
          {!isLoading && employeeList.map(employee => (
              <TableRow key={employee.id}>
                <TableCell>{employee.firstName}</TableCell>
                <TableCell>{employee.lastName}</TableCell>
                <TableCell><a href={`mailto:${employee.email}`}>{employee.email}</a></TableCell>
                <TableCell>{employee.employmentType}</TableCell>
                <TableCell>{formatDateToDDMMYYYY(employee.joinedOn)}</TableCell>
                <TableCell>
                  <EditOutlinedIcon className="clickableIcon" onClick={() => setSelectedEmployee(employee)} />
                  <DeleteOutlinedIcon className="clickableIcon" onClick={() => onDeleteEmployee(employee.id)} />
                </TableCell>
              </TableRow>
            ))
          }
        </TableBody>
      </Table>
      {isLoading && <Loader />}
    </TableContainer>
  );
}

export default EmployeeTable;