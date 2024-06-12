export const formatDate = dateValue => {
    const createdOn = new Date(dateValue);
    return [
        ('0' + createdOn.getDate()).slice(-2),
        ('0' + (createdOn.getMonth() + 1)).slice(-2),
        createdOn.getFullYear()
    ].join('-');
};
