import React, { useState, useEffect } from 'react';
import 'bootstrap/dist/css/bootstrap.min.css';
import { login } from './services/auth.api.service'
import { getUsers, saveUser, deleteUsers, editUser } from './services/user.api.service'

function App() {
  const [token, setToken] = useState(null);
  const [error, setError] = useState(null);
  const [userData, setUserData] = useState([]);
  const [newUser, setNewUser] = useState({
    id:'',
    name: '',
    email: '',
    age: 0,
    nationality: '',
  });
  const [userLogin, setUserLogin] = useState({
    email: '',
    password: '',
  });
  const [formErrors, setFormErrors] = useState({
    name: '',
    email: '',
  });

  const handleSession = async () => {
    const tokenSession = sessionStorage.getItem('SessionToken') ?? '';
    console.log(tokenSession);

    if(tokenSession !== '') {
      setToken(tokenSession);
      setError(null);
    } else {
      setError('Debe iniciar sesion.');
    }
    
  }

  const handleLogOut = async () => {
    sessionStorage.setItem('SessionToken', '');
    setToken(null);
    setError('Debe iniciar sesion.');
  }

  const handleLogin = async () => {
    // Validar campos requeridos
    if (!userLogin.email || !userLogin.password) {
      setFormErrors({
        name: userLogin.password ? '' : 'El password es requerido.',
        email: userLogin.email ? '' : 'El correo electrónico es requerido.',
      });
      return;
    }

    // Validar formato de correo electrónico
    const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    if (!emailRegex.test(userLogin.email)) {
      setFormErrors({
        ...formErrors,
        email: 'El formato del correo electrónico no es válido.',
      });
      return;
    }


    try {
      // const authToken = await login("gustavoamoreno@outlook.com", "0123456789");
      const authToken = await login(userLogin.email, userLogin.password);
      
      setToken(authToken);
      handleClearForms();
      setError(null);
      sessionStorage.setItem('SessionToken', authToken);
    } catch (error) {
      setError('A ocurrido un error al iniciar sesion. Los datos de sesión enviados son invalidos');
      console.error('Error al iniciar sesión:', error.message);
    }
  };

  const handleDeleteUser = async (userId) => {
    try {
      const result = await deleteUsers(token, userId);
      console.log(result);
      window.location.reload();
    }catch (error) {
      setError('A ocurrido un error al eliminar usuario.');
      console.error('Error al iniciar sesión:', error.message);
    }
  };

  const handleEditarUsuario = async (user) => {
    setNewUser(user);
  };

  const fetchUserData = async () => {
    try {
      const users = await getUsers(token);
      setUserData(users);
    } catch (error) {
      console.error('Error al obtener datos de usuario:', error.message);
    }
  };

  const handleCreateUser = async () => {
    // Validar campos requeridos
    if (!newUser.name || !newUser.email) {
      setFormErrors({
        name: newUser.name ? '' : 'El nombre es requerido.',
        email: newUser.email ? '' : 'El correo electrónico es requerido.',
      });
      return;
    }

    // Validar formato de correo electrónico
    const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    if (!emailRegex.test(newUser.email)) {
      setFormErrors({
        ...formErrors,
        email: 'El formato del correo electrónico no es válido.',
      });
      return;
    }

    try {
      if(newUser.id && newUser.id !== ''){
        await editUser(token, newUser);
      } else {
        await saveUser(token, newUser);
      }
      handleClearForms();

      // Recargar los datos después de la creación del usuario
      window.location.reload();
    } catch (error) {
      console.error('Error al crear usuario:', error.message);
    }
  };

  const handleClearForms = async () => {
    // Limpiar el formulario después de la creación exitosa
    setNewUser({
      id: '',
      name: '',
      email: '',
      age: 0,
      nationality: '',
    });
    // Limpiar los mensajes de error
    setFormErrors({
      name: '',
      email: '',
    });
  }

  useEffect(() => {
    handleSession();
  }, []);

  useEffect(() => {
    if (token) {
      fetchUserData();
    }
  }, [token]);

  return (
    <div className="container mt-5">
      {error && (
        <div>
          
        <div className="alert alert-danger text-break" role="alert">
          {error}
        </div>
        <hr/>
        
        <div className="row">
          <div className="col-md-12 text-center">
            <h2>Inicio de sesión:</h2>
          </div>
        </div>

        <form>
          <div className="row">
            <div className="col-md-4 offset-md-4">
              <label htmlFor="email" className="form-label">Email:</label>
              <input
                type="text"
                className={`form-control ${formErrors.email ? 'is-invalid' : ''}`}
                id="email"
                value={userLogin.email}
                onChange={(e) => setUserLogin({ ...userLogin, email: e.target.value })}
              />
              {formErrors.email && <div className="invalid-feedback">{formErrors.email}</div>}
            </div>
          </div>
          <div className="row">
            <div className="col-md-4 offset-md-4 mt-4">
              <label htmlFor="password" className="form-label">Password:</label>
              <input
                type="password"
                className={`form-control ${formErrors.name ? 'is-invalid' : ''}`}
                id="password"
                value={userLogin.password}
                onChange={(e) => setUserLogin({ ...userLogin, password: e.target.value })}
              />
              {formErrors.name && <div className="invalid-feedback">{formErrors.name}</div>}
            </div>
          </div>
          <div className="row">
            <div className="col-md-4 offset-md-4 mt-4 text-center">
              <button type="button" className="btn btn-success" onClick={handleLogin}>
                Iniciar sesión
              </button>
            </div>
          </div>
        </form>
        </div>
      )}
      {token && (
        <div>
          <h2>Datos de Usuario:</h2>
          <table className="table table-bordered table-hover">
            <thead>
              <tr>
                <td>Nombre</td>
                <td>Correo Electrónico</td>
                <td>Edad</td>
                <td>Nacionalidad</td>
                <td width='160px'>Acciones</td>
              </tr>
            </thead>
            <tbody>
              {
                userData.map(user => 
                 <tr>
                  <td> {user.name} </td>
                  <td> {user.email} </td>
                  <td> {user.age} </td>
                  <td> {user.nationality} </td>
                  <td width='160px'> 
                    <div className="row">
                      <div className="col-md-6">
                        <button type="button" className="btn btn-danger btn-sm" onClick={() => {handleDeleteUser(user.id);}}>
                          Eliinar
                        </button>
                      </div>
                      <div className="col-md-6">
                        <button type="button" className="btn btn-primary btn-sm" onClick={() => {handleEditarUsuario(user);}}>
                          Editar
                        </button>
                      </div>
                    </div>
                  </td>
                 </tr> 
                )
              }
              <tr>

              </tr>
            </tbody>
          </table>

          <h2>Crear Nuevo Usuario:</h2>
          <form>
            <div className="mb-3">
              <label htmlFor="name" className="form-label">Nombre:</label>
              <input type='hidden' name='id' id='id' value={newUser.id}></input>
              <input
                type="text"
                className={`form-control ${formErrors.name ? 'is-invalid' : ''}`}
                id="name"
                value={newUser.name}
                onChange={(e) => setNewUser({ ...newUser, name: e.target.value })}
              />
              {formErrors.name && <div className="invalid-feedback">{formErrors.name}</div>}
            </div>
            <div className="mb-3">
              <label htmlFor="email" className="form-label">Correo Electrónico:</label>
              <input
                type="email"
                className={`form-control ${formErrors.email ? 'is-invalid' : ''}`}
                id="email"
                value={newUser.email}
                onChange={(e) => setNewUser({ ...newUser, email: e.target.value })}
                required
              />
              {formErrors.email && <div className="invalid-feedback">{formErrors.email}</div>}
            </div>
            <div className="mb-3">
              <label htmlFor="age" className="form-label">Edad:</label>
              <input
                type="number"
                className="form-control"
                id="age"
                value={newUser.age}
                onChange={(e) => setNewUser({ ...newUser, age: parseInt(e.target.value, 10) })}
              />
            </div>
            <div className="mb-3">
              <label htmlFor="nationality" className="form-label">Nacionalidad:</label>
              <input
                type="text"
                className="form-control"
                id="nationality"
                value={newUser.nationality}
                onChange={(e) => setNewUser({ ...newUser, nationality: e.target.value })}
              />
            </div>
            <div className="row">
              <div className="col-md-6">
                <button type="button" className="btn btn-success" onClick={handleCreateUser}>
                  Crear Usuario
                </button>
              </div>
              <div className="col-md-6">
                <button type="button" className="btn btn-warning" onClick={handleLogOut}>
                  Cerrar sesión
                </button>
              </div>
            </div>
            
          </form>
        </div>
      )}
    </div>
  );
}

export default App;
