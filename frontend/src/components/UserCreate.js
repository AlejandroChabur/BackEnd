import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import { createUser } from '../Service/UserService.js'; // Servicio para crear un usuario

const CreateUserForm = () => {
    const [idPerson, setIdPerson] = useState(''); // ID de la persona
    const [name, setName] = useState('');
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');
    const [phoneNumber, setPhoneNumber] = useState(''); // Número de teléfono
    const [userCode, setUserCode] = useState(''); // Código de usuario
    const [idUserType, setIdUserType] = useState(1); // ID del tipo de usuario
    const [error, setError] = useState('');
    const navigate = useNavigate();

    const handleSubmit = async (e) => {
        e.preventDefault();
        try {
            const newUser = {
                idPerson: parseInt(idPerson, 10), // Asegúrate de convertir a número
                name,
                email,
                password,
                phoneNumber,
                userCode,
                idUserType: parseInt(idUserType, 10), // Convierte a número
                isDelete: false,
            };
            console.log("Enviando nuevo usuario:", newUser); // Para depuración
            await createUser(newUser);
            navigate('/login');
        } catch (err) {
            console.error("Error al crear el usuario:", err.response.data); // Registrar el error detallado
            setError('Error al crear el usuario: ' + err.response.data.message); // Mensaje de error claro
        }
    };

    return (
        <div>
            <h2>Crear Nuevo Usuario</h2>
            <form onSubmit={handleSubmit}>
                <div>
                    <label>ID Persona:</label>
                    <input
                        type="number"
                        value={idPerson}
                        onChange={(e) => setIdPerson(e.target.value)}
                        required
                    />
                </div>
                <div>
                    <label>Nombre:</label>
                    <input
                        type="text"
                        value={name}
                        onChange={(e) => setName(e.target.value)}
                        required
                    />
                </div>
                <div>
                    <label>Email:</label>
                    <input
                        type="email"
                        value={email}
                        onChange={(e) => setEmail(e.target.value)}
                        required
                    />
                </div>
                <div>
                    <label>Contraseña:</label>
                    <input
                        type="password"
                        value={password}
                        onChange={(e) => setPassword(e.target.value)}
                        required
                    />
                </div>
                <div>
                    <label>Número de Teléfono:</label>
                    <input
                        type="text"
                        value={phoneNumber}
                        onChange={(e) => setPhoneNumber(e.target.value)}
                        required
                    />
                </div>
                <div>
                    <label>Código de Usuario:</label>
                    <input
                        type="text"
                        value={userCode}
                        onChange={(e) => setUserCode(e.target.value)}
                        required
                    />
                </div>
                <div>
                    <label>ID Tipo de Usuario:</label>
                    <input
                        type="number"
                        value={idUserType}
                        onChange={(e) => setIdUserType(e.target.value)}
                        required
                    />
                </div>
                {error && <p style={{ color: 'red' }}>{error}</p>}
                <button type="submit">Crear Usuario</button>
            </form>
        </div>
    );
};

export default CreateUserForm;
