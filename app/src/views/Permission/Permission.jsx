import PermissionForm from '../../components/PermissionForm/PermissionForm'
import * as Yup from "yup";
import Validations from '../../utilities/validations'
import { useNavigate, useParams } from 'react-router-dom';
import { useEffect, useState } from 'react';
import PermissionService from '../../services/permission.services'
import PermissionTypeService from '../../services/permissionType.services'
import DateHelper from '../../utilities/dateHelper';

const Permission = ({ action }) => {
  const navigate = useNavigate();
  const { id } = useParams();
  const [permissionTypes, setPermissionTypes] = useState([])
  const [error, setError] = useState('');
  const [loading, setLoading] = useState(false);
  const initialValues = { name: '', surname: '', date: '', permissionType: '', };
  
  const [formValues, setFormValues] = useState(initialValues);

  const getAllPermissionTypes = async () => {
    try {
      if (!permissionTypes.length) {
        const response = await PermissionTypeService.getAll();

        if (response && response.status && response.validation)
          setPermissionTypes(response.content);
        else setError(response?.content?.message || response.message || 'An error ocurred while getting all the permission types')
      }
    } catch (errorCatch) {
      setError('An error ocurred while getting all the permission types');
    }
  };

  const getPermission = async () => {
    try {
      if (!formValues.name) {
        const response = await PermissionService.getOne(id);

        if (response && response.status && response.validation)
        {
          response.content.date = DateHelper.convertStringToDate(response.content.date)
          response.content.permissionType = response.content.permissionType.id
          setFormValues(response.content);
        }
        else setError(response?.content?.message || response.message || 'An error ocurred while getting the permission')
      }
    } catch (errorCatch) {
      setError('An error ocurred while getting the permission');
    }
  };

  useEffect(() => {
    setLoading(true);
    getAllPermissionTypes();
    if (id) {
      getPermission()
    }
    setLoading(false);
    // eslint-disable-next-line
  }, [id, action])

  const editPermission = async (formData, actions) => {
    setLoading(true);
    const response = await PermissionService.update(formData)

    if (response && response.status && response.validation)
      navigate(`/`);
    else setError(response?.content?.message || response.message || 'An error ocurred while updating the permission')

    actions.resetForm()
    setLoading(false);
  };

  const addPermission = async (formData, actions) => {
    setLoading(true);
    const response = await PermissionService.create(formData)

    if (response && response.status && response.validation)
      navigate(`/`);
    else setError(response?.content?.message || response.message || 'An error ocurred while getting all the permissions')

    actions.resetForm()
    setLoading(false);
  };

  const submit = action === 'add' ? addPermission : editPermission;
  const validations = Yup.object().shape({
    name: Validations.textRequired,
    surname: Validations.textRequired,
    date: Validations.dateRequired,
    permissionType: Validations.textRequired,
  });

  return (
    <PermissionForm
      action={action}
      submit={submit}
      validations={validations}
      permissionTypes={permissionTypes}
      initialValues={formValues}
      error={error}
      loading={loading}
    />
  );
};

export default Permission;