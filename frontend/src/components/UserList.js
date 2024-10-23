import React, { useEffect, useState } from 'react';
import { GetAllUsers, DeleteUser } from '../Service/UserService.js'; // Aseg�rate de tener estas funciones
import { Link, useNavigate } from 'react-router-dom';

const UserList = () => {
    const [users, setUsers] = useState([]);
    const navigate = useNavigate();

    useEffect(() => {
        const fetchUsers = async () => {
            try {
                const data = await GetAllUsers();
                console.log("Datos de la API de usuarios:", data); // Imprime los datos para ver la estructura
                setUsers(data); // Aqu� se asigna directamente el array de usuarios
            } catch (error) {
                console.error("Error fetching users:", error);
            }
        };
        fetchUsers();
    }, []);

    const handleDelete = async (id) => {
        const confirmDelete = window.confirm("�Est�s seguro de que deseas eliminar este usuario?");
        if (confirmDelete) {
            const result = await DeleteUser(id);
            if (result) {
                setUsers(users.filter(user => user.userId !== id)); // Filtrar por userId
            } else {
                alert("Error al eliminar el usuario");
            }
        }
    };

    const handleEdit = (id) => {
        navigate(`/update-user/${id}`);
    };

    return (
        <div>
            <h2>Lista de Usuarios</h2>
            <button onClick={() => navigate('/create-user')}>Agregar Usuario</button>
            <ul>
                {users.map(user => (
                    <li key={user.userId}>
                        <Link to={`/users/${user.Id}`}>{user.name}</Link> {/* Enlace al detalle del usuario */}
                        <button onClick={() => handleEdit(user.userId)}>Actualizar</button>
                        <button onClick={() => handleDelete(user.userId)}>Eliminar</button>
                    </li>
                ))}
            </ul>
        </div>
    );
};

export default UserList;