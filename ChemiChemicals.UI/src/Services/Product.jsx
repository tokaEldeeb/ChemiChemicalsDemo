const Product = {
    GetAllProducts: function (resolveCallback, errorCallBack) {
        fetch("https://localhost:5001/product/getallproducts")
            .then(res => {
                if (res.ok) {
                    return res.json()
                }
                throw new Error(res.status);
            })
            .then(resolveCallback).
            catch(errorCallBack);
    },

    GetRecentlyChangedProducts: function (resolveCallback, errorCallBack) {
        fetch("https://localhost:5001/product/GetRecentlyChangedProducts")
            .then(res => {
                if (res.ok) {
                    return res.json()
                }
                throw new Error(res.status);
            })
            .then(resolveCallback).
            catch(errorCallBack);
    },

    GetViewProductContentLink: function (productId) {
        return "https://localhost:5001/file/downloadfile/" + productId;
    },

    EditProduct: function (product, resolveCallback, errorCallBack) {
        fetch("https://localhost:5001/product/UpdateProduct", {
            method: "POST", headers: {
                'Content-Type': 'application/json'
            }, body: JSON.stringify(product) })
            .then(res => {
                if (res.ok) {
                    return res.json()
                }
                throw new Error("Error while editing product please make sure to fill all fields");
            })
            .then(resolveCallback).
            catch(errorCallBack);
    },
    AddProduct: function (product, resolveCallback, errorCallBack) {
        fetch("https://localhost:5001/product/InsertNewProduct", {
            method: "POST", headers: {
                'Content-Type': 'application/json'
            }, body: JSON.stringify(product)
        })
            .then(res => {
                if (res.ok) {
                    return res.json()
                }
                throw new Error("Error while add a product please fill all the data");
            })
            .then(resolveCallback).
            catch(errorCallBack);
    },
    DeleteProduct: function (product) {
        fetch("https://localhost:5001/product/DeleteProductByid/"+product.id)
            .then(res => res.json());
            
    }
};

export default Product;