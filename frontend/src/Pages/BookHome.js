import React from 'react';
import BookList from '../components/BookList.js'; // Asegúrate de tener este componente

const HomeBook = () => {
    return (
        <div>
            <h1>Libros</h1>
            <BookList /> {/* Componente que muestra la lista de libros */}
        </div>
    );
};

export default HomeBook;
