import React, { Component } from 'react';
import Dialog from '@material-ui/core/Dialog';
import AppBar from '@material-ui/core/AppBar';
import { MuiThemeProvider as ThemeProvider } from '@material-ui/core/styles';
import { List, ListItem, ListItemText } from '@material-ui/core/';
import Button from '@material-ui/core/Button';
import { Route } from 'react-router-dom';
import { connect } from 'react-redux';
import PropTypes from 'prop-types';
import { addEditUsers } from '../../actions/userActions';
import moment from 'moment';

export class Confirm extends Component {
    continue = e => {
        e.preventDefault();
        //if (this.props.values.pessoaId) {
        //    this.props.addNewUser([{ ...this.props.values, id: this.props.values.pessoaId }])
        //}
        //else {
        //    this.props.addNewUser([this.props.values]);
        //}
        this.props.values.dataNascimento = moment(this.props.values.dataNascimento).toISOString();
        this.props.addNewUser([this.props.values]);
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
        const {
            values: {
                 ativado, nome, sobreNome, pseudonimo, sexo, dataNascimento, celular, email, cpf, rg,
                endereco: { logradouro, numero, bairro, complemento, cidade, cep } }
        } = this.props;
        return (
            <ThemeProvider >
                <React.Fragment>
                    <Dialog
                        open="true"
                        fullWidth="true"
                        maxWidth='sm'
                    >
                        <AppBar title="Confirm User Data" />
                        <Button
                            color="secondary"
                            variant="contained"
                            onClick={this.cancelItem_onClick}
                        >Cancelar</Button>
                        <List>
                            <ListItem>
                                <ListItemText primary="Ativado" secondary={ativado == true ? "Sim" : "Nao"} />
                            </ListItem>
                            <ListItem>
                                <ListItemText primary="Primeiro Nome" secondary={nome} />
                            </ListItem>
                            <ListItem>
                                <ListItemText primary="Sobrenome" secondary={sobreNome} />
                            </ListItem>
                            <ListItem>
                                <ListItemText primary="Pseudonimo" secondary={pseudonimo} />
                            </ListItem>
                            <ListItem>
                                <ListItemText primary="Sexo" secondary={sexo} />
                            </ListItem>
                            <ListItem>
                                <ListItemText primary="Data Nascimento" secondary={dataNascimento} />
                            </ListItem>
                            <ListItem>
                                <ListItemText primary="Celular" secondary={celular} />
                            </ListItem>
                            <ListItem>
                                <ListItemText primary="Email" secondary={email} />
                            </ListItem>
                            <ListItem>
                                <ListItemText primary="Cpf" secondary={cpf} />
                            </ListItem>
                            <ListItem>
                                <ListItemText primary="Rg" secondary={rg} />
                            </ListItem>
                            <ListItem>
                                <ListItemText primary="Logradouro" secondary={logradouro} />
                            </ListItem>
                            <ListItem>
                                <ListItemText primary="Numero" secondary={numero} />
                            </ListItem>
                            <ListItem>
                                <ListItemText primary="Bairro" secondary={bairro} />
                            </ListItem>
                            <ListItem>
                                <ListItemText primary="Complemento" secondary={complemento} />
                            </ListItem>
                            <ListItem>
                                <ListItemText primary="Cidade" secondary={cidade} />
                            </ListItem>
                            <ListItem>
                                <ListItemText primary="CEP" secondary={cep} />
                            </ListItem>
                        </List>
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
                        >Confirmar & Finalizar</Button>
                    </Dialog>
                </React.Fragment>
            </ThemeProvider>
        );
    }
}

Confirm.propTypes = {
    addNewUser: PropTypes.func,
};

export default connect(null, { addNewUser: addEditUsers })(Confirm);