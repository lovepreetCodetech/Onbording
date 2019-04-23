import React, { Component}from 'react';
import ReactDOM from 'react-dom';
import { Modal, Button, Form, Message } from 'semantic-ui-react';


export default class CustomerUpdate extends Component {
    constructor(props) {
        super(props);
        this.state = {


        };
    }
    render() {
        return (
            <React.Fragment>
             

                <Modal open={this.props.showUpdateModal} onClose={this.props.onClose}>
                    <Modal.Header> Edit Cutomer</Modal.Header>
                    
                    <Modal.Content>
                        <Form size="small">
                            <Form.Group>
                                <Form.Input label='NAME' width={16} onChange={this.props.onChange} name="Name" defaultValue={this.props.Name} />
                            </Form.Group>
                            <Form.Group>
                                <Form.Input label='ADDRESS' width={16} onChange={this.props.onChange} name="Address" defaultValue={this.props.Address} />
                            </Form.Group>
                        </Form>
                    </Modal.Content>
                    <Modal.Actions>
                        <Modal.Actions>
                            <Button onClick={this.props.onClose} secondary >cancel</Button>
                            <Button onClick={() => this.props.onUpdateSubmit(this.props.update)} className="ui yellow button">Submit <i className="check icon"></i></Button>
                        </Modal.Actions>
                    </Modal.Actions>
                    </Modal>
                
            </React.Fragment>
        )
    }
}

