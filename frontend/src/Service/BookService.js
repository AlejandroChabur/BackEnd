import axios from 'axios';

const API_URL = 'https://bibliotecasantotomas.somee.com/api/BookController'; // Actualizado con la nueva URL

export const GetAllBooks = async () => {
    try {
        const response = await axios.get(API_URL); // Obtiene la lista de libros
        return response.data; // Devuelve la lista de libros
    } catch (error) {
        console.error("Error fetching books:", error);
        return []; // Devuelve un array vac�o en caso de error
    }
}

export const GetBookById = async (Id) => {
    try {
        const response = await axios.get(`${API_URL}/${Id}`); // Aseg�rate de incluir la barra antes de bookId
        return response.data; // Devuelve los datos del libro
    } catch (error) {
        console.error("Error fetching book by id", error);
        throw error; // Lanza el error para que pueda ser manejado donde se llama
    }
};

export const CreateBook = async (book) => {
    try {
        const response = await fetch ('https://bibliotecasantotomas.somee.com/api/BookController/',{
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            }
        });

        return response.data; // Devuelve el nuevo libro creado
    } catch (error) {
        console.error("Error creating book:", error);
        throw new Error('Error al crear el libro'); // Lanza el error si la creaci�n falla
    }
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
        await axios.delete(`${API_URL}/${id}`); // Utiliza el m�todo DELETE
        return true; // Retorna true si la eliminaci�n fue exitosa
    } catch (error) {
        console.error("Error deleting book:", error);
        return false; // Retorna false en caso de error
    }
};
