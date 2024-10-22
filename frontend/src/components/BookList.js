import React, { useEffect, useState } from 'react';
import { GetAllBooks, DeleteBook } from '../Service/BookService.js'; // Aseg�rate de tener estos servicios
import { Link, useNavigate } from 'react-router-dom';

const BookList = () => {
    const [books, setBooks] = useState([]); // Estado para almacenar la lista de libros
    const navigate = useNavigate(); // Para redirigir a otras p�ginas

    useEffect(() => {
        const fetchBooks = async () => {
            try {
                const data = await GetAllBooks(); // Llamada al servicio para obtener todos los libros
                console.log("Datos de la API:", data); // Imprime los datos para ver la estructura
                setBooks(data); // Asigna el array de libros al estado
            } catch (error) {
                console.error("Error fetching books:", error);
            }
        };
        fetchBooks(); // Llamada a la funci�n para obtener los libros
    }, []); // Se ejecuta al montar el componente

    const handleDelete = async (id) => {
        const confirmDelete = window.confirm("�Est�s seguro de que deseas eliminar este libro?");
        if (confirmDelete) {
            const result = await DeleteBook(id); // Llamada al servicio para eliminar un libro
            if (result) {
                setBooks(books.filter(book => book.id !== id)); // Filtra la lista para remover el libro eliminado
            } else {
                alert("Error al eliminar el libro");
            }
        }
    };

    const handleEdit = (id) => {
        navigate(`/update-book/${id}`); // Redirige a la p�gina de actualizaci�n de libro
    };

    return (
        <div>
            <h2>Lista de Libros</h2>
            <button onClick={() => navigate('/create-book')}>Agregar Libro</button> {/* Bot�n para agregar nuevo libro */}
            <ul>
                {books.map(book => (
                    <li key={book.id}> {/* Usamos 'id' como clave, que es el identificador �nico */}
                        <Link to={`/books/${book.id}`}>{book.title}</Link> {/* Enlace al detalle del libro */}
                        <button onClick={() => handleEdit(book.id)}>Actualizar</button> {/* Bot�n para editar */}
                        <button onClick={() => handleDelete(book.id)}>Eliminar</button> {/* Bot�n para eliminar */}
                    </li>
                ))}
            </ul>
        </div>
    );
};

export default BookList;
