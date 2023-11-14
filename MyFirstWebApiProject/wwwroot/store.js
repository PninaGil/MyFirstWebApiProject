
const filterProducts = async () => {
    try {
        const product = await fetch("/api/Product",{
            method: 'GET',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify()
        })
        if (!product.ok)
            throw("problem on get products")
        const products = await product.json()
        products.forEach(p => drawProduct(p))
    } catch (ex) {
        alert(ex.message+" products")
    }
}

const drawProduct = (product) => {
    tmp = document.getElementById("temp-card")
    var cloneProduct = tmp.content.cloneProduct(true)
    document.getElementById("ProductList").innerHTML("")
    cloneProduct.querySelector("img").source = "./pic/" + product.imageUrl
    cloneProduct.querySelector("h1").innerText = product.productName
    cloneProduct.querySelector(".price").innerText = product.price + '₪'
    cloneProduct.querySelector(".description").innerText = product.description
    cloneProduct.querySelector("button").addEventListener("click", () => addToCart(product))
    document.getElementById("ProductList").appendChild(cloneProduct)
}

const addrtoCart = (product) => {

}

const getCategories = async () => {
    try {
        const c = fetch("/api/Category", {
            method: 'GET',
            headers: {
                'Content-Type': "application/json"
            },
            body: JSON.stringify()
        })
        if (!c.ok)
            alert("problem on get categories")
        const category = await c.json()
        category.forEach(c => showCategory(c))
    } catch (ex) {
        alert(ex.message)
    }
}
const showCategory = (category) => {
    temp = document.getElementById("temp-category")
    var cloneCategory = temp.content.cloneNode(true)
    cloneCategory.querySelector("checkbox").innerText = category.name;
}

