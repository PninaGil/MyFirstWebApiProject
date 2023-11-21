
const getProduct = async () => {
    let products = JSON.parse(sessionStorage.getItem("cartProducts"))
    let sum = 0
    let count = 0
    if (!products) {
        document.getElementById("noItems").innerText="Add products to cart to see them here."
    }

    for (let i = 0; i < products.length; i++) {
        showCart(products[i])
        sum += products[i].price
        count++
    }
    document.getElementById("itemCount").innerText = count
    document.getElementById("totalAmount").innerText = sum+' ₪'

}


const showCart =(product) => {
    let temp = document.getElementById("temp-row")
    var cloneCart = temp.content.cloneNode(true)
    cloneCart.querySelector(".image").src = `./pic/${product.image}`
    //cloneCart.querySelector(".descriptionColumn").innerText = product.description
    cloneCart.querySelector(".descriptionColumn").innerText = product.productName
    cloneCart.querySelector(".price").innerText = product.price + ' ₪'
    cloneCart.querySelector("#deleteButton").addEventListener('click', () => deleteItem(product))
    document.getElementById("items").appendChild(cloneCart)
}

const placeOrder = async () => {
    try {
        const products = sessionStorage.getItem("cartProducts")
        let userId = sessionStorage.getItem("User")
        if (userId)
            userId = userId.userId
        else {
            alert("Please login,\nWaiting to see you here :)")
            document.location = 'login.html'
            return
        }

        const order = await fetch(`api/Order`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: { userId, products }
        })
        if (!order.ok)
            alert("Error: problem on post-order")
        else
            alert("The order created!!")
    } catch (ex) {
        alert(ex.message)
    }
    
}

const deleteItem = (product) => {
    let cart = JSON.parse(sessionStorage.getItem("cartProducts"))
    cart = cart.filter(p => p.productId != product.productId)
    JSON.stringify(sessionStorage.setItem("cartProducts", JSON.stringify(cart)))
    document.location="ShoppingBag.html"
}
