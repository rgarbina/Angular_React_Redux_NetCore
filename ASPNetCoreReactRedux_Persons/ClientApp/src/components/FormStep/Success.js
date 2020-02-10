import React, { Component } from 'react';
import Dialog from '@material-ui/core/Dialog';
import AppBar from '@material-ui/core/AppBar';
import { MuiThemeProvider as ThemeProvider } from '@material-ui/core/styles';
import { ListItem, Button } from '@material-ui/core/';
import { Link } from 'react-router-dom';

export class Success extends Component {
    continue = e => {
        e.preventDefault();
        // PROCESS FORM //
        this.props.nextStep();
    };

    back = e => {
        e.preventDefault();
        this.props.prevStep();
    };

    render() {
        return (
            <ThemeProvider >
                <React.Fragment>
                    <Dialog
                        open="true"
                        fullWidth="true"
                        maxWidth='sm'
                    >
                        <AppBar title="Success" />
                        <h2>Cadastro foi Salvo !</h2>
                        <Link to="/">
                            <Button variant="contained" color="primary" renderAs="button">
                                <span>Clique para voltar pra tela de Detalhe</span>
                            </Button>
                        </Link>
                    </Dialog>
                </React.Fragment>
            </ThemeProvider>
        );
    }
}

export default Success;
