import React, { useEffect, useState } from 'react'
import { useParams } from 'react-router-dom';
import {getRoom, postQues} from '../http/questAPI'

import { useLocation } from 'react-router-dom'
import Test from './Test';
import PinCode from './PinCode';


const Room = () => {

    let { id } = useParams(); 

    // const location = useLocation()
    // console.log(location.search)

    const [nameRoom, setNameRoom] = useState('Начальная')
    const [title, setTitle] = useState('')
    const [type, setType] = useState('test')
    const [answers, setAnswers] = useState([]) // him id

    const [loading, setLoading] = useState(true)
    
    useEffect(() => {

        getRoom(id).then(data => {

            console.log(data)
            const newId = data.answerFalses[data.answerFalses.length - 1].id + 1

            setNameRoom(data.question.room.title)
            setTitle(data.question.title)
            setType(data.question.type.title)
            setAnswers([...data.answerFalses.map(i => { return {id: i.id,title: i.title, ok: false}}), {id: newId, title: data.question.answer, ok: true}])

        }).finally(() => setLoading(false))

    }, []);

    const sendAnswer = (value) => {
        postQues()
    }

    if (loading) {
        return <div>Загрузка...</div>
    }

    return (
        <>
            <div className='nameRoom'>Комната «{nameRoom}»</div>
            {
                type == 'Test'
                ?
                <Test
                    id={id}
                    textQuestion={title}
                    answers={answers}
                    sendAnswer={sendAnswer}
                />
                :
                <PinCode />
            }
        </>
    );
}
  
export default Room;
  