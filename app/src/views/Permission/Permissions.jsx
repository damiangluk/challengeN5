import React, { useEffect, useState } from 'react';
import PermissionTable from '../../components/PermissionTable/PermissionTable';
import { Toolbar, Tooltip, Typography } from '@mui/material';
import AddIcon from '@mui/icons-material/Add';
import Button from '@mui/material/Button';
import PermissionService from '../../services/permission.services';
import { Link } from 'react-router-dom';
import RefreshRoundedIcon from '@mui/icons-material/RefreshRounded';
import './Permission.css'


const Permissions = () => {
  const [permissions, setPermissions] = useState([]);
  const [error, setError] = useState("");
  const [loading, setLoading] = useState(true);

  const getAllPermissions = async () => {
    try {
      setLoading(true);

      const response = await PermissionService.getAll();

      if (response && response.status && response.validation)
        setPermissions(response.content);
      else setError(response?.content?.message || response.message || 'An error ocurred while getting all the permissions')

      setLoading(false);
    } catch (errorCatch) {
      setError('An error ocurred while getting all the permissions');
      setLoading(false);
    }
  };

  useEffect(() => {
    if (!permissions.length) {
      getAllPermissions();
    }
    // eslint-disable-next-line
  }, []);

  return (
    <div>
      <Toolbar
        sx={{
          pl: { sm: 2 },
          pr: { xs: 1, sm: 1 },
          justifyContent: 'space-between',
        }}
      >
        <Typography variant="h4" align="left" gutterBottom>
          Permissions
        </Typography>
        <div>
          <Tooltip title="Search results">
            <Button
              variant="contained"
              style={{ backgroundColor: '#333', color: '#fff', marginRight: '12px' }}
              onClick={() => getAllPermissions()}
            >
              Search
            </Button>
          </Tooltip>
          <Tooltip title="Add permission">
            <Button component={Link} to="/add" variant="contained" endIcon={<AddIcon />}>
              Add
            </Button>
          </Tooltip>
        </div>
      </Toolbar>
      {
        !error
          ? (
            loading
              ? <RefreshRoundedIcon fontSize='large' className='rotate' />
              : <PermissionTable items={permissions} />
          )
          : <div className='permissions-error'>{error}</div>
      }
    </div>
  );
};

export default Permissions;