import React, { useState } from 'react';
import { CreateBook } from '../Service/BookService.js';
import { useNavigate } from 'react-router-dom';

const CreateBookForm = () => {
    const [idEdition, setIdEdition] = useState('');
    const [title, setTitle] = useState('');
    const [publicationYear, setPublicationYear] = useState('');
    const [code, setCode] = useState('');
    const [errorMessage, setErrorMessage] = useState('');

    const handleSubmit = async (e) => {
        e.preventDefault();
        setErrorMessage('');

        const newBook = {
            idEdition: parseInt(idEdition, 10), // Aseg�rate de convertir a n�mero
            title,
            publicationYear, // Debe estar en formato 'YYYY-MM-DD'
            code,
            isDelete: false,
            edition: { // Aqu� agregamos la propiedad edition
                id: parseInt(idEdition, 10), // El id de la edici�n
                editionName: "Primera", // Nombre de la edici�n (puedes modificar esto seg�n sea necesario)
                isDelete: true // Este valor depende de tu l�gica
            }
        };

        try {
            console.log("Enviando datos del libro:", newBook); // Para depuraci�n
            const result = await CreateBook(newBook);
            alert("Libro creado exitosamente");
            // Limpia el formulario
            setIdEdition('');
            setTitle('');
            setPublicationYear('');
            setCode('');
            navigate('/books'); // Redirige despu�s de crear el libro
        } catch (error) {
            console.error("Error en la creaci�n del libro:", error);
            setErrorMessage("Error al crear el Libro");
        }
    };

    return (
        <form onSubmit={handleSubmit}>
            <div>
                <label>Edici�n:</label>
                <input
                    type="number"
                    value={idEdition}
                    onChange={(e) => setIdEdition(e.target.value)}
                    required
                />
            </div>
            <div>
                <label>T�tulo:</label>
                <input
                    type="text"
                    value={title}
                    onChange={(e) => setTitle(e.target.value)}
                    required
                />
            </div>
            <div>
                <label>Fecha de publicaci�n:</label>
                <input
                    type="date" // Facilita el ingreso de fechas
                    value={publicationYear}
                    onChange={(e) => setPublicationYear(e.target.value)}
                    required
                />
            </div>
            <div>
                <label>C�digo:</label>
                <input
                    type="text"
                    value={code}
                    onChange={(e) => setCode(e.target.value)}
                    required
                />
            </div>

            {errorMessage && <p style={{ color: 'red' }}>{errorMessage}</p>}
            <button type="submit">Crear Libro</button>
        </form>
    );
};

export default CreateBookForm;
