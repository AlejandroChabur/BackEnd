import React from 'react';
import CreateBookForm from '../components/BookCreate.js'; // Asegúrate de tener el componente CreateBookForm

const CreateBookPage = () => {
    return (
        <div>
            <h1>Crear Nuevo Libro</h1>
            <CreateBookForm /> {/* Componente del formulario para crear libros */}
        </div>
    );
};

export default CreateBookPage;
