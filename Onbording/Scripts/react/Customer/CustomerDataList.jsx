import React, { Component } from 'react';
import ReactDOM from 'react-dom';
import CustomerCreate from './CustomerCreate.jsx';
import CustomerDelete from './CustomerDelete.jsx';
import CustomerUpdate from './CustomerUpdate.jsx';
import { Modal, Button, Message } from 'semantic-ui-react';


export default class CustomerDataList extends Component {
    constructor(props) {
        super(props);
        this.state = {
            CustomerList: [],
            Success: { Data: '' },
            showDeleteModal: false,
            deleteId: 0,
            showCreateModal: false,
            Name: '',
            Address: '',
            showUpdateModal: false,
            updateId: 0,
            Id: 0,

        };


        this.loadData = this.loadData.bind(this);
        this.handleDelete = this.handleDelete.bind(this);
        this.closeDeleteModal = this.closeDeleteModal.bind(this);
        this.handleCreate = this.handleCreate.bind(this);
        this.closeCreateModal = this.closeCreateModal.bind(this);
        this.onDeleteSubmit = this.onDeleteSubmit.bind(this);
        this.onCreateSubmit = this.onCreateSubmit.bind(this);
        this.onChange = this.onChange.bind(this);
        this.handleUpdate = this.handleUpdate.bind(this);
        this.closeUpdateModal = this.closeUpdateModal.bind(this);
        this.onUpdateSubmit = this.onUpdateSubmit.bind(this);
    }


    componentDidMount() {
        this.loadData();
    }

    closeCreateModal() {
        this.setState({ showCreateModal: false });
    }

    closeDeleteModal() {
        this.setState({ showDeleteModal: false });
    }
    closeUpdateModal() {

        this.setState({ showUpdateModal: false });
    }
    onChange(e) {
        this.setState({ [e.target.name]: e.target.value });
    }




    loadData() {
        //ajax call logic


        $.ajax({
            url: "/Customer/GetCustomer",
            type: "Get",
            success: function (data) {
                this.setState({ CustomerList: data })
            }.bind(this)
        });
    }


    onUpdateSubmit(id) {
        //ajax call logic
        let data = { 'Name': this.state.Name, 'Address': this.state.Address, 'Id': this.state.Id };
        console.log('data1', data);
        $.ajax({
            url: "Customer/UpdatedRec",
            type: "post",
            data: data,
            success: function (data) {
                this.setState({ Sucess: data })
                window.location.reload()

            }.bind(this)
        });
    }


    onCreateSubmit() {
        //ajax call logic
        //console.log(this.state.errors)
        
        console.log('Modal create', this.state.Name, this.state.Address);
        let data = { 'Name': this.state.Name, 'Address': this.state.Address }
        console.log(data);
        $.ajax({
            url: "Customer/CreateCustomers",
            type: "post",
            data: data,
            success: function (data) {
                this.setState({ Sucess: data })
                window.location.reload()

            }.bind(this)
        });
    }

    onDeleteSubmit(id) {

        $.ajax({
            url: "Customer/DelCustomers",
            type: "post",
            data: { 'id': id },

            //success: function (data) { this.setState({ Sucess: data }), console.log('c id', id) }.bind(this)
        });

        window.location.reload()
    }

    handleDelete(id) {

        this.setState({ showDeleteModal: true });
        this.setState({ deleteId: id });

    }

    handleCreate() {
        console.log('Create clicked');
        this.setState({ showCreateModal: true });
    }

    handleUpdate(id) {

        this.setState({ showUpdateModal: true });

        this.setState({ updateId: id });
        $.ajax({
            url: "/Customer/GetUpdatedRec",
            type: "GET",
            data: { 'id': id },
            success: function (data) {
                this.setState({ Id: data.Id, Name: data.Name, Address: data.Address }); console.log(data);
            }.bind(this)

        });

        console.log(this.state.updateId)


    }

    render() {


        let tam = this.state.CustomerList;
        let tabletamData = null;
        if (tam != "") {
            tabletamData = tam.map(customer =>
                <tr key={customer.Id}>
                    <td className="four wide">{customer.Name}</td>
                    <td className="four wide">{customer.Address}</td>

                    <td className="four wide">

                        <Button className="ui yellow button" onClick={this.handleUpdate.bind(this, customer.Id)} name={this.state.Name}><i className="edit icon"></i>Edit</Button>
                    </td>
                    <td className="four Wide">
                        <Button className="ui red button" onClick={this.handleDelete.bind(this, customer.Id)}><i className="delete icon"></i>Delete</Button>

                    </td>



                </tr>
            )
        }



        return (
            <React.Fragment>
                
                <div className="ui one column grid">

                    <div className="row"></div>
                    <div className="row"></div>

                    
                    <div className="row">
                        <div className="column"><Button primary onClick={this.handleCreate}>Add New Customer</Button></div>
                        <CustomerCreate onChange={this.onChange} onClose={this.closeCreateModal} showCreateModal={this.state.showCreateModal} onCreateSubmit={this.onCreateSubmit} />
                    </div>
                    <div className="column">
                        <CustomerDelete delete={this.state.deleteId} onClose={this.closeDeleteModal} onDeleteSubmit={this.onDeleteSubmit} showDeleteModal={this.state.showDeleteModal} />

                        <CustomerUpdate update={this.state.UpdateId} onClose={this.closeUpdateModal} showUpdateModal={this.state.showUpdateModal} Name={this.state.Name} Address={this.state.Address} onChange={this.onChange} onUpdateSubmit={this.onUpdateSubmit} />

                        <table className="ui striped table">
                            <thead>
                                <tr>
                                    <th className="four wide">Name</th>
                                    <th className="four wide">Address</th>
                                    <th className="four wide">Action</th>
                                    <th className="four wide">Action</th>

                                </tr>
                            </thead>
                            <tbody>
                                {tabletamData}
                            </tbody>
                        </table>
                    </div>
                </div>
               
            </React.Fragment>
        )
    }

  }