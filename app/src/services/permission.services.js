import {post, get } from './api.service';
import DateHelper from '../utilities/dateHelper';

const ENTITY_URL = 'Permission/';

const formatFormData = (formData) => {
    return {
        Id: formData.id || 0,
        EmployeeName: formData.name,
        EmployeeSurname: formData.surname,
        PermissionDate: DateHelper.formatTo(formData.date),
        PermissionTypeId: formData.permissionType,
    };
}

const getAll = async () => {
    return await get(ENTITY_URL + 'get-all');
}

const create = (formData) => {
    return post(ENTITY_URL + 'request-permission', formatFormData(formData));
}

const update = (formData) => {
    return post(ENTITY_URL+ `modify-permission`, formatFormData(formData));
}

const getOne = async (id) => {
    return await get(ENTITY_URL + `get?id=${id}`);
}

const PermissionService = {
    getAll,
    getOne,
    update,
    create
}

export default PermissionService