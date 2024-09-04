import React, { useEffect, useState } from 'react';
import {Api, Fruit} from '../Api'; // Adjust the import path as necessary

const GetAllFruits: React.FC = () => {
    const [fruits, setFruits] = useState<Fruit[]>([]);
    const api = new Api();

    useEffect(() => {
        const fetchFruits = async () => {
            try {
                const response = await api.api.fruitGetAll();
                setFruits(response.data);
            } catch (error) {
                console.error('Error fetching fruits:', error);
            }
        };

        fetchFruits();
    }, []);

    return (
        <div>
            <h1>All Fruits</h1>
            <ul>
                {fruits.map((fruit) => (
                    <li key={fruit.id}>{fruit.name}</li>
                ))}
            </ul>
        </div>
    );
};

export default GetAllFruits;