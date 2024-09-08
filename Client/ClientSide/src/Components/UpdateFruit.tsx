import React, { useState } from 'react';
import { Api, Fruit } from '../Api'; // Adjust the import path as necessary

const UpdateFruit: React.FC = () => {
    const [id, setId] = useState<number | undefined>(undefined);
    const [name, setName] = useState('');
    const [price, setPrice] = useState<number | undefined>(undefined);
    const [message, setMessage] = useState<string | null>(null);
    const api = new Api();

    const handleSubmit = async (event: React.FormEvent) => {
        event.preventDefault();
        if (id === undefined) {
            setMessage('Please provide a valid ID.');
            return;
        }
        const updatedFruit: Fruit = { name, price };

        try {
            await api.api.fruitUpdate(id, updatedFruit);
            setMessage('Fruit updated successfully!');
        } catch (error) {
            console.error('Error updating fruit:', error);
            setMessage('Failed to update fruit.');
        }
    };

    return (
        <div>
            <h1>Update Fruit</h1>
            <form onSubmit={handleSubmit}>
                <div>
                    <label htmlFor="id">ID:</label>
                    <input
                        type="number"
                        id="id"
                        value={id}
                        onChange={(e) => setId(Number(e.target.value))}
                        required
                    />
                </div>
                <div>
                    <label htmlFor="name">Name:</label>
                    <input
                        type="text"
                        id="name"
                        value={name}
                        onChange={(e) => setName(e.target.value)}
                        required
                    />
                </div>
                <div>
                    <label htmlFor="price">Price:</label>
                    <input
                        type="number"
                        id="price"
                        value={price}
                        onChange={(e) => setPrice(Number(e.target.value))}
                        required
                    />
                </div>
                <button type="submit">Update Fruit</button>
            </form>
            {message && <p>{message}</p>}
        </div>
    );
};

export default UpdateFruit;