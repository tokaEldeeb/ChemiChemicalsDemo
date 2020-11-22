import '@testing-library/jest-dom/extend-expect'
import { render, screen, fireEvent, waitFor } from '@testing-library/react';
import FormPopup from "../Components/FormPopup";
import Product from "../Services/Product";

const handleClose = jest.fn(() => console.log("closed is fired"));
const handleOnInsertSuccess =jest.fn(() => console.log("closed is fired"));
const handleOnInsertFail =jest.fn(() => console.log("closed is fired"));

test('test open popup', () => {
    render(<FormPopup showPopup={true} handleClose={handleClose} handleOnInsertSuccess={handleOnInsertSuccess} handleOnInsertFail={handleOnInsertFail} />);
    const modelShown = screen.getByRole("dialog");
    expect(modelShown).toHaveClass("show");
});

test('test close popup', () => {
    const { container } = render(<FormPopup showPopup={false} handleClose={handleClose} handleOnInsertSuccess={handleOnInsertSuccess} handleOnInsertFail={handleOnInsertFail} />);
    expect(container).toBeEmptyDOMElement();
});

test('test click close button', () => {
    render(<FormPopup showPopup={true} handleClose={handleClose} handleOnInsertSuccess={handleOnInsertSuccess} handleOnInsertFail={handleOnInsertFail} />);
    const closeBtn = screen.getAllByText("Close", { selector: 'button' });
    fireEvent.click(closeBtn[0]);
    expect(handleClose).toBeCalled();
});

test('test click submit', async () => {
    jest.mock("../Services/Product");
    const getSpy = jest.spyOn(Product, 'AddProduct');


    //mock the getrecetlychangedproducts function that get all the recently changed products
    const mockedFn = jest.fn((product,resolveCallback, errorCallBack) => {
        Promise.resolve([
            {
                id: "56432a9a-02c4-43eb-88e9-e5e4ce536201",
                productName: 'product',
                supplierName: "supplier",
                url: "http://www.africau.edu/images/default/sample.pdf",
                binaryContent: "",
                isChanged: false,
                insertDate: "11-10-2020"
            }]).then(handleOnInsertSuccess).catch(handleOnInsertFail)
    });

    Product.AddProduct.mockImplementation(mockedFn);

    render(<FormPopup showPopup={true} handleClose={handleClose} handleOnInsertSuccess={handleOnInsertSuccess} handleOnInsertFail={handleOnInsertFail} />);
    const submitBtn = screen.getAllByText("Save Changes", { selector: 'button' });
    fireEvent.click(submitBtn[0]);
    await waitFor(mockedFn);
    expect(handleOnInsertSuccess).toBeCalled()
});

test('test click submit for failed API ', async () => {
    jest.mock("../Services/Product");
    const getSpy = jest.spyOn(Product, 'AddProduct');


    //mock the getrecetlychangedproducts function that get all the recently changed products
    const mockedFn = jest.fn((product, resolveCallback, errorCallBack) => {
        Promise.reject("Failed").then(handleOnInsertSuccess).catch(handleOnInsertFail)
    });

    Product.AddProduct.mockImplementation(mockedFn);

    render(<FormPopup showPopup={true} handleClose={handleClose} handleOnInsertSuccess={handleOnInsertSuccess} handleOnInsertFail={handleOnInsertFail} />);
    const submitBtn = screen.getAllByText("Save Changes", { selector: 'button' });
    fireEvent.click(submitBtn[0]);
    await waitFor(mockedFn);
    expect(handleOnInsertFail).toBeCalled()
})
