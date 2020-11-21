import { render, screen, fireEvent } from '@testing-library/react';
import Header from '../Components/Header';
import { rest } from 'msw';
import { setupServer } from 'msw/node';
import '@testing-library/jest-dom/extend-expect'
import Product from "../Services/Product";

jest.mock("../Services/Product");

const server = setupServer(
    rest.get('/getRecentlyChangedProducts', (req, res, ctx) => {
        return res(ctx.json([
            {
                id: "56432a9a-02c4-43eb-88e9-e5e4ce536201",
                productName: 'product',
                supplierName: "supplier",
                url:"http://www.africau.edu/images/default/sample.pdf",
                binaryContent: "",
                isChanged: false,
                insertDate: "11-10-2020"
            }]))
    })
);

beforeAll(() => server.listen());
afterEach(() => server.resetHandlers());
afterAll(() => server.close());

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
    const getSpy = jest.spyOn(Product, 'GetRecentlyChangedProducts');
    render(<Header />);
    expect(getSpy).toBeCalled()
});
