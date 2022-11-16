import React, { useEffect, useState } from 'react'
import Header from '../components/Header';
import TestForm from '../components/TestForm';
import Way from '../components/Way';
import {getRoom} from '../http/questAPI'

const Test = () => {
    
    const [loading, setLoading] = useState(true)
    
    useEffect(() => {
        getRoom(1).then(data => {
            console.log(data)
        }).finally(() => setLoading(false))
    }, []);

    if (loading) {
        return <div>Загрузка...</div>
    }

    return (
        <>
            <Header />
            <TestForm />
            {/* <Way /> */}
        </>
    );
}
  
export default Test;
  