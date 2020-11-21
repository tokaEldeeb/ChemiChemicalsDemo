import React, { Component } from "react";
import { Datatable } from "@o2xp/react-datatable";
import Product from "../Services/Product";
import TableOptions from "../Data/TableOptions";
import {
    Add as Add,
} from "@material-ui/icons";
import VisibilityIcon from '@material-ui/icons/Visibility';
import FormPopup from "./FormPopup";
import { Toast } from 'react-bootstrap';


const options = TableOptions;

class Table extends Component {

    constructor(props) {
        super(props);
        options.features.additionalIcons[0]={            
            title: "Add", 
            icon: <Add color="primary" />,
            onClick: this.handleShow
        };
        this.state = { "options": { ...options,"showError":false,"error":"" } };
    };

    componentDidMount() {
        Product.GetAllProducts(result => this.setState(oldstate => { oldstate.options.data.rows = result; return oldstate; }),
            this.handleFailCRUDOperation);
    }
   
    buildCustomTableBodyCell = ({ cellVal, column, rowId }) => {
        let val;
        switch (column.id) {
            case "binaryContent":
                val = <div style={{ textAlign: "center" }}>
                    <a href={Product.GetViewProductContentLink(rowId)} target="blank" style={{ color: "#17a2b8", textAlign: "center" }}>
                    <VisibilityIcon/>
                    </a>
                </div>;
                break;
            default:
                val = <div style={{ color: "#17a2b8", textAlign:"center" }}>{cellVal}</div>;
                break;
        }
        return val;
    };

    actionsRow = ({ type, payload }) => {
        switch (type){
            case "save": {
                Product.EditProduct(payload,
                    result => this.setState(oldState => {
                        var index = oldState.options.data.rows.findIndex(r => r.id == result.id);
                        oldState.options.data.rows[index] = result;
                        return oldState;
                    }),
                    this.handleFailCRUDOperation);
                break;
            }
            case "delete": {
                Product.DeleteProduct(payload);
                break;
            }                 
        }

    };
    handleClose = () => {
        this.setState(oldState => oldState.showPopup = false);
    };

    handleShow = () => {
        this.setState(oldState => oldState.showPopup = true);
    };

    handleOnInsertSuccess = (result) => {
        if (this.state.options.data.rows.findIndex(r => r.id == result.id) == -1) //to ensure that it wasnot pushed before
            this.setState(oldState => {
                oldState.showPopup = false;
                if (this.state.options.data.rows.findIndex(r => r.id == result.id) == -1)
                    oldState.options.data.rows.push(result);
                return oldState;
            });
    }
    handleFailCRUDOperation = (err) => {
        this.setState(oldState => {
            oldState.showPopup = false;
            oldState.showError = true;
            oldState.error= err.message;
            return oldState;
        });
    }

    render() {
        return (
            <React.Fragment>
                {this.state.showError && <div className="col-6">
                    <Toast onClose={() => this.setState(state => state.showError = false)} show={this.state.showError} delay={3000} autohide>
                        <Toast.Header>
                            <strong className="mr-auto">Error</strong>
                        </Toast.Header>
                        <Toast.Body>{this.state.error}</Toast.Body>
                    </Toast>
                </div>}
                <Datatable
                    options={this.state.options}
                    actions={this.actionsRow}
                    CustomTableBodyCell={this.buildCustomTableBodyCell}
                />
                <FormPopup showPopup={this.state.showPopup} handleClose={this.handleClose} handleOnInsertSuccess={this.handleOnInsertSuccess} handleOnInsertFail={this.handleFailCRUDOperation} />

            </React.Fragment>
        );
    }
}

export default Table;

