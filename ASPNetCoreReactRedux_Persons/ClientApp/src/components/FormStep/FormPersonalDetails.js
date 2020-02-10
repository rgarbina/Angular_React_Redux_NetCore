import React, { Component } from 'react';
import PropTypes from 'prop-types';
import { connect } from 'react-redux';
import Dialog from '@material-ui/core/Dialog';
import AppBar from '@material-ui/core/AppBar';
import { MuiThemeProvider as ThemeProvider } from '@material-ui/core/styles';
import { TextField, MenuItem, Button } from '@material-ui/core';
import { fetchUF, fetchCidade } from '../../actions/componentActions';
import { List, ListItem, ListItemText } from '@material-ui/core/';

export class FormPersonalDetails extends Component {
    continue = e => {
        e.preventDefault();
        this.props.nextStep();
    };

    back = e => {
        e.preventDefault();
        this.props.prevStep();
    };

    cancelItem_onClick = () => {
        window.history.back();
    };

    render() {
        this.props.fetchCidade();

        const { values, handleChangeEndereco, handleChangeCidade } = this.props;

        return (
            <ThemeProvider >
                <React.Fragment>
                    <Dialog
                        open="true"
                        fullWidth="true"
                        maxWidth='sm'
                    >
                        <AppBar title="Dados Endereco Pessoa" />
                        <Button
                            color="secondary"
                            variant="contained"
                            onClick={this.cancelItem_onClick}
                        >Cancelar</Button>
                        <TextField
                            id="Selecione a Cidade"
                            select
                            label="Cidades"
                            value={values.endereco.cidadeId}
                            defaultValue={values.endereco.cidadeId}
                            onChange={handleChangeCidade}
                            helperText="Cidades"
                        >
                            {this.props.allCidades.map(option => (
                                <MenuItem key={option.value} value={option.value} name={option.label}>
                                    {option.label}
                                </MenuItem>
                            ))}
                        </TextField>
                        <br />
                        <TextField
                            placeholder="Logradouro"
                            label="Logradouro"
                            onChange={handleChangeEndereco('logradouro')}
                            defaultValue={values.endereco.logradouro}
                            margin="normal"
                            fullWidth="true"
                        />
                        <br />
                        <TextField
                            placeholder="Numero"
                            label="Numero"
                            onChange={handleChangeEndereco('numero')}
                            defaultValue={values.endereco.numero}
                            margin="normal"
                            fullWidth="true"
                        />
                        <br />
                        <TextField
                            placeholder="Bairro"
                            label="Bairro"
                            onChange={handleChangeEndereco('bairro')}
                            defaultValue={values.endereco.bairro}
                            margin="normal"
                            fullWidth="true"
                        />
                        <br />
                        <TextField
                            placeholder="Complemento"
                            label="Complemento"
                            onChange={handleChangeEndereco('complemento')}
                            defaultValue={values.endereco.complemento}
                            margin="normal"
                            fullWidth="true"
                        />
                        <br />
                        <TextField
                            placeholder="Cep"
                            label="CEP"
                            onChange={handleChangeEndereco('cep')}
                            defaultValue={values.endereco.cep}
                            margin="normal"
                            fullWidth="true"
                        />
                        <br />
                        <Button
                            color="secondary"
                            variant="contained"
                            onClick={this.back}
                        >Retroceder</Button>

                        <Button
                            color="primary"
                            variant="contained"
                            onClick={this.continue}
                        >Prosseguir</Button>
                    </Dialog>
                </React.Fragment>
            </ThemeProvider>
        );
    }
}

FormPersonalDetails.propTypes = {
    fetchUF: PropTypes.array.isRequired,
    fetchCidade: PropTypes.array.isRequired,
};

const mapStateToProps = state => ({
    allEstados: state.components.allEstados,
    allCidades: state.components.allCidades,
})
export default connect(mapStateToProps, { fetchUF, fetchCidade })(FormPersonalDetails);
