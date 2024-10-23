import React from "react";
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import HomeBook from './Pages/BookHome'; // P�gina principal de libros
import BookDetail from './components/BookDetail'; // Detalle del libro
import BookCreate from './Pages/BookCreate';
import BookUpdate from './Pages/BookUpdate'; // P�gina para actualizar un libro
import LoginPage from './components/Login';
import DashboardPage from './Pages/DashBoardPage';
import UserCreate from './components/UserCreate';
import UserHome from './Pages/UserHome';
import UserDetail from './components/UserDetail';
import UserUpdate from './Pages/UserUpdate';

function App() {
    return (
        <Router>
            <Routes>
                <Route path="/" element={<LoginPage />} />s
                <Route path="/dashboard" element={<DashboardPage />} />
                <Route path="/users" element={<UserHome />} />
                <Route path="/create-user" element={<UserCreate />} />
                <Route path="/users/:id" element={<UserDetail />} />
                <Route path="/update-user/:id" element={<UserUpdate />} /> 
                <Route path="books/" element={<HomeBook />} /> {/* P�gina principal que lista todos los libros */}
                <Route path="/books/:id" element={<BookDetail />} /> {/* Detalle de un libro */}
                <Route path="/create-book" element={<BookCreate />} /> {/* P�gina para crear un nuevo libro */}
                <Route path="/update-book/:id" element={<BookUpdate />} /> {/* P�gina para actualizar un libro */}
            </Routes>
        </Router>
    );
}

export default App;
