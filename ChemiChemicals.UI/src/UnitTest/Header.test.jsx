import { render, screen, fireEvent, getByText, waitForElement, getByRole  } from '@testing-library/react';
import Header from '../Components/Header';
import '@testing-library/jest-dom/extend-expect'
import Product from "../Services/Product";


test('renders header', () => {
    render(<Header />);
    var headerTitle = screen.getByText("Chemi Chemicals Interface");
    expect(headerTitle).toBeInTheDocument();
});

test('toggle menu using toggle btn', async () => {
    const { container } = render(<Header />);
    const toggleBtn = document.getElementById('dropdown-basic');

    //toggle btn is clicked for first time
    fireEvent.click(toggleBtn);

    expect(container.getElementsByClassName("show")[0]).toBeInTheDocument();
    
    //toggle btn is clicked for second time so menu should be closed
    fireEvent.click(toggleBtn);
    for (var i = 0; i < container.children.length;i++) {
        expect(container.children[i]).not.toHaveClass("show");
    }

});

test('test calling api', async () => {
    jest.mock("../Services/Product");
    const getSpy = jest.spyOn(Product, 'GetRecentlyChangedProducts');
    render(<Header />);
    expect(getSpy).toBeCalled()
});



test('loading the notification', async () => {
    jest.mock("../Services/Product");
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

    Product.GetRecentlyChangedProducts.mockImplementation(mockedFn);

   const { container} = render(<Header />);

    //click on the toggle button to open the notification menu
    const toggleBtn = document.getElementById('dropdown-basic');
    fireEvent.click(toggleBtn);

    //look if the newly added item was found
    const newlyAddedNotification = await waitForElement(() => container.getElementsByClassName("dropdown-item")[0]);
    expect(newlyAddedNotification).toBeInTheDocument();
});