import * as React from 'react';
import { styled } from '@mui/material/styles';
import {
  Table,
  TableBody,
  TableCell,
  tableCellClasses,
  TableContainer,
  TableHead,
  TableRow,
  Paper,
  IconButton,
  Tooltip,
} from '@mui/material';
import EditIcon from '@mui/icons-material/Edit';
import { Link } from 'react-router-dom';
import DateHelper from '../../utilities/dateHelper';

const StyledTableCell = styled(TableCell)(({ theme }) => ({
  [`&.${tableCellClasses.head}`]: {
    backgroundColor: theme.palette.common.black,
    color: theme.palette.common.white,
    fontWeight: 'bold',
  },
  [`&.${tableCellClasses.body}`]: {
    fontSize: 14,
  },
}));

const StyledTableRow = styled(TableRow)(({ theme }) => ({
  '&:nth-of-type(odd)': {
    backgroundColor: theme.palette.action.hover,
  },
  // hide last border
  '&:last-child td, &:last-child th': {
    border: 0,
  },
}));

const PermissionTable = ({ items }) => {
  return (
    items && !items.length ? (
      <div>No se encontraron resultados</div>
    ) : (
      <TableContainer component={Paper}>
        <Table sx={{ minWidth: 700 }} aria-label="customized table">
          <TableHead>
            <TableRow>
              <StyledTableCell width="20%" align='center'>Name</StyledTableCell>
              <StyledTableCell width="20%" align='center'>Surname</StyledTableCell>
              <StyledTableCell width="20%" align='center'>Date</StyledTableCell>
              <StyledTableCell width="20%" align='center'>Permission type</StyledTableCell>
              <StyledTableCell width="20%" align='center'>Actions</StyledTableCell>
            </TableRow>
          </TableHead>
          <TableBody>
            {items.map((row, index) => (
              <StyledTableRow key={index}>
                <StyledTableCell align='center'>{row.name}</StyledTableCell>
                <StyledTableCell align='center'>{row.surname}</StyledTableCell>
                <StyledTableCell align='center'>{DateHelper.convertStringToDate(row.date)}</StyledTableCell>
                <StyledTableCell align='center'>{row.permissionType.text}</StyledTableCell>
                <StyledTableCell align='center'>
                  <Tooltip title="Editar">
                    <IconButton component={Link} to={`/edit/${row.id}`}>
                      <EditIcon />
                    </IconButton>
                  </Tooltip>
                </StyledTableCell>
              </StyledTableRow>
            ))}
          </TableBody>
        </Table>
      </TableContainer>
    )
  )
};

export default PermissionTable;
