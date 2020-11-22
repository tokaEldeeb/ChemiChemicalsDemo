import { render, screen, fireEvent, getByText, waitForElement, getByRole, waitFor } from '@testing-library/react';
import Table from '../Components/Table';
import '@testing-library/jest-dom/extend-expect'
import Product from "../Services/Product";

test('load products in table rows', async () => {
    jest.mock("../Services/Product");
    const getSpy = jest.spyOn(Product, 'GetAllProducts');

    //mock the getrecetlychangedproducts function that get all the recently changed products
    const mockedFn = jest.fn((resolveCallback, errorCallBack) => {
        Promise.resolve([
            {
                id: "56432a9a-02c4-43eb-88e9-e5e4ce536201",
                productName: 'product',
                supplierName: "supplier",
                url: "http://www.africau.edu/images/default/sample.pdf",
                binaryContent: "",
                isChanged: false,
                insertDate: "11-10-2020"
            }]).then(resolveCallback).catch(errorCallBack)
    });

    Product.GetAllProducts.mockImplementation(mockedFn);
    render(<Table />);
    await waitFor(mockedFn);
    expect(screen.getByText("http://www.africau.edu/images/default/sample.pdf")).toBeInTheDocument();
});