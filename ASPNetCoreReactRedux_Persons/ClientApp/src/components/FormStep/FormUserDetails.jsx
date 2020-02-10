import React, { Component } from 'react';
import Dialog from '@material-ui/core/Dialog';
import AppBar from '@material-ui/core/AppBar';
import { MuiThemeProvider as ThemeProvider } from '@material-ui/core/styles';
import {
    RadioGroup, Radio, FormControlLabel, FormControl, TextField, Button,
    FormLabel, Checkbox
} from '@material-ui/core';
import { List, ListItem, ListItemText } from '@material-ui/core/';


export class FormUserDetails extends Component {
    continue = e => {
        e.preventDefault();
        this.props.nextStep();
    };
    cancelItem_onClick = () => {
        window.history.back();
    };

    render() {
        const { values, handleChange, handleChangeCheck } = this.props;

        return (
            <ThemeProvider >
                <React.Fragment>
                    <Dialog
                        open="true"
                        fullWidth="true"
                        maxWidth='sm'
                    >
                        <AppBar title="Dados Pessoa" />
                        <Button
                            color="secondary"
                            variant="contained"
                            onClick={this.cancelItem_onClick}
                        >Cancelar</Button>

                        <FormControlLabel
                            control={
                                <Checkbox
                                    defaultChecked={values.ativado}
                                    checked={values.ativado}
                                    onChange={handleChangeCheck('ativado')}
                                    color="primary"
                                />
                            }
                            label="Ativo"
                        />
                        <TextField
                            placeholder="Primeiro Nome"
                            label="Primeiro Nome"
                            onChange={handleChange('nome')}
                            defaultValue={values.nome}
                            margin="normal"
                            fullWidth="true"
                        />
                        <br />
                        <TextField
                            placeholder="Sobrenome"
                            label="Sobrenome"
                            onChange={handleChange('sobreNome')}
                            defaultValue={values.sobreNome}
                            margin="normal"
                            fullWidth="true"
                        />
                        <br />
                        <TextField
                            placeholder="Pseudonimo"
                            label="Pseudonimo"
                            onChange={handleChange('pseudonimo')}
                            defaultValue={values.pseudonimo}
                            margin="normal"
                            fullWidth="true"
                        />
                        <br />
                        <FormControl component="fieldset" margin="normal" fullWidth="true">
                            <FormLabel component="legend">Sexo</FormLabel>
                            <RadioGroup aria-label="sexo" name="sexo" value={values.sexo} onChange={handleChange('sexo')} row>
                                <FormControlLabel value="Feminino" control={<Radio />} label="Feminino" />
                                <FormControlLabel value="Masculino" control={<Radio />} label="Masculino" />
                            </RadioGroup>
                        </FormControl>
                        <br />
                        <RadioGroup
                            placeholder="Sexo"
                            label="Sexo"
                            onChange={handleChange('sexo')}
                            defaultValue={values.sexo}
                            margin="normal"
                            fullWidth="true"
                        />
                        <br />
                        <TextField
                            placeholder="Digita a data formato 00/00/0000"
                            label="Data Nascimento"
                            onChange={handleChange('dataNascimento')}
                            defaultValue={values.dataNascimento}
                            margin="normal"
                            fullWidth="true"
                        />
                        <br />
                        <TextField
                            placeholder="Celular"
                            label="Celular"
                            onChange={handleChange('celular')}
                            defaultValue={values.celular}
                            margin="normal"
                            fullWidth="true"
                        />
                        <br />
                        <TextField
                            placeholder="Email"
                            label="E-Mail"
                            onChange={handleChange('email')}
                            defaultValue={values.email}
                            margin="normal"
                            fullWidth="true"
                        />
                        <br />
                        <TextField
                            placeholder="CPF"
                            label="CPF"
                            onChange={handleChange('cpf')}
                            defaultValue={values.cpf}
                            margin="normal"
                            fullWidth="true"
                        />
                        <br />
                        <TextField
                            placeholder="RG"
                            label="RG"
                            onChange={handleChange('rg')}
                            defaultValue={values.rg}
                            margin="normal"
                            fullWidth="true"
                        />
                        <br />
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

export default FormUserDetails;
