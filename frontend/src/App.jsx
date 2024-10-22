import React from "react";
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import HomeBook from './Pages/BookHome'; // Página principal de libros
import BookDetail from './components/BookDetail'; // Detalle del libro
import BookCreate from './Pages/BookCreate';
import BookUpdate from './Pages/BookUpdate'; // Página para actualizar un libro

function App() {
    return (
        <Router>
            <Routes>
                <Route path="/" element={<HomeBook />} /> {/* Página principal que lista todos los libros */}
                <Route path="/books/:id" element={<BookDetail />} /> {/* Detalle de un libro */}
                <Route path="/create-book" element={<BookCreate />} /> {/* Página para crear un nuevo libro */}
                <Route path="/update-book/:id" element={<BookUpdate />} /> {/* Página para actualizar un libro */}
            </Routes>
        </Router>
    );
}

export default App;
