import React, { useEffect, useState } from 'react';
import { useParams } from 'react-router-dom';
import { GetBookById } from '../Service/BookService.js'; // Aseg�rate de tener esta funci�n

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
            <p>T�tulo: {book.title}</p>
            <p>C�digo: {book.code}</p>
            <p>A�o de Publicaci�n: {book.publicationYear}</p>
            <p>Edici�n: {book.edition?.name || 'Sin informaci�n de edici�n'}</p> {/* Si la edici�n existe, muestra su nombre */}
            <p>Eliminado: {book.isDelete ? "S�" : "No"}</p> {/* Mostramos si est� marcado como eliminado o no */}
            {/* Otros detalles que desees mostrar */}
        </div>
    );
};

export default BookDetail;
