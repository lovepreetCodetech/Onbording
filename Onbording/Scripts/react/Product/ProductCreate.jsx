import React, { Component } from 'react';
import ReactDOM from 'react-dom';
import { Modal, Button, Form } from 'semantic-ui-react';

export default class ProductCreate extends Component {

    constructor(props) {
        super(props);
        this.state = {


        };
    }

    render() {
        return (
            <React.Fragment>

                <Modal open={this.props.showCreateModal} onClose={this.props.onClose} size="tiny">
                    <Modal.Header>Create Product</Modal.Header>
                    <Modal.Content>
                        <Form size="small">
                            <Form.Group>
                                <Form.Input label='NAME' width={16} onChange={this.props.onChange} name="Name" />

                            </Form.Group>

                            <Form.Group>
                                <Form.Input label='Price' width={16} onChange={this.props.onChange} name="Price" />
                            </Form.Group>
                        </Form>
                    </Modal.Content>
                    <Modal.Actions>
                        <Button onClick={this.props.onClose} secondary >cancel</Button>
                        <Button onClick={() => this.props.onCreateSubmit(this.props.Create)} className="ui green button">Create  <i className="check icon"></i></Button>
                    </Modal.Actions>
                </Modal>
            </React.Fragment>

        )
    }
}