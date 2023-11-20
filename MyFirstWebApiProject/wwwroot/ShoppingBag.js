
const getProduct = async () => {
    let products = sessionStorage.getItem("cartProducts")
    console.log(products)
    let sum = 0
    let count = 0
    for (let i = 0; i < products.length; i++) {
        showCart(products[i])
        sum += products[i].price
        count++
    }
    document.getElementById("itemCount").innerText = count
    document.getElementById("totalAmount").innerText = sum

}


const showCart =(product) => {
    let temp = document.getElementById("temp-row")
    var cloneCart = temp.content.cloneNode(true)
    cloneCart.querySelector("image").src = './pic/' + product.image?
    cloneCart.querySelector("descriptionColumn").innerText = product.description
    cloneCart.querySelector("itemName").innerText = product.productName
    cloneCart.querySelector("price").innerText = product.price + ' ₪'
    document.getElementById("item-row").appendChild(cloneCart)
}

const placeOrder = async () => {
    try {
        const order = {
            orderItem: sessionStorage.setItem("cartProducts")
        userId: sessionStorage.setItem("User").userId
        orderSum: document.getElementsByClassName("price").value
        }
        const order = await fetch("api/Order/?order=" + order, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify()
        })
        if (!order.ok)
            alert("problem on post-order")
        alert("The order created!!")
    } catch (ex) {
        alert(ex.message)
    }
    
}
}