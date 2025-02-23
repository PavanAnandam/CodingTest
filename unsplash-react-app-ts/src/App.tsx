import React, { useState } from 'react';
import { createRoot } from 'react-dom/client';
import { Input } from '@/components/ui/input';
import { Button } from '@/components/ui/button';
import { Card, CardContent } from '@/components/ui/card';
import { motion } from 'framer-motion';
import { useUnsplash } from 'unsplash-react';

const topics = ['Travel', 'Cars', 'Wildlife', 'Technology', 'Other'];

function App() {
    const [step, setStep] = useState(1);
    const [formData, setFormData] = useState({ name: '', surname: '', topic: '', customTopic: '' });
    const [imageUrl, setImageUrl] = useState('');
    const { searchPhotos } = useUnsplash({ accessKey: 'iUUngfb7gDXMfDVIyBEv8rYWf9GU-mGch9iZG7_7WOY' });

    const handleChange = (e) => {
        const { name, value } = e.target;
        setFormData({ ...formData, [name]: value });
    };

    const fetchImage = async () => {
        const query = formData.topic === 'Other' ? formData.customTopic : formData.topic;
        const response = await searchPhotos({ query, perPage: 1 });
        if (response && response.results.length) {
            setImageUrl(response.results[0].urls.regular);
            setStep(2);
        }
    };

    const handleAccept = () => {
        setStep(3);
    };

    const handleReject = () => {
        fetchImage();
    };

    return (
        <div className="min-h-screen flex items-center justify-center p-4 bg-gray-100">
            {step === 1 && (
                <Card className="w-full max-w-md p-4">
                    <CardContent>
                        <h1 className="text-xl font-bold mb-4">Enter Your Details</h1>
                        <Input name="name" placeholder="Name" onChange={handleChange} className="mb-2" />
                        <Input name="surname" placeholder="Surname" onChange={handleChange} className="mb-2" />
                        <select name="topic" onChange={handleChange} className="mb-2 w-full p-2 rounded">
                            <option value="">Select Topic</option>
                            {topics.map((topic) => (
                                <option key={topic} value={topic}>{topic}</option>
                            ))}
                        </select>
                        {formData.topic === 'Other' && (
                            <Input name="customTopic" placeholder="Enter custom topic" onChange={handleChange} className="mb-2" />
                        )}
                        <Button onClick={fetchImage} className="w-full">Submit</Button>
                    </CardContent>
                </Card>
            )}

            {step === 2 && (
                <motion.div className="text-center" initial={{ opacity: 0 }} animate={{ opacity: 1 }}>
                    <img src={imageUrl} alt="Topic" className="rounded-lg shadow-lg mb-4" />
                    <div className="flex justify-center gap-4">
                        <Button onClick={handleAccept}>Accept</Button>
                        <Button variant="outline" onClick={handleReject}>Reject</Button>
                    </div>
                </motion.div>
            )}

            {step === 3 && (
                <Card className="w-full max-w-sm p-4 text-center">
                    <CardContent>
                        <h2 className="text-xl font-bold mb-4">Your Information</h2>
                        <p>Name: {formData.name}</p>
                        <p>Surname: {formData.surname}</p>
                        <img src={imageUrl} alt="Thumbnail" className="mt-4 rounded-lg shadow-md w-32 h-32 object-cover mx-auto" />
                    </CardContent>
                </Card>
            )}
        </div>
    );
}

const container = document.getElementById('root');
const root = createRoot(container);
root.render(<App />);
