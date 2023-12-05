const register = async () => {
    try {
        const user = {
            FirstName: document.getElementById("txtFName").value,
            LastName: document.getElementById("txtLName").value,
            Email: document.getElementById("txtEmailReg").value,
            Password: document.getElementById("txtPasswordReg").value
        }
        if (!user.Email || !user.Password)
            throw new Error("Error: No user to add");

        const strong = await checkPassword(user.Password);
        if (strong == 0)
            alert("Your password is weak, Enter password again!");
        else {
            const res = await fetch("/api/user", {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(user)
            })
            if (!res.ok)
                throw new Error("Error: Adding user to server");

            const u = await res.json()
            document.getElementById("Register").style.visibility = "hidden";
            alert(`${u.firstName || u.email} created`);
        }
    }
    catch (ex) {
        alert(ex.message)
    }
}

const registerVisible = () => document.getElementById("Register").style.visibility = "visible";


const login = async () => {
    try {
        const user = {
            Email: document.getElementById("txtEmailLog").value,
            Password: document.getElementById("txtPasswordLog").value
        }
        const res = await fetch(`/api/user/login`,
            {
                method: 'Post',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(user)
            })
        if (!res.ok)
            throw new Error("Error: login user to server");

        if (res.status == 204)
            alert("User name or password are incorrect.\nTry again!")

        const myUser = await res.json();

        sessionStorage.setItem("User", JSON.stringify(myUser))
        document.location = "updateUserDetails.html"
        const name = myUser.firstName || myUser.email
        alert(`Welcome ${name.trim()}!`);
    }
    catch (ex) {
        alert(ex.message)
    }
}

const update = async () => {
    try {
        const user = {
            FirstName: document.getElementById("txtFName").value,
            LastName: document.getElementById("txtLName").value,
            Email: document.getElementById("txtEmail").value,
            Password: document.getElementById("txtPassword").value,
            UserId: JSON.parse(sessionStorage.getItem("User")).userId
        }
        const strong = await checkPassword(user.Password);
        if (strong == 0)
            alert("Your password is weak, Enter password again!");
        else {
            const res = await fetch(`/api/user/${user.UserId}`, {
                method: 'PUT',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(user)
            })

            if (!res.ok)
                throw new Error("Error: Update user to server");
            const myUser = await res.json()
            sessionStorage.setItem("User", JSON.stringify(myUser))
            document.location = "updateUserDetails.html"
            const name = myUser.firstName || myUser.email
            alert(`${name} updtaed!`);

        }
    }
    catch (ex) {
        alert(ex.message)
    }
}

const checkPassword = async (pass) => {
    try {
        const check = await fetch("/api/user/checkPassword", {
            method: 'POST',
            headers: {
                'Content-Type': "application/json"
            },
            body: JSON.stringify(pass)
        })
        if (!check.ok)
            throw new Error("Error: Check password strength failed")

        const score = await check.json()
        document.getElementById("progress").value = score

        if (score > 2)
            return 1;
        else
            return 0;
    }
    catch (ex) {
        alert(ex.message)
    }
}

const fillFields = () => {
    const user = JSON.parse(sessionStorage.getItem('User'))
    document.getElementById("txtFName").value = (user.firstName).trim() || ''
    document.getElementById("txtLName").value = (user.lastName).trim() || ''
}