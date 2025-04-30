import React, { useState, useEffect } from 'react';
import axios from 'axios';
import './App.css';

const apiUrl = 'https://localhost:7047/api/todos'; 

function App() {
  const [todos, setTodos] = useState([]);
  const [title, setTitle] = useState('');
  const [description, setDescription] = useState('');
  const [isEditing, setIsEditing] = useState(false);
  const [currentTodo, setCurrentTodo] = useState(null);

  useEffect(() => {
    loadTodos();
  }, []);

  const loadTodos = async () => {
    try {
      const response = await axios.get(apiUrl);
      setTodos(response.data);
    } catch (error) {
      console.error('Error loading todos:', error);
    }
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    
    if (!title.trim() || !description.trim()) return;

    try {
      if (isEditing) {
        await axios.put(`${apiUrl}/${currentTodo.id}`, {
          title,
          description,
          isCompleted: currentTodo.isCompleted
        });
      } else {
        await axios.post(apiUrl, {
          title,
          description
        });
      }
      
      // Reset form
      setTitle('');
      setDescription('');
      setIsEditing(false);
      setCurrentTodo(null);
      
      // Reload todos
      loadTodos();
    } catch (error) {
      console.error('Error saving todo:', error);
    }
  };

  const handleDelete = async (id) => {
    try {
      await axios.delete(`${apiUrl}/${id}`);
      loadTodos();
    } catch (error) {
      console.error('Error deleting todo:', error);
    }
  };

  const handleEdit = (todo) => {
    setIsEditing(true);
    setCurrentTodo(todo);
    setTitle(todo.title);
    setDescription(todo.description);
  };

  const handleToggleComplete = async (todo) => {
    try {
      await axios.put(`${apiUrl}/${todo.id}`, {
        title: todo.title,
        description: todo.description,
        isCompleted: !todo.isCompleted
      });
      loadTodos();
    } catch (error) {
      console.error('Error updating todo:', error);
    }
  };

  return (
    <div className="App">
      <header className="App-header">
        <h1>Todo App</h1>
      </header>
      <main>
        <form onSubmit={handleSubmit} className="todo-form">
          <h2>{isEditing ? 'Edit Todo' : 'Add Todo'}</h2>
          <div className="form-group">
            <label htmlFor="title">Title:</label>
            <input
              type="text"
              id="title"
              value={title}
              onChange={(e) => setTitle(e.target.value)}
              required
            />
          </div>
          <div className="form-group">
            <label htmlFor="description">Description:</label>
            <textarea
              id="description"
              value={description}
              onChange={(e) => setDescription(e.target.value)}
              required
            />
          </div>
          <button type="submit" className="btn btn-primary">
            {isEditing ? 'Update' : 'Add'}
          </button>
          {isEditing && (
            <button
              type="button"
              className="btn btn-secondary"
              onClick={() => {
                setIsEditing(false);
                setCurrentTodo(null);
                setTitle('');
                setDescription('');
              }}
            >
              Cancel
            </button>
          )}
        </form>

        <div className="todo-list">
          <h2>Your Todos</h2>
          {todos.length === 0 ? (
            <p>No todos yet. Add some!</p>
          ) : (
            <ul>
              {todos.map((todo) => (
                <li key={todo.id} className={todo.isCompleted ? 'completed' : ''}>
                  <div className="todo-content">
                    <h3>{todo.title}</h3>
                    <p>{todo.description}</p>
                    <p className="date">Created: {new Date(todo.createdDate).toLocaleDateString()}</p>
                  </div>
                  <div className="todo-actions">
                    <button
                      className="btn btn-toggle"
                      onClick={() => handleToggleComplete(todo)}
                    >
                      {todo.isCompleted ? 'Mark Incomplete' : 'Mark Complete'}
                    </button>
                    <button
                      className="btn btn-edit"
                      onClick={() => handleEdit(todo)}
                    >
                      Edit
                    </button>
                    <button
                      className="btn btn-delete"
                      onClick={() => handleDelete(todo.id)}
                    >
                      Delete
                    </button>
                  </div>
                </li>
              ))}
            </ul>
          )}
        </div>
      </main>
    </div>
  );
}

export default App;