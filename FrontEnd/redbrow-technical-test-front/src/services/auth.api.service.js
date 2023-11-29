import axios from 'axios'

const login = async(email, password) => {
    const response = await axios.post('https://localhost:7175/api/Auth/login', {
        email: email,
        password: password,
    });
    return response.data
}

export {
    login
}