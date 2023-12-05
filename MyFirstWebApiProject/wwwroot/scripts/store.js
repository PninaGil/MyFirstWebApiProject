

const filterProducts = async () => {
    let cart = JSON.parse(sessionStorage.getItem("cartProducts"))
    document.getElementById("ItemsCountText").innerText = cart?.length || 0

    let minPrice = document.getElementById("minPrice").value
    let maxPrice = document.getElementById("maxPrice").value
    let desc = document.getElementById("nameSearch").value

    let opt = document.getElementsByClassName("opt")
    let url = `/api/Product?minPrice=${minPrice}&maxPrice=${maxPrice}&Desc=${desc}`
    for (let i = 0; i < opt.length; i++) {
        if (opt[i].checked)
            url += "&categoryIds=" + opt[i].id
    }

    try {
        const product = await fetch(url, {
            method: 'GET',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify()
        })
        if (!product.ok)
            throw ("problem on get products")

        const products = await product.json()

        document.getElementById("counter").innerHTML = await products.length

        document.getElementById("ProductList").replaceChildren([])

        products.forEach(p => drawProduct(p))
    } catch (ex) {
        alert(ex.message + " products")
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

let cartProducts = JSON.parse(sessionStorage.getItem("cartProducts")) || []

const addToCart = (product) => {
    cartProducts.push(product)
    sessionStorage.setItem("cartProducts", JSON.stringify(cartProducts))
    document.getElementById("ItemsCountText").innerText = cartProducts.length
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
            showCategory(category[i])
        }
    } catch (ex) {
        alert(ex.message)
    }
}
const showCategory = (category) => {
    let temp = document.getElementById("temp-category")
    var cloneCategory = temp.content.cloneNode(true)
    cloneCategory.querySelector(".OptionName").innerText = category.categoryName;
    cloneCategory.querySelector(".opt").id = category.categoryId
    cloneCategory.querySelector("label").setAttribute("for", category.id);
    document.getElementById("categoryList").addEventListener('click', () => filterProducts())
    document.getElementById("categoryList").appendChild(cloneCategory)

}

