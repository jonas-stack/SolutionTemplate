import React, { useState } from 'react';
import { Api, Fruit } from '../Api'; // Adjust the import path as necessary

const CreateFruit: React.FC = () => {
    const [name, setName] = useState('');
    const [price, setPrice] = useState<number | undefined>(undefined);
    const [message, setMessage] = useState<string | null>(null);
    const api = new Api();

    const handleSubmit = async (event: React.FormEvent) => {
        event.preventDefault();
        const newFruit: Fruit = { name, price };

        try {
            await api.api.fruitAdd(newFruit);
            setMessage('Fruit added successfully!');
        } catch (error) {
            console.error('Error adding fruit:', error);
            setMessage('Failed to add fruit.');
        }
    };

    return (
        <div>
            <h1>Create Fruit</h1>
            <form onSubmit={handleSubmit}>
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
                <button type="submit">Add Fruit</button>
            </form>
            {message && <p>{message}</p>}
        </div>
    );
};

export default CreateFruit;