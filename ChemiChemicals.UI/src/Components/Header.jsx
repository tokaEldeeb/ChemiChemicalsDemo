import React from 'react';
import Product from '../Services/Product';
import { Dropdown } from 'react-bootstrap';
import NotificationsIcon from '@material-ui/icons/Notifications';

export class Header extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            "newProducts": [],
            "isNavCollapsed": true
        }
    }

    componentDidMount() {
        Product.GetRecentlyChangedProducts(
            (result) => this.setState(oldState => oldState.newProducts = result),
            (err) => new Error(err)
        );
    }

    ToggleNavCollapsed = () => {
        if (this.state.isNavCollapsed)
            this.setState(oldState => oldState.isNavCollapsed = false);
        else
            this.setState(oldState => oldState.isNavCollapsed = true);
    }

    render() {
        return (
            <nav className="navbar navbar-expand-lg navbar-light bg-light rounded">
                <div className="col-11">
                    <a className="navbar-brand text-info font-weight-bolder" href="#">
                    <span className="">Chemi Chemicals Interface</span>
                    </a>
                </div>
                <div className="col-1">
                <Dropdown align="right">
                    <Dropdown.Toggle variant="info" id="dropdown-basic" menuAlign="left">
                        <NotificationsIcon/>
                    </Dropdown.Toggle>
                    <Dropdown.Menu>
                        {
                            this.state.newProducts.map(product => {
                                return (<Dropdown.Item href="#">
                                    Product : {product.productName} of ID : {product.id} has been changed
                                </Dropdown.Item>)
                            })
                        }
                        </Dropdown.Menu>
                    </Dropdown>
                    </div>
            </nav>
            );
    }
}

export default Header;