import React, { useEffect, useState } from 'react'
import Header from '../components/Header';
import TestForm from '../components/TestForm';
import {getRoom} from '../http/questAPI'

const Room = () => {
    
    const [idQues, setIdQues] = useState(0)
    const [dataRoom, setDataRoom] = useState({})
    const [loading, setLoading] = useState(true)
    
    useEffect(() => {
        getRoom().then(data => {
            
            console.log(data)

        }).finally(() => setLoading(false))

    }, []);

    // async function test () {
    //     let responce = await fetch(
    //         'https://localhost:7201/questions/1',

    //         {
    //             method: 'get',
    //         }
    //     )
    //     // ).then(( res ) => res.json()).then((resJson) => {console.log(resJson)}) 

    //     let responceJson = await responce.json()

    //     console.log(responceJson)
    // }

    // test()

    // useEffect(() => {
        
    // }, [idQues])

    if (loading) {
        return <div>Загрузка...</div>
    }

    return (
        <>
            <Header />

            Комната пустая
        </>
    );
}
  
export default Room;
  