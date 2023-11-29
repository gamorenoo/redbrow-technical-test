import axios from 'axios'

const getUsers = async(token) => {
    const response = await axios.get('https://localhost:7175/api/user', {
        headers: {
          Authorization: `Bearer ${token}`,
        },
    });

    return response.data;
}

const saveUser = async(token, user) => {
    const response = await axios.post('https://localhost:7175/api/user', user, {
        headers: {
            Authorization: `Bearer ${token}`,
            'Content-Type': 'application/json',
        },
    });

    return response;
}

const editUser = async(token, user) => {
    const response = await axios.put('https://localhost:7175/api/user', user, {
        headers: {
            Authorization: `Bearer ${token}`,
            'Content-Type': 'application/json',
        },
    });

    return response;
}

const deleteUsers = async(token, idUser) => {
    const response = await axios.delete('https://localhost:7175/api/user/' + idUser, {
        headers: {
          Authorization: `Bearer ${token}`,
        },
    });

    return response.data;
}

export {
    getUsers,
    saveUser,
    editUser,
    deleteUsers
}