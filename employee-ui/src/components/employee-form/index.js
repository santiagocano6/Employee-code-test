import { useEffect, useState } from 'react';
import Modal from '@mui/material/Modal';
import Button from '@mui/material/Button';
import Select from '@mui/material/Select';
import MenuItem from '@mui/material/MenuItem';
import TextField from '@mui/material/TextField';
import InputLabel from '@mui/material/InputLabel';
import FormControl from '@mui/material/FormControl';
import IconButton from '@mui/material/IconButton';
import CloseIcon from '@mui/icons-material/Close';

import { createEmployee, updateEmployee, getEmploymentTypes } from '../../services/employee-service';

import { formatDateToYYYYMMDD, formatDateToDDMMYYYY } from '../../utils/date-utils';
import { validateEmail } from '../../utils/string';

import './employee-form.css';

function EmployeeForm({employeeData, handleClose, refreshData}) {
  const [newData, setNewData] = useState({...employeeData});
  const [isSaving, setIsSaving] = useState(false);
  const [employmentTypes, setEmploymentTypes] = useState([]);
  const [emailError, setEmailError] = useState(false);

  useEffect(() => {
    getEmploymentTypes().then(result => setEmploymentTypes(result));
  }, []);

  const handleChange = (field, value) => {
    setNewData({...newData, [field]: value})
  };

  const handleEmailChange = (email) => {
    setNewData({...newData, email: email})
    if (validateEmail(email)) {
        setEmailError(false);
    } else {
        setEmailError(true);
    }
  };

  const onClose = () => {
    if(!isSaving) {
      handleClose();
    }
  };

  const saveEmployee = async () => {
    setIsSaving(true);

    let savingProcess = null;
    if(employeeData.id) {
      savingProcess = updateEmployee;
    } else {
      savingProcess = createEmployee;
    }
    
    try {
      await savingProcess(newData);

      refreshData();
      handleClose();
    } catch {
      setIsSaving(false);
    }
  };

  const canSave = newData.firstName && newData.lastName  && newData.email  && newData.employmentTypeId  && newData.joinedOn;

  return (
      <Modal
        open
        onClose={onClose}
        aria-labelledby="modal-modal-title"
        aria-describedby="modal-modal-description"
        disableRestoreFocus
      >
        <div className="formContainer">
          <div className="formHeader">
            <div className="formTitle">
              <span>{employeeData.id ? 'Update Employee' : 'Create Employee'}</span>
              <IconButton aria-label="delete" color="primary" disabled={isSaving} onClick={handleClose}>
                <CloseIcon />
              </IconButton>
            </div>
            <div>
              {employeeData.modifiedOn && <span className="modifiedOn">Modified On: {formatDateToDDMMYYYY(employeeData.modifiedOn)}</span>}
            </div>
          </div>
          <div className="formBody">
            <FormControl variant="standard" sx={{ m: 1, minWidth: 120 }}>
              <TextField
                required
                autoFocus
                id="standard-basic"
                label="First Name"
                variant="standard"
                value={newData.firstName}
                onChange={event => handleChange('firstName', event.target.value)}
              />
            </FormControl>
            <FormControl variant="standard" sx={{ m: 1, minWidth: 120 }}>
              <TextField
                required
                id="standard-basic"
                label="Last Name"
                variant="standard"
                value={newData.lastName}
                onChange={event => handleChange('lastName', event.target.value)}
              />
            </FormControl>
            <FormControl variant="standard" sx={{ m: 1, minWidth: 120 }}>
              <TextField
                required
                id="standard-basic"
                label="Email"
                variant="standard"
                value={newData.email}
                onChange={event => handleEmailChange(event.target.value)}
                error={emailError}
                helperText={emailError && "Email is invalid"}
              />
            </FormControl>
            <FormControl variant="standard" sx={{ m: 1, minWidth: 120 }}>
              <InputLabel required id="demo-simple-select-standard-label">Employment Type</InputLabel>
              <Select
                sx={{ minWidth: 195 }}
                labelId="demo-simple-select-standard-label"
                id="demo-simple-select-standard"
                value={newData.employmentTypeId}
                onChange={event => handleChange('employmentTypeId', event.target.value)}
                label="Age"
              >
                {employmentTypes.map(employmentType => (
                    <MenuItem key={employmentType.id} value={employmentType.id}>{employmentType.description}</MenuItem>
                ))}
              </Select>
            </FormControl>
            <FormControl variant="standard" sx={{ m: 1, minWidth: 120 }}>
              <TextField
                    required
                    sx={{ minWidth: 195 }}
                  id="standard-basic"
                  label="Joined On"
                  variant="standard"
                  type="date"
                  InputLabelProps={{ shrink: true }}
                  value={newData.joinedOn ? formatDateToYYYYMMDD(newData.joinedOn) : ''}
                  onChange={event => handleChange('joinedOn', event.target.value)}
                />
            </FormControl>
          </div>
          <div className="formFooter">
            <Button variant="outlined" disabled={isSaving} onClick={() => handleClose()}>Cancel</Button>
            <Button variant="contained" disabled={isSaving || !canSave} onClick={() => saveEmployee()}>Save</Button>
          </div>
        </div>
      </Modal>
  );
}

export default EmployeeForm;
