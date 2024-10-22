import React, { useState } from 'react';
import { CreateBook } from '../Service/BookService.js';
import { useNavigate } from 'react-router-dom';

const CreateBookForm = () => {
    const [idedition, setIdEdition] = useState('');
    const [title, setTitle] = useState('');
    const [publicationyear, setPublicationYear] = useState('');

    const [errorMessage, setErrorMessage] = useState(''); // Estado para manejar errores

    const navigate = useNavigate(); // Usar useNavigate para redirigir a otras páginas

    const handleSubmit = async (e) => {
        e.preventDefault();
        setErrorMessage(''); // Resetea el mensaje de error

        const newBook = {
            idedition,
            title,
            publicationyear,
           
        };

        try {
            const result = await CreateDriver(newBook);
            alert("Libro creado exitosamente");
            // Limpia el formulario después de crear el conductor
            setIdEdition('');
            setTitle('');
            setPublicationYear('');
          
            navigate('/books'); // Redirige a la lista de conductores
        } catch (error) {
            setErrorMessage("Error al crear el Libro"); // Manejo de errores
        }
    };

    return (
        <form onSubmit={handleSubmit}>
            <div>
                <label>Edicion:</label>
                <input
                    type="text"
                    value={idedition}
                    onChange={(e) => setIdEdition(e.target.value)}
                    required
                />
            </div>
            <div>
                <label>Titulo:</label>
                <input
                    type="text"
                    value={title}
                    onChange={(e) => setTitle(e.target.value)}
                    required
                />
            </div>
            <div>
                <label>Fecha de publicación:</label>
                <input
                    type="text"
                    value={publicationyear}
                    onChange={(e) => setPublicationYear(e.target.value)}
                    required
                />
            </div>
           
            {errorMessage && <p style={{ color: 'red' }}>{errorMessage}</p>} {/* Muestra el mensaje de error */}
            <button type="submit">Crear Libro</button>
        </form>
    );
};

export default CreateBookForm;
