import React, { useEffect, useState } from 'react';
import { useParams } from 'react-router-dom';
import { GetBookById } from '../Service/BookService.js'; // Asegúrate de tener esta función

const BookDetail = () => {
    const { id } = useParams(); // Tomamos el id desde la URL
    const [book, setBook] = useState(null); // Estado para almacenar los datos del libro

    useEffect(() => {
        const fetchBook = async () => {
            const result = await GetBookById(id); // Llamada al servicio para obtener el libro
            setBook(result); // Actualizamos el estado con el resultado
        };
        fetchBook();
    }, [id]); // Se ejecuta cada vez que cambia el id

    if (!book) return <div>Cargando...</div>; // Mientras no tengamos datos, mostramos un mensaje de carga

    return (
        <div>
            <h2>Detalles del Libro</h2>
            <p>Título: {book.title}</p>
            <p>Código: {book.code}</p>
            <p>Año de Publicación: {book.publicationYear}</p>
            <p>Edición: {book.edition?.name || 'Sin información de edición'}</p> {/* Si la edición existe, muestra su nombre */}
            <p>Eliminado: {book.isDelete ? "Sí" : "No"}</p> {/* Mostramos si está marcado como eliminado o no */}
            {/* Otros detalles que desees mostrar */}
        </div>
    );
};

export default BookDetail;
