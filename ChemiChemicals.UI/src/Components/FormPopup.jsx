import React, { Component, useEffect,useState } from "react";
import Product from "../Services/Product";
import { Modal, Button, Form } from 'react-bootstrap';


function FormPopup({ showPopup, handleClose,handleOnInsertSuccess,handleOnInsertFail}) {
    const [showPopupState, setShowPopupState] = useState();
    const [newProduct, setNewProduct] = useState({ "productName": "", "supplierName": "", "url": "" });

    useEffect(() => {
        setShowPopupState(showPopup);
    });

    const addProduct = () => {
        Product.AddProduct(newProduct, handleOnInsertSuccess, handleOnInsertFail);
    }

    return (
        <Modal show={showPopupState} onHide={handleClose}>
            <Modal.Header closeButton>
                <Modal.Title>Add Product</Modal.Title>
            </Modal.Header>
            <Modal.Body>
                <form>
                    <div>
                        <label>Product Name</label>
                        <input type="text" value={newProduct.productName} onChange={value => setNewProduct({...newProduct,"productName": value.target.value })} />
                    </div>
                    <div>
                        <label>Supplier Name</label>
                        <input type="text" value={newProduct.supplierName} onChange={value => setNewProduct({ ...newProduct, "supplierName": value.target.value })} />
                    </div>
                    <div>
                        <label>Url</label>
                        <input type="text" value={newProduct.url} onChange={value => setNewProduct({ ...newProduct, "url": value.target.value })} />
                    </div>
                </form>
            </Modal.Body>
            <Modal.Footer>
                <Button variant="secondary" onClick={handleClose}>
                    Close
                </Button>
                <Button variant="primary" onClick={addProduct}>
                    Save Changes
                </Button>
            </Modal.Footer>
        </Modal>
       );
}

export default FormPopup;