const mockEmploymentTypes = [
    {
        "id": 1,
        "description": "Permanent",
    },
    {
        "id": 2,
        "description": "Freelance",
    },
    {
        "id": 3,
        "description": "Intern",
    }
];

const mockInitialData = [
    {
        "id": 1,
        "firstName": "Sherlock",
        "lastName": "Holmes",
        "email": "holmes@detectives.org",
        "employmentTypeId": 1,
        "employmentType": "Permanent",
        "joinedOn": "2011-06-05T00:00:00",
        "createdOn": "2024-06-12T14:57:44.7249241",
        "modifiedOn": "2024-06-12T14:57:44.724926"
    },
    {
        "id": 2,
        "firstName": "Jane",
        "lastName": "Marple",
        "email": "marple@detectives.org",
        "employmentTypeId": 2,
        "employmentType": "Freelance",
        "joinedOn": "2013-11-14T00:00:00",
        "createdOn": "2024-06-12T14:57:44.7249283",
        "modifiedOn": "2024-06-12T14:57:44.7249284"
    },
    {
        "id": 3,
        "firstName": "Hercule",
        "lastName": "Poirot",
        "email": "poirot@detectives.org",
        "employmentTypeId": 1,
        "employmentType": "Permanent",
        "joinedOn": "2012-08-09T00:00:00",
        "createdOn": "2024-06-12T14:57:44.7249302",
        "modifiedOn": "2024-06-12T14:57:44.7249303"
    },
    {
        "id": 4,
        "firstName": "Nancy",
        "lastName": "Drew",
        "email": "drew@detectives.org",
        "employmentTypeId": 3,
        "employmentType": "Intern",
        "joinedOn": "2024-03-04T00:00:00",
        "createdOn": "2024-06-12T14:57:44.7249316",
        "modifiedOn": "2024-06-12T14:57:44.7249316"
    },
    {
        "id": 5,
        "firstName": "Jessica",
        "lastName": "Fletcher",
        "email": "fletcher@detectives.org",
        "employmentTypeId": 2,
        "employmentType": "Freelance",
        "joinedOn": "2018-05-12T00:00:00",
        "createdOn": "2024-06-12T14:57:44.7249329",
        "modifiedOn": "2024-06-12T14:57:44.724933"
    },
    {
        "id": 6,
        "firstName": "Frank",
        "lastName": "Columbo",
        "email": "columbo@detectives.org",
        "employmentTypeId": 1,
        "employmentType": "Permanent",
        "joinedOn": "2016-09-07T00:00:00",
        "createdOn": "2024-06-12T14:57:44.7249346",
        "modifiedOn": "2024-06-12T14:57:44.7249346"
    }
];

const getSavedEmployeeListMock = () => {
    const employeeListMock = sessionStorage.getItem("employeeListMock");
    if(employeeListMock) {
        return JSON.parse(employeeListMock);
    }

    sessionStorage.setItem("employeeListMock", JSON.stringify(mockInitialData));
    return mockInitialData;
}

export const getEmployeeListMock = () => {
    return Promise.resolve(getSavedEmployeeListMock());
};

export const createEmployeeMock = (newEmployee) => {
    const employeeListMock = getSavedEmployeeListMock();
    const lastId = employeeListMock.reduce((accumulator, current) => current > accumulator ? current : accumulator, 0);
    const newEmployeeListMock = [ ...employeeListMock, {
        ...newEmployee,
        id: lastId + 1,
        employmentType: mockEmploymentTypes.find(x => x.id === newEmployee.employmentTypeId).description
    }];
    sessionStorage.setItem("employeeListMock", JSON.stringify(newEmployeeListMock));

    return Promise.resolve();
};

export const updateEmployeeMock = (updateEmployee) => {
    const employeeListMock = getSavedEmployeeListMock();
    const employeeIndex = employeeListMock.findIndex(x => x.id === updateEmployee.id);
    const newEmployeeListMock = [ ...employeeListMock ]
    newEmployeeListMock[employeeIndex] = {
        ...updateEmployee,
        employmentType: mockEmploymentTypes.find(x => x.id === updateEmployee.employmentTypeId).description
    }
    sessionStorage.setItem("employeeListMock", JSON.stringify(newEmployeeListMock));

    return Promise.resolve();
};

export const deleteEmployeeMock = (id) => {
    const employeeListMock = getSavedEmployeeListMock();
    const newEmployeeListMock = employeeListMock.filter(x => x.id !== id);
    sessionStorage.setItem("employeeListMock", JSON.stringify(newEmployeeListMock));
    return Promise.resolve();
};

export const getEmploymentTypesMock = () => {
    return Promise.resolve(mockEmploymentTypes);
};
