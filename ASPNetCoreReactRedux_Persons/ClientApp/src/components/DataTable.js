import React from 'react';
import PropTypes from 'prop-types';

import SnackBar from './SnackBar';

import { connect } from 'react-redux';

import clsx from 'clsx';
import { lighten, makeStyles } from '@material-ui/core/styles';
import Table from '@material-ui/core/Table';
import TableBody from '@material-ui/core/TableBody';
import TableCell from '@material-ui/core/TableCell';
import TableHead from '@material-ui/core/TableHead';
import TablePagination from '@material-ui/core/TablePagination';
import TableRow from '@material-ui/core/TableRow';
import TableSortLabel from '@material-ui/core/TableSortLabel';
import Toolbar from '@material-ui/core/Toolbar';
import Typography from '@material-ui/core/Typography';
import Paper from '@material-ui/core/Paper';
import Checkbox from '@material-ui/core/Checkbox';
import IconButton from '@material-ui/core/IconButton';
import IconAdd from '@material-ui/icons/Add';
import Tooltip from '@material-ui/core/Tooltip';
import DeleteIcon from '@material-ui/icons/Delete';
import FilterListIcon from '@material-ui/icons/FilterList';
import EditIcon from '@material-ui/icons/Edit';
import Moment from 'moment/min/moment-with-locales';
import Button from '@material-ui/core/Button';

import { Link } from 'react-router-dom';
import { removeUsers } from '../actions/userActions';
import { showSnackBar } from '../actions/utilActions';

function desc(a, b, orderBy) {
  if (b[orderBy] < a[orderBy]) {
    return -1;
  }
  if (b[orderBy] > a[orderBy]) {
    return 1;
  }
  return 0;
}

function stableSort(array, cmp) {
  const stabilizedThis = array.map((el, index) => [el, index]);
  stabilizedThis.sort((a, b) => {
    const order = cmp(a[0], b[0]);
    if (order !== 0) return order;
    return a[1] - b[1];
  });
  return stabilizedThis.map(el => el[0]);
}

function getSorting(order, orderBy) {
  return order === 'desc' ? (a, b) => desc(a, b, orderBy) : (a, b) => -desc(a, b, orderBy);
}

const headRows = [
  { id: 'pessoaId', numeric: true, disablePadding: true, label: 'ID' },
  { id: 'nome', numeric: false, disablePadding: false, label: 'Nome Completo' },
  { id: 'pseudonimo', numeric: false, disablePadding: false, label: 'Pseudonimo' },
  { id: 'sexo', numeric: false, disablePadding: false, label: 'Sexo' },
  { id: 'aniversario', numeric: false, disablePadding: false, label: 'Data Aniversario' },
  { id: 'idade', numeric: false, disablePadding: false, label: 'Idade' },
  { id: 'celular', numeric: false, disablePadding: false, label: 'Celular' },
  { id: 'email', numeric: false, disablePadding: false, label: 'Email' },
  { id: 'cpf', numeric: false, disablePadding: false, label: 'Cpf' },
  { id: 'rg', numeric: false, disablePadding: false, label: 'Rg' },
  { id: 'endereco', numeric: false, disablePadding: false, label: 'Endereco' },
  { id: 'cidade', numeric: false, disablePadding: false, label: 'Cidade' },
  { id: 'estado', numeric: false, disablePadding: false, label: 'Estado' },
  { id: 'actions', numeric: false, disablePadding: false, label: 'Actions' },
];

function EnhancedTableHead(props) {
  const { onSelectAllClick, order, orderBy, numSelected, rowCount, onRequestSort } = props;
  const createSortHandler = property => event => {
    onRequestSort(event, property);
  };

  return (
    <TableHead>
      <TableRow>
        <TableCell padding="checkbox">
          <Checkbox
            indeterminate={numSelected > 0 && numSelected < rowCount}
            checked={numSelected === rowCount}
            onChange={onSelectAllClick}
            inputProps={{ 'aria-label': 'select all desserts' }}
          />
        </TableCell>
        {headRows.map(row => (
          <TableCell
            key={row.id}
            align={row.numeric ? 'right' : 'left'}
            padding={row.disablePadding ? 'none' : 'default'}
            sortDirection={orderBy === row.id ? order : false}
          >
            <TableSortLabel
              active={orderBy === row.id}
              direction={order}
              onClick={createSortHandler(row.id)}
            >
              {row.label}
            </TableSortLabel>
          </TableCell>
        ))}
      </TableRow>
    </TableHead>
  );
}

EnhancedTableHead.propTypes = {
  numSelected: PropTypes.number.isRequired,
  onRequestSort: PropTypes.func.isRequired,
  onSelectAllClick: PropTypes.func.isRequired,
  order: PropTypes.oneOf(['asc', 'desc']).isRequired,
  orderBy: PropTypes.string.isRequired,
  rowCount: PropTypes.number.isRequired,
};

const useToolbarStyles = makeStyles(theme => ({
  root: {
    paddingLeft: theme.spacing(2),
    paddingRight: theme.spacing(1),
  },
  highlight:
    theme.palette.type === 'light'
      ? {
          color: theme.palette.secondary.main,
          backgroundColor: lighten(theme.palette.secondary.light, 0.85),
        }
      : {
          color: theme.palette.text.primary,
          backgroundColor: theme.palette.secondary.dark,
        },
  spacer: {
    flex: '1 1 100%',
  },
  actions: {
    color: theme.palette.text.secondary,
  },
  title: {
    flex: '0 0 auto',
  },
}));

const EnhancedTableToolbar = props => {
  const classes = useToolbarStyles();
  const { selected } = props;
  const numSelected = selected.length;

  function handleDelete() {
    props.removeUserCallback(selected);
  }

  return (
    <Toolbar
      className={clsx(classes.root, {
        [classes.highlight]: numSelected > 0,
      })}
      >
          <div>
              <Link to="/add-edit">
                  <Button variant="contained" color="primary"  renderas="button">
                      <span>Adicionar Pessoa</span>
                  </Button>
              </Link>
        </div>

      <div className={classes.title}>
        {numSelected > 0 ? (
          <Typography color="inherit" variant="subtitle1">
            {numSelected} selected
          </Typography>
        ) : (
          <Typography variant="h6" id="tableTitle">
            Detalhe Pessoa
          </Typography>
        )}
      </div>
      <div className={classes.spacer} />
      <div className={classes.actions}>
        {numSelected > 0 ? (
          <Tooltip title="Delete">
            <IconButton onClick={handleDelete} aria-label="delete">
              <DeleteIcon />
            </IconButton>
          </Tooltip>
        ) :""}
      </div>
    </Toolbar>
  );
};

EnhancedTableToolbar.propTypes = {
  selected: PropTypes.array.isRequired
};

// connect(null, { removeUsers })(EnhancedTableToolbar);

const useStyles = makeStyles(theme => ({
  root: {
    width: '90%',
    margin: 'auto',
    marginTop: theme.spacing(3),
  },
  paper: {
    width: '100%',
    marginBottom: theme.spacing(2),
  },
  table: {
    minWidth: 750,
  },
  tableWrapper: {
    overflowX: 'auto',
  },
  icon: {
    fontSize: 20
  }
}));

function ExtendedDataTable(props) {
  const classes = useStyles();
  const [order, setOrder] = React.useState('asc');
  const [orderBy, setOrderBy] = React.useState('calories');
  const [selected, setSelected] = React.useState([]);
  const [page, setPage] = React.useState(0);
  const [rowsPerPage, setRowsPerPage] = React.useState(5);
  const [open, setOpen] = React.useState(false);

  function handleOpen() {
    setOpen(true);
  }

  // ===================
  // Check for props
  if (props.newUsers && props.newUsers.length > 0) {
    // console.log("newUser Props -> ", JSON.stringify(props, null, 2));
    const usersID = props.users.map(user => +user.id);
    let largest = Math.max(...usersID);
    const newUsers = props.newUsers.map((user, index) => {
      return { ...user, id: ++largest}
    })
    props.users.unshift(...newUsers);
    props.newUsers.splice(0);
    handleOpen();
  } else if(props.editUsers && props.editUsers.length > 0) {
    // console.log("editUser Props -> ", JSON.stringify(props, null, 2));
    props.editUsers.forEach(editUser => {
      props.users.splice(props.users.findIndex(user => 
        user.id === editUser.id), 1, editUser);
    })
    props.editUsers.splice(0);
    handleOpen();
  } else if (props.deleteUsers && props.deleteUsers.length > 0) {
     console.log("deleteUser Props -> ", JSON.stringify(props, null, 2));
    props.deleteUsers.forEach(delUser => {
      props.users.splice(props.users.findIndex(user => 
        user.pessoaId === delUser), 1);
    })
    // Empty selected array
    selected.splice(0);
    props.deleteUsers.splice(0);
    handleOpen();
  }
  // ===================

  function handleClose(event, reason) {
    if (reason === "clickaway") {
      return;
    }
    setOpen(false);
  };

  function handleUsersDelete(usersNameArr) {
    props.removeUsers(usersNameArr);
  }

  function handleRequestSort(event, property) {
    const isDesc = orderBy === property && order === 'desc';
    setOrder(isDesc ? 'asc' : 'desc');
    setOrderBy(property);
  }

  function handleSelectAllClick(event) {
    if (event.target.checked) {
      const newSelection = props.users.map(n => n.pessoaId);
      setSelected(newSelection);
      return;
    }
    setSelected([]);
  }

  function handleClick(event, id) {
      const selectedIndex = selected.indexOf(id);
    let newSelected = [];

    if (selectedIndex === -1) {
        newSelected = newSelected.concat(selected, id);
    } else if (selectedIndex === 0) {
      newSelected = newSelected.concat(selected.slice(1));
    } else if (selectedIndex === selected.length - 1) {
      newSelected = newSelected.concat(selected.slice(0, -1));
    } else if (selectedIndex > 0) {
      newSelected = newSelected.concat(
        selected.slice(0, selectedIndex),
        selected.slice(selectedIndex + 1),
      );
    }

    setSelected(newSelected);
  }

  function handleChangePage(event, newPage) {
    setPage(newPage);
  }

  function handleChangeRowsPerPage(event) {
    setRowsPerPage(+event.target.value);
    setPage(0);
  }

    const isSelected = pessoaId => selected.indexOf(pessoaId) !== -1;

  const emptyRows = rowsPerPage - Math.min(rowsPerPage, props.users.length - page * rowsPerPage);

  return (
    <div className={classes.root}>
      <Paper className={classes.paper}>
        <EnhancedTableToolbar selected={selected} removeUserCallback={handleUsersDelete} />
        <div className={classes.tableWrapper}>
          <Table
            className={classes.table}
            aria-labelledby="tableTitle"
            size={'medium'}
          >
            <EnhancedTableHead
              numSelected={selected.length}
              order={order}
              orderBy={orderBy}
              onSelectAllClick={handleSelectAllClick}
              onRequestSort={handleRequestSort}
              rowCount={props.users.length}
            />
            <TableBody>
              {stableSort(props.users, getSorting(order, orderBy))
                .slice(page * rowsPerPage, page * rowsPerPage + rowsPerPage)
                .map((row, index) => {
                    const isItemSelected = isSelected(row.pessoaId);
                  const labelId = `enhanced-table-checkbox-${index}`;

                  return (
                    <TableRow
                      hover
                          onClick={event => handleClick(event, row.pessoaId)}
                      role="checkbox"
                      aria-checked={isItemSelected}
                      tabIndex={-1}
                          key={row.nome}
                      selected={isItemSelected}
                    >
                      <TableCell padding="checkbox">
                        <Checkbox
                          checked={isItemSelected}
                          inputProps={{ 'aria-labelledby': labelId }}
                        />
                      </TableCell>
                      <TableCell component="th" align="right" id={labelId} scope="row" padding="none">
                        {row.pessoaId}
                      </TableCell>
                      <TableCell align="right">{row.nome + " " + row.sobreNome}</TableCell>
                      <TableCell align="right">{row.pseudonimo}</TableCell>
                      <TableCell align="right">{row.sexo}</TableCell>
                      <TableCell align="right">{Moment(row.dataNascimento).lang("pt-br").format('DD MMM YYYY')}</TableCell>
                      <TableCell align="right">{Moment().diff(row.dataNascimento, 'years')}</TableCell>
                      <TableCell align="right">{row.celular}</TableCell>
                      <TableCell align="right">{row.email}</TableCell>
                      <TableCell align="right">{row.cpf}</TableCell>
                      <TableCell align="right">{row.rg}</TableCell>
                      <TableCell align="right">{row.endereco.logradouro + " Numero: " + row.endereco.numero + " Bairro: " + row.endereco.bairro}</TableCell>
                      <TableCell align="right">{row.endereco.cidade}</TableCell>
                      <TableCell align="right">{row.endereco.estado}</TableCell>
                      <TableCell align="center">
                        <Link to={{
                          pathname: '/add-edit',
                          state: {
                            user: row,
                            edit: true
                          }
                        }}>
                          <IconButton>
                              <EditIcon className={classes.icon}/>
                          </IconButton>
                        </Link>
                      </TableCell>
                    </TableRow>
                  );
                })}
              {emptyRows > 0 && (
                <TableRow style={{ height: 49 * emptyRows }}>
                  <TableCell colSpan={6} />
                </TableRow>
              )}
            </TableBody>
          </Table>
        </div>
        <TablePagination
          rowsPerPageOptions={[5, 10, 25]}
          component="div"
          count={props.users.length}
          rowsPerPage={rowsPerPage}
          page={page}
          backIconButtonProps={{
            'aria-label': 'previous page',
          }}
          nextIconButtonProps={{
            'aria-label': 'next page',
          }}
          onChangePage={handleChangePage}
          onChangeRowsPerPage={handleChangeRowsPerPage}
        />
      </Paper>
      <SnackBar
        open={open}
        handleClose={handleClose}
        variant={props.snackBarVariant}
        message={props.snackBarMessage}
      />
    </div>
  );
}

ExtendedDataTable.propTypes = {
    users: PropTypes.array.isRequired,
    newUsers: PropTypes.array,
    editUsers: PropTypes.array,
    deleteUsers: PropTypes.array,
    removeUsers: PropTypes.func,
    showSnackBar: PropTypes.func,
    snackBarMessage: PropTypes.string,
    snackBarVariant: PropTypes.string
}

const mapStateToProps = state => ({
    users: state.users.allUsers,
    newUsers: state.users.newUsers,
    editUsers: state.users.editUsers,
    deleteUsers: state.users.deleteUsers,
    snackBarMessage: state.users.message,
    snackBarVariant: state.users.variant
});

export default connect(mapStateToProps, { removeUsers, showSnackBar })(ExtendedDataTable);