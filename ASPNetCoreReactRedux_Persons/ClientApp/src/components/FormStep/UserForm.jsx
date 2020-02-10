import React, { Component } from 'react';
import FormUserDetails from './FormUserDetails';
import FormPersonalDetails from './FormPersonalDetails';
import Confirm from './Confirm';
import Success from './Success';

export class UserForm extends Component {
    constructor(props) {
        super(props);
        this.state = {
            step: 1,
            pessoaId: this.props.location.state && this.props.location.state.user ? this.props.location.state.user.pessoaId : 0,
            ativado: this.props.location.state && this.props.location.state.user ? this.props.location.state.user.ativado : true,
            nome: this.props.location.state && this.props.location.state.user ? this.props.location.state.user.nome : '',
            sobreNome: this.props.location.state && this.props.location.state.user ? this.props.location.state.user.sobreNome : '',
            pseudonimo: this.props.location.state && this.props.location.state.user ? this.props.location.state.user.pseudonimo : '',
            sexo: this.props.location.state && this.props.location.state.user ? this.props.location.state.user.sexo : '',
            dataNascimento: this.props.location.state && this.props.location.state.user ? this.props.location.state.user.dataNascimento : '',
            celular: this.props.location.state && this.props.location.state.user ? this.props.location.state.user.celular : '',
            email: this.props.location.state && this.props.location.state.user ? this.props.location.state.user.email : '',
            cpf: this.props.location.state && this.props.location.state.user ? this.props.location.state.user.cpf : '',
            rg: this.props.location.state && this.props.location.state.user ? this.props.location.state.user.rg : '',
            endereco: {
                estadoId: this.props.location.state && this.props.location.state.user ? this.props.location.state.user.endereco.estadoId : "",
                cidadeId: this.props.location.state && this.props.location.state.user ? this.props.location.state.user.endereco.cidadeId : 0,
                logradouro: this.props.location.state && this.props.location.state.user ? this.props.location.state.user.endereco.logradouro : "",
                numero: this.props.location.state && this.props.location.state.user ? this.props.location.state.user.endereco.numero : "",
                bairro: this.props.location.state && this.props.location.state.user ? this.props.location.state.user.endereco.bairro : "",
                complemento: this.props.location.state && this.props.location.state.user ? this.props.location.state.user.endereco.complemento : "",
                cidade: this.props.location.state && this.props.location.state.user ? this.props.location.state.user.endereco.cidade : "",
                cep: this.props.location.state && this.props.location.state.user ? this.props.location.state.user.endereco.cep : "",
                estado: this.props.location.state && this.props.location.state.user ? this.props.location.state.user.endereco.estado : "",
            }
        };

        this.handleChange = this.handleChange.bind(this);
        //this.handleSubmit = this.handleSubmit.bind(this);
    }
    // Proceed to next step
    nextStep = () => {
        const { step } = this.state;
        this.setState({
            step: step + 1
        });
    };

    // Go back to prev step
    prevStep = () => {
        const { step } = this.state;
        this.setState({
            step: step - 1
        });
    };

    // Handle fields change
    handleChange = input => e => {
        this.setState({ [input]: e.target.value });
    };

    handleChangeEndereco = input => e => {
        e.persist();
        this.setState(prevState => ({
            endereco: {
                ...prevState.endereco,
                [input]: e.target.value
            }
        }));
    };

    handleChangeCidade = e => {
        e.persist();
        let label = e.nativeEvent.target.textContent;

        this.setState(prevState => ({
            endereco: {
                ...prevState.endereco,
                cidade: label,
                cidadeId: parseInt(e.target.value, 10)
            }
        }));
    };

    handleChangeCheck = input => event => {
        this.setState({ [input]: event.target.checked });
    };

    render() {
        const { step } = this.state;
        const { pessoaId, ativado, nome, sobreNome, pseudonimo, sexo, dataNascimento, celular, email, cpf, rg,
            endereco: { estadoId, cidadeId, logradouro, numero, bairro, complemento, cidade, cep, estado } } = this.state;
        const values = {
            pessoaId, ativado, nome, sobreNome, pseudonimo, sexo, dataNascimento, celular, email, cpf, rg,
            endereco: { estadoId, cidadeId, logradouro, numero, bairro, complemento, cidade, cep, estado }
        };

        switch (step) {
            case 1:
                return (
                    <FormUserDetails
                        nextStep={this.nextStep}
                        handleChange={this.handleChange}
                        handleChangeCheck={this.handleChangeCheck}
                        values={values}
                    />
                );
            case 2:
                return (
                    <FormPersonalDetails
                        nextStep={this.nextStep}
                        prevStep={this.prevStep}
                        handleChangeEndereco={this.handleChangeEndereco}
                        handleChangeCidade={this.handleChangeCidade}
                        values={values}
                    />
                );
            case 3:
                return (
                    <Confirm
                        nextStep={this.nextStep}
                        prevStep={this.prevStep}
                        values={values}
                    />
                );
            case 4:
                return <Success state={this.state} />;
        }
    }
}

export default UserForm;
