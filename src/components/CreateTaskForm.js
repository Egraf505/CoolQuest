import React, { useEffect, useState } from 'react'
import Answers_FormCreateTask from './formsCreateTask/Answers_FormCreateTask';
import PinCode_FormCreateTask from './formsCreateTask/PinCode_FormCreateTask';


const CreateTaskForm = () => {

    const [isAnswers, setIsAnswers] = useState(true)
    const [isPinCode, setIsPinCode] = useState(false)

    useEffect(() => {
        const testBlock = document.getElementById('option-test')
        const pincodeBlock = document.getElementById('option-pincode')

        testBlock.addEventListener('click', () => {
            setIsAnswers(true)
            setIsPinCode(false)
        })

        pincodeBlock.addEventListener('click', () => {
            setIsPinCode(true)
            setIsAnswers(false)
        })

    }, [])

    return (
        <section className='createTask'>
            <div className='title'>Добавление вопроса</div>
            <div method='POST' className='createTask_form'>
                
                <div className='block_form_input'>
                    <h3>Тип вопроса</h3>
                    <div className='createTask_form_option'>
                        <button className={`button ${isAnswers && 'primary'}`} id='option-test'>Тест</button>
                        <button className={`button ${isPinCode && 'primary'}`} id='option-pincode'>Пин-код</button>
                    </div>
                </div>

                <div className='block_form_input'>
                    <h3>Номер вопроса</h3>
                    <input
                        className='form_input'
                        type='text'
                        placeholder='Например, вопрос №5'
                    />
                </div>

                <div className='block_form_input'>
                    <h3>Текст вопроса</h3>
                    <textarea
                        className='form_input'
                        type='text'
                        placeholder='Например, длина реки Нил? Почему нет?'
                    />
                </div>

                {isAnswers 
                &&
                <Answers_FormCreateTask />
                }

                {isPinCode 
                &&
                <PinCode_FormCreateTask />
                }
                
                <div className='block_form_input'>
                    <h3>Загрузить изображение</h3>

                    <div className='createTask_form_fotoLoad'>
                        <input 
                            className='createTask_form_fotoLoad-fileReal' 
                            accept='.jpg' 
                            id='fotoLoad-1' 
                            type='file' 
                        />
                        <label className='createTask_form_fotoLoad-fileFalse' htmlFor='fotoLoad-1'>
                            Выбрать
                        </label>
                    </div>
                </div>

                <div className='block_form_input'>
                    <h3>Подтвердите добавление</h3>

                    <div className='createTask_button-add button primary'>Добавить вопрос</div>
                </div>
            </div>
        </section>
    );
  }
  
export default CreateTaskForm;
  