import React, { Component } from 'react';

import { Formik, Field} from 'formik';
import * as Yup from 'yup';

import { Route } from 'react-router-dom';
import { connect } from 'react-redux';
import PropTypes from 'prop-types';
import { addEditUsers } from '../actions/userActions';
import { fetchUF } from '../actions/componentActions';
import { TextField, Button, Select, RadioGroup } from '@material-ui/core';

import SnackBar from './SnackBar';


class AddEditUser extends Component {
    constructor(props) {
        super(props);
        this.props.fetchUF();
        this.state = {
            user: {
                id: this.props.location.state && this.props.location.state.user ? this.props.location.state.user.id : null,
                name: this.props.location.state && this.props.location.state.user ? this.props.location.state.user.name : '',
                email: this.props.location.state && this.props.location.state.user ? this.props.location.state.user.email : '',
                phone: this.props.location.state && this.props.location.state.user ? this.props.location.state.user.phone : '',
                website: this.props.location.state && this.props.location.state.user ? this.props.location.state.user.website : '',
                endereco: this.props.location.state && this.props.location.state.user ? this.props.location.state.user.endereco :
                    {
                        cidadeId:0
                    },
                component:
                {
                    uf: [
                        { value: 'foo', label: 'Foo' },
                        { value: 'bar', label: 'Bar' },

                        { label: "Acre", value: "AC" },

                        { label: "Alagoas", value: "AL" },

                        { label: "Amazonas", value: "AM" },

                        { label: "Amapá", value: "AP" },

                        { label: "Bahia", value: "BA" },

                        { label: "Ceará", value: "CE" },

                        { label: "Distrito Federal", value: "DF" },

                        { label: "Espírito Santo", value: "ES" },

                        { label: "Goiás", value: "GO" },

                        { label: "Maranhão", value: "MA" }]
                },
                edit: this.props.location.state && this.props.location.state.user ? this.props.location.state.edit : false
            },

            open: false
        };
        this.handleClose = this.handleClose.bind(this);
        this.handleOpen = this.handleOpen.bind(this);
    }

    handleOpen() {
        this.setState({ open: true });
    }

    handleClose(event, reason) {
        if (reason === "clickaway") {
            return;
        }
        this.setState({ open: false });
    }

    render() {
        return (
            <Route render={({ history }) => (
                <div>
                    <Formik
                        initialValues={this.state.user}
                        onSubmit={(values, actions) => {
                            setTimeout(() => {
                                // actions.handleReset();
                                history.push('/');
                                this.state.user.id ? this.props.addNewUser([{ ...values, id: this.state.user.id }]) : this.props.addNewUser([values])
                            }, 100);
                        }}
                        validationSchema={Yup.object().shape({
                            name: Yup.string().required('Name field is required'),
                            email: Yup.string()
                                .email('Email not valid')
                                .required('Email field is required'),
                            phone: Yup.string()
                                .required('Phone field is required')
                                .max(10)
                                .min(10),
                            website: Yup.string().notRequired()
                        })}
                    >
                        {props => {
                            const {
                                values,
                                touched,
                                errors,
                                dirty,
                                isSubmitting,
                                handleChange,
                                handleBlur,
                                handleSubmit
                            } = props;
                            return (
                                <form
                                    onSubmit={handleSubmit}
                                    style={{ width: '30%', margin: 'auto' }}
                                >
                                    <TextField
                                        id="standard-name"
                                        type="text"
                                        name="name"
                                        label="Name" // Label acts like placeholder
                                        onChange={handleChange}
                                        onBlur={handleBlur}
                                        value={values.name}
                                        fullWidth
                                        margin="normal"
                                        variant="outlined"
                                        required
                                    />
                                    {errors.name && touched.name && (
                                        <div
                                            style={{ textAlign: 'start', marginTop: '2px', color: 'red' }}
                                        >
                                            {errors.name}
                                        </div>
                                    )}

                                    <TextField
                                        id="standard-email"
                                        type="email"
                                        name="email"
                                        label="Email" // Label acts like placeholder
                                        onChange={handleChange}
                                        onBlur={handleBlur}
                                        value={values.email}
                                        fullWidth
                                        margin="normal"
                                        variant="outlined"
                                        required
                                    />
                                    {errors.email && touched.email && (
                                        <div
                                            style={{ textAlign: 'start', marginTop: '2px', color: 'red' }}
                                        >
                                            {errors.email}
                                        </div>
                                    )}

                                    <TextField
                                        id="standard-phone"
                                        type="text"
                                        name="phone"
                                        label="Phone Number" // Label acts like placeholder
                                        onChange={handleChange}
                                        onBlur={handleBlur}
                                        value={values.phone}
                                        fullWidth
                                        margin="normal"
                                        variant="outlined"
                                        required
                                    />
                                    {errors.phone && touched.phone && (
                                        <div
                                            style={{ textAlign: 'start', marginTop: '2px', color: 'red' }}
                                        >
                                            {errors.phone}
                                        </div>
                                    )}

                                    <TextField
                                        id="standard-website"
                                        type="text"
                                        name="website"
                                        label="Website" // Label acts like placeholder
                                        onChange={handleChange}
                                        onBlur={handleBlur}
                                        value={values.website}
                                        fullWidth
                                        margin="normal"
                                        variant="outlined"
                                    />
                                    {errors.website && touched.website && (
                                        <div
                                            style={{ textAlign: 'start', marginTop: '2px', color: 'red' }}
                                        >
                                            {errors.website}render
                                        </div>
                                    )}
                                    {errors.cidade && touched.cidade && (
                                        <div
                                            style={{ textAlign: 'start', marginTop: '2px', color: 'red' }}
                                        >
                                            {errors.cidade}
                                        </div>
                                    )}

                                    <TextField
                                        id="standard-website"
                                        type="text"
                                        name="website"
                                        label="Website" // Label acts like placeholder
                                        onChange={handleChange}
                                        onBlur={handleBlur}
                                        value={values.website}
                                        fullWidth
                                        margin="normal"
                                        variant="outlined"
                                    />
                                    {errors.website && touched.website && (
                                        <div
                                            style={{ textAlign: 'start', marginTop: '2px', color: 'red' }}
                                        >
                                            {errors.website}
                                        </div>
                                    )}

                                    <Button
                                        disabled={!dirty && !isSubmitting}
                                        type="submit"
                                        variant="contained"
                                        color="primary"
                                        style={{ margin: '1em', float: 'right' }}
                                    >
                                        {this.state.user.edit ? 'Update User' : 'Add User'}
                                    </Button>
                                </form>
                            );
                        }}
                    </Formik>
                    <SnackBar
                        open={this.state.open}
                        handleClose={this.handleClose}
                        variant="success"
                        message="User Created Successfully"
                    />
                </div>
            )} />
        );
    }
}

AddEditUser.propTypes = {
    addNewUser: PropTypes.func,
    fetchUF: PropTypes.array.isRequired,
    snackBarMessage: PropTypes.string,
    snackBarVariant: PropTypes.string
};

const mapStateToProps = state => ({
    allEstados: state.components.allEstados,
    snackBarMessage: state.utils.message,
    snackBarVariant: state.utils.variant
})

export default connect(mapStateToProps, { addNewUser: addEditUsers, fetchUF })(AddEditUser);
