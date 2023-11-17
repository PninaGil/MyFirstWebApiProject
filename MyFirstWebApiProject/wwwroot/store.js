
const filterProducts = async () => {
    let minPrice = document.getElementById("minPrice").value
    let maxPrice = document.getElementById("maxPrice").value
    let desc = document.getElementById("nameSearch").value
    let opt = document.getElementsByClassName("opt")
    let url = `/api/Product?minPrice=${minPrice}&maxPrice=${maxPrice}&Desc=${desc}`
    for (let i = 0; i < opt.length; i++) {
        if (opt[i].checked)
            url += "&categoriIds=" + opt[i].id
    }
    try {
       
        /*const categoryids = document.getElementById("")*/
        const product = await fetch(url,{
            method: 'GET',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify()
        })
        if (!product.ok)
            throw("problem on get products")
        const products = await product.json()
        document.getElementById("ProductList").replaceChildren([])

        products.forEach(p => drawProduct(p))
    } catch (ex) {
        alert(ex.message+" products")
    }
}

const drawProduct = (product) => {
    tmp = document.getElementById("temp-card")
    var cloneProduct = tmp.content.cloneNode(true)
    cloneProduct.querySelector("img").src = './pic/' + product.image
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
        const c = await fetch("/api/Category", {
            method: 'GET',
            headers: {
                'Content-Type': "application/json"
            },
            body: JSON.stringify()
        })
        if (!c.ok)
            alert("problem on get categories")
        const category = await c.json()
        for (let i = 0; i < category.length; i++) {
            console.log(category[i]);
            showCategory(category[i])
        }
        //category.forEach(cat => console.log(cat), showCategory(cat))
    } catch (ex) {
        alert(ex.message)
    }
}
const showCategory = (category) => {
    console.log("fgdhyu");
    let temp = document.getElementById("temp-category")
    var cloneCategory = temp.content.cloneNode(true)
    cloneCategory.querySelector(".OptionName").innerText = category.categoryName;
    cloneCategory.querySelector(".OptionName").id = category.categoryId
    document.getElementById("categoryList").addEventListener('click', () => filterProducts())
    document.getElementById("categoryList").appendChild(cloneCategory)

}

