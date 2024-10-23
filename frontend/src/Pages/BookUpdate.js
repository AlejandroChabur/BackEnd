import React, { useState, useEffect } from 'react';
import { useParams, useNavigate } from 'react-router-dom';
import { GetBookById, UpdateBook } from '../Service/BookService.js'; // Aseg�rate de tener estos servicios

const UpdateBookPage = () => {
    const { id } = useParams(); // Captura el ID desde la URL
    const navigate = useNavigate(); // Para redireccionar despu�s de la actualizaci�n
    const [book, setBook] = useState({
        title: '',
        code: '',
        publicationYear: '',
        idEdition: '',
        isDelete: false,
    });

    // Cargar datos del libro al montar el componente
    useEffect(() => {
        const fetchBook = async () => {
            console.log("Book ID from URL:", id); // Verifica el valor del ID
            try {
                const fetchedBook = await GetBookById(id);
                if (fetchedBook) {
                    setBook(fetchedBook);
                }
            } catch (error) {
                console.error("Error fetching book:", error);
            }
        };
        fetchBook();
    }, [id]);

    // Funci�n para manejar cambios en el formulario
    const handleChange = (e) => {
        const { name, value, type, checked } = e.target;
        setBook({
            ...book,
            [name]: type === 'checkbox' ? checked : value
        });
    };

    // Funci�n para manejar el submit del formulario
    const handleSubmit = async (e) => {
        e.preventDefault();
        try {
            console.log("Updating book with data:", book); // Imprime los datos para verificar
            await UpdateBook(id, book); // Llama al servicio para actualizar el libro
            navigate('/'); // Redirecciona despu�s de la actualizaci�n
        } catch (error) {
            console.error("Error updating book:", error);
        }
    };

    return (
        <div>
            <h1>Actualizar Libro</h1>
            <form onSubmit={handleSubmit}>
                <div>
                    <label>T�tulo:</label>
                    <input
                        type="text"
                        name="title"
                        value={book.title}
                        onChange={handleChange}
                        required
                    />
                </div>
                <div>
                    <label>C�digo:</label>
                    <input
                        type="text"
                        name="code"
                        value={book.code}
                        onChange={handleChange}
                        required
                    />
                </div>
                <div>
                    <label>A�o de Publicaci�n:</label>
                    <input
                        type="text"
                        name="publicationYear"
                        value={book.publicationYear}
                        onChange={handleChange}
                        required
                    />
                </div>
                <div>
                    <label>Edici�n:</label>
                    <input
                        type="text"
                        name="idEdition"
                        value={book.idEdition}
                        onChange={handleChange}
                        required
                    />
                </div>
                <div>
                    <label>Eliminado:</label>
                    <input
                        type="checkbox"
                        name="isDelete"
                        checked={book.isDelete}
                        onChange={handleChange}
                    />
                </div>
                <button type="submit">Actualizar Libro</button>
            </form>
        </div>
    );
};

export default UpdateBookPage;
