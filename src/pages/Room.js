import React, { useEffect, useState } from 'react'
import { useParams } from 'react-router-dom';
import {getRoom, postQuest} from '../http/questAPI'

import { useHistory } from 'react-router-dom'
import Test from './Test';
import PinCode from './PinCode';
import ResultWindow from '../components/ResultWindows';
import Error from './Error';


const Room = () => {

    let { id } = useParams(); 

    const history = useHistory()

    const [question, setQuestion] = useState({})
    const [nameRoom, setNameRoom] = useState('Начальная')
    const [title, setTitle] = useState('')
    const [type, setType] = useState('test')
    const [answers, setAnswers] = useState([]) // him id
    const [activeWindow, setActiveWindow] = useState(false) // check true/false in answer
    const [ok, setOk] = useState(false) // check true/false in answer

    const [loading, setLoading] = useState(true)
    
    useEffect(() => {

        getRoom(id).then(data => {
            
            const newId = data.answerFalses[data.answerFalses.length - 1].id + 1

            setQuestion(data)

            setNameRoom(data.question.room.title)
            setTitle(data.question.title)
            setType(data.question.type.title)
            setAnswers([...data.answerFalses.map(i => { return {id: i.id,title: i.title, ok: false}}), {id: newId, title: data.question.answer, ok: true}])

        })
        .catch(e => {
            const urlOld = history.location.pathname
            history.push({
                pathname: '/login',
                search: '?url=' + urlOld,
            })
        })
        .finally(() => setLoading(false))

    }, []);

    const sendAnswer = (value) => {
        setActiveWindow(true)
        setOk(value)
        if (value) {
            postQuest(localStorage.setItem('userId'), question.question.roomId, question.question.id)
        }
    }

    const logOut = () => {
        localStorage.removeItem('token')
        localStorage.removeItem('userId')
    }

    const close = () => {
        setActiveWindow(false)
    }

    if (loading) {
        return <div>Загрузка...</div>
    }

    return (
        <>
            <form>
                <button className='logOut' onClick={() => logOut()}>Выйти из аккаунта</button>
            </form>
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
            {
                activeWindow && 
                <ResultWindow
                    close={close}
                    ok={ok}
                />
            }
        </>
    );
}
  
export default Room;
  