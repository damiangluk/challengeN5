import React from 'react';
import { TextField, Button, Box, Typography, MenuItem } from '@mui/material';
import { Formik, Form, Field } from 'formik';
import { Link } from 'react-router-dom';
import './PermissionForm.css';
import RefreshRoundedIcon from '@mui/icons-material/RefreshRounded';

const CustomForm = ({ action, submit, validations, permissionTypes, initialValues, error, loading }) => {
  return (
    <Box sx={{ minWidth: '350px', backgroundColor: '#fff', padding: '20px', borderRadius: '8px', display: 'flex', flexDirection: 'column' }}>
      <Typography
        variant="h6"
        sx={{ alignSelf: 'flex-start' }}>
        { action === 'add' ? "Create permission" : "Modify permission" }
      </Typography>
      <Formik
        initialValues={initialValues}
        enableReinitialize
        onSubmit={submit}
        validationSchema={validations}
      >
        {({ handleSubmit, touched, errors }) => (
          <Form onSubmit={handleSubmit}>
            <div className='permission-form-inputs'>
              <Field name="name">
                {({ field }) => (
                  <TextField
                    {...field}
                    label="Name"
                    variant="outlined"
                    margin="normal"
                    sx={{ marginTop: 0, marginBottom: 0 }}
                    fullWidth
                    error={touched.name && Boolean(errors.name)}
                    helperText={touched.name && errors.name}
                  />
                )}
              </Field>
              <Field name="surname">
                {({ field }) => (
                  <TextField
                    {...field}
                    label="Surname"
                    variant="outlined"
                    margin="normal"
                    fullWidth
                    sx={{ marginTop: 0, marginBottom: 0 }}
                    error={touched.surname && Boolean(errors.surname)}
                    helperText={touched.surname && errors.surname}
                  />
                )}
              </Field>
              <Field name="date">
                {({ field }) => (
                  <TextField
                    {...field}
                    label="Date"
                    variant="outlined"
                    margin="normal"
                    fullWidth
                    sx={{ marginTop: 0, marginBottom: 0 }}
                    error={touched.date && Boolean(errors.date)}
                    helperText={touched.date && errors.date}
                  />
                )}
              </Field>
              <Field name="permissionType">
                {({ field }) => (
                  <TextField
                    {...field}
                    select
                    label="Permission type"
                    variant="outlined"
                    margin="normal"
                    fullWidth
                    sx={{
                      '& .MuiInputBase-input': { textAlign: 'left' },
                      marginTop: 0,
                    }}
                    error={touched.permissionType && Boolean(errors.permissionType)}
                    helperText={touched.permissionType && errors.permissionType}
                  >
                    {permissionTypes.map((pt, index) => (
                      <MenuItem key={index} value={pt.id}>{pt.text}</MenuItem>
                    ))}
                  </TextField>
                )}
              </Field>
            </div>
            <div className='permission-error'>{error}</div>
            <div className='buttons-form-permission'>
              {
                loading
                ? <RefreshRoundedIcon fontSize='large' className='rotate' />
                : (
                    <>
                      <Link to="/">
                        <Button variant="contained" style={{ backgroundColor: '#333', color: '#fff', marginRight: '8px' }}>
                          Volver
                        </Button>
                      </Link>
                      <Button type="submit" variant="contained" color="primary">
                        Enviar
                      </Button>
                    </>
                )
              }
            </div>
          </Form>
        )}
      </Formik>
    </Box>
  );
};

export default CustomForm;