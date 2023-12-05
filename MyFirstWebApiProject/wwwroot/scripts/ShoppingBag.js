let sum = 0

const getProduct = async () => {
    let products = JSON.parse(sessionStorage.getItem("cartProducts"))

    let count = 0
    if (!products) {
        document.getElementById("noItems").innerText = "Add products to cart to see them here."
        return
    }

    for (let i = 0; i < products.length; i++) {
        showCart(products[i])
        sum += products[i].price
        count++
    }
    document.getElementById("itemCount").innerText = count
    document.getElementById("totalAmount").innerText = sum + ' ₪'
}


const showCart = (product) => {
    let temp = document.getElementById("temp-row")
    var cloneCart = temp.content.cloneNode(true)
    cloneCart.querySelector(".image").src = `./pic/${product.image}`
    cloneCart.querySelector(".descriptionColumn").innerText = product.productName
    cloneCart.querySelector(".price").innerText = product.price + ' ₪'
    cloneCart.querySelector("#deleteButton").addEventListener('click', () => deleteItem(product))
    document.getElementById("items").appendChild(cloneCart)
}

const placeOrder = async () => {
    try {
        let products = sessionStorage.getItem("cartProducts")
        console.log(products)
        if (!products) {
            alert("Add products to create your order")
            return
        }
        let user = sessionStorage.getItem("User")
        if (!user) {
            alert("Please login,\n Waiting to see you here!")
            document.location = 'login.html'
            return
        }
        user = JSON.parse(user)
        let product = JSON.parse(sessionStorage.getItem("cartProducts"))
        let orderItem = []
        for (let i = 0; i < product.length; i++) {
            const ord = orderItem.findIndex(p => p.productId == product[i].productId)
            if (ord > -1)
                orderItem[ord].quantity++
            else
                orderItem.push({ "productId": product[i].productId, "quantity": 1, "price": product[i].price })
        }
        const order = {
            "userId": user.userId,
            "orderSum": sum,
            "orderDate": new Date(),
            "orderItems": orderItem
        }

        const theOrder = await fetch('/api/Order', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(order)
        })
        if (!theOrder.ok)
            alert("Error: problem on post-order")
        else {
            const data = await theOrder.json()
            alert("Order ID " + data + " placed successfully")
            sessionStorage.removeItem("cartProducts")
            document.location = 'store.html'
        }

    } catch (ex) {
        alert(ex.message)
    }
}


const deleteItem = (product) => {

    let cart = JSON.parse(sessionStorage.getItem("cartProducts"))
    const ind = cart.findIndex(productInCart => productInCart.productId == product.productId)
    cart.splice(ind, 1)
    JSON.stringify(sessionStorage.setItem("cartProducts", JSON.stringify(cart)))

    if (cart.length == 0)
        sessionStorage.removeItem("cartProducts")

    document.location = "ShoppingBag.html"
}
