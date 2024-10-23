import axios from 'axios';

const API_URL = 'http://www.bibliotecasanttotomas.somee.com/api/Books'; // Actualizado con la nueva URL

export const GetAllBooks = async () => {
    try {
        const response = await axios.get(API_URL); // Obtiene la lista de libros
        return response.data; // Devuelve la lista de libros
    } catch (error) {
        console.error("Error fetching books:", error);
        return []; // Devuelve un array vacío en caso de error
    }
}

export const GetBookById = async (Id) => {
    try {
        const response = await axios.get(`${API_URL}/${Id}`); 
        return response.data; // Devuelve los datos del libro
    } catch (error) {
        console.error("Error fetching book by id", error);
        throw error; // Lanza el error para que pueda ser manejado donde se llama
    }
};

export const CreateBook = async (book) => {
    const response = await fetch('http://www.bibliotecasanttotomas.somee.com/api/Books/', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(book),
    });

    if (!response.ok) {
        throw new Error('Error al crear el Libro');
    }

    return await response.json(); // Devuelve el nuevo conductor creado
};

export const UpdateBook = async (Id, bookData) => {
    try {
        const response = await axios.put(`${API_URL}/${Id}`, bookData); // Agrega "/" antes de bookId
        return response.data; // Devuelve los datos del libro actualizado
    } catch (error) {
        console.error("Error updating book:", error);
        throw error; // Lanza el error para que pueda ser manejado en el componente
    }
};

export const DeleteBook = async (id) => {
    try {
        await axios.delete(`${API_URL}/${id}`); // Utiliza el método DELETE
        return true; // Retorna true si la eliminación fue exitosa
    } catch (error) {
        console.error("Error deleting book:", error);
        return false; // Retorna false en caso de error
    }
};
