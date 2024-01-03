import {get } from './api.service';

const ENTITY_URL = 'PermissionType/';

const getAll = async () => {
    return await get(ENTITY_URL + 'get-all');
}

const PermissionTypeService = {
    getAll
}

export default PermissionTypeService