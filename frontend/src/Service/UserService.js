import axios from 'axios';
const API_URL = 'http://www.bibliotecasanttotomas.somee.com/api/User';
const deleteUser


export const login = async (credentials) => {
    return await axios.post('http://www.bibliotecasanttotomas.somee.com/api/User/login', credentials);
};
export const createUser = async (user) => {
    const response = await axios.post('http://www.bibliotecasanttotomas.somee.com/api/User', user);
    return response.data;
};
export const GetAllUsers = async () => {
    try {
        const response = await axios.get('http://www.bibliotecasanttotomas.somee.com/api/User'); // Asegúrate de reemplazar con la URL correcta de tu API
        return response.data; // Devuelve la lista de conductores
    } catch (error) {
        console.error("Error fetching users:", error);
        return []; // Devuelve un array vacío en caso de error
    }
}
export const GetUserById = async (userId) => {
    try {
        const response = await axios.get(`${'http://www.bibliotecasanttotomas.somee.com/api/User'}/${userId}`); // Asegúrate de incluir la barra antes de driverId
        return response.data; // Asegúrate de devolver los datos correctos
    } catch (error) {
        console.error("Error fetching user by id", error);
        throw error; // Lanza el error para que pueda ser manejado donde se llama
    }
};
export const UpdateUser = async (userId, userData) => {
    try {
        const response = await axios.put('http://www.bibliotecasanttotomas.somee.com/api/User/login', userData); 
        return response.data;
    } catch (error) {
        console.error("Error updating user:", error);
        throw error; // Lanza el error para que pueda ser manejado en el componente
    }
}; export const DeleteUser = async (userId) => {
    try {
        const response = await axios.delete(`http://www.bibliotecasanttotomas.somee.com/api/User/${userId}`);
        console.log('Usuario eliminado con éxito:', response.data);
        alert('Usuario eliminado exitosamente');
    } catch (error) {
        console.error('Error al eliminar el usuario:', error);
        alert('Error al eliminar el usuario');
    }

};

export default deleteUser;