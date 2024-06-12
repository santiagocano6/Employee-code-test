import Modal from '@mui/material/Modal';
import Button from '@mui/material/Button';

import './employee-form.css';
import { useState } from 'react';

const style = {
  
};

function EmployeeForm({employeeData, handleClose, saveEmployee}) {
  const [newData, setNewData] = useState({...employeeData});

  return (
    <Modal
      open
      onClose={handleClose}
      aria-labelledby="modal-modal-title"
      aria-describedby="modal-modal-description"
    >
      <div className="container">
        {newData.firstName}
        <Button variant="contained" onClick={() => saveEmployee()}>Save</Button>
        <Button variant="contained" onClick={() => handleClose()}>Cancel</Button>
      </div>
    </Modal>
  );
}

export default EmployeeForm;
