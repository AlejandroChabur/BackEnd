import React, { useState, useEffect } from 'react';
import { useParams } from 'react-router-dom';
import { GetBookById, UpdateBook } from '../Service/BookService.js'; // Asegúrate de tener estos servicios

const UpdateBookForm = () => {
    const { id } = useParams(); // Obtiene el ID del libro desde la URL
    console.log("Book ID:", id); // Verifica que el ID se capture correctamente

    // Estado inicial del libro
    const [book, setBook] = useState({
        id: id,
        title: '',
        code: '',
        publicationYear: '',
        idEdition: '',
        isDelete: false,
    });

    const [loading, setLoading] = useState(true); // Estado de carga
    const [message, setMessage] = useState(''); // Estado para mensajes de éxito o error

    useEffect(() => {
        const fetchBook = async () => {
            try {
                const fetchedBook = await GetBookById(id); // Obtiene el libro por su ID
                if (fetchedBook) {
                    setBook(fetchedBook); // Asigna los datos obtenidos al estado
                }
            } catch (error) {
                console.error("Error fetching book by id", error); // Manejo de errores
            } finally {
                setLoading(false); // Finaliza el estado de carga
            }
        };

        fetchBook(); // Llama a la función para obtener el libro
    }, [id]);

    // Manejo del cambio en los inputs del formulario
    const handleInputChange = (e) => {
        const { name, value } = e.target;
        setBook({ ...book, [name]: value });
    };

    // Manejo del envío del formulario
    const handleSubmit = async (e) => {
        e.preventDefault();

        const updatedBook = {
            ...book,
            modified: new Date().toISOString(),
            modifiedBy: 'tuNombreUsuario' // Puedes cambiarlo por el usuario actual
        };

        try {
            const result = await UpdateBook(id, updatedBook); // Actualiza el libro
            if (result) {
                setMessage('Libro actualizado con éxito');
            } else {
                setMessage('Error actualizando el libro');
            }
        } catch (error) {
            setMessage('Error al actualizar el libro');
        }
    };

    if (loading) {
        return <div>Cargando...</div>; // Mientras se cargan los datos del libro
    }

    return (
        <div>
            <h2>Actualizar Libro</h2>
            {message && <p>{message}</p>} {/* Muestra mensaje de éxito o error */}
            <form onSubmit={handleSubmit}>
                <div>
                    <label>Título del Libro</label>
                    <input
                        type="text"
                        name="title"
                        value={book.title}
                        onChange={handleInputChange}
                        required
                    />
                </div>

