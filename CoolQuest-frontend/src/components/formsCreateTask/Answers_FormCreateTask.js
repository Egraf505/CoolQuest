import React from 'react'


const Answers_FormCreateTask = () => {

    return (
        <div className='block_form_input'>
            <h3>Варианты ответов</h3>

            <div className='createTask_form_answers'>

                <div className='createTask_form_answers_input'>
                    <input 
                        className='createTask_form_answers_input-checkReal'
                        type='checkbox'
                        id='createTask-check-1'
                    />
                    <label 
                        className='createTask_form_answers_input-checkFalse' 
                        htmlFor='createTask-check-1'
                    ></label>
                    <input 
                        className='createTask_form_answers_input-text'
                        type='text'
                    />
                </div>

                <div className='createTask_form_answers_input'>
                    <input 
                        className='createTask_form_answers_input-checkReal'
                        type='checkbox'
                        id='createTask-check-2'
                    />
                    <label 
                        className='createTask_form_answers_input-checkFalse' 
                        htmlFor='createTask-check-2'
                    ></label>
                    <input 
                        className='createTask_form_answers_input-text'
                        type='text'
                    />
                </div>

                <div className='createTask_form_answers_input'>
                    <input 
                        className='createTask_form_answers_input-checkReal'
                        type='checkbox'
                        id='createTask-check-3'
                    />
                    <label 
                        className='createTask_form_answers_input-checkFalse' 
                        htmlFor='createTask-check-3'
                    ></label>
                    <input 
                        className='createTask_form_answers_input-text'
                        type='text'
                    />
                </div>

                <div className='createTask_form_answers_input'>
                    <input 
                        className='createTask_form_answers_input-checkReal'
                        type='checkbox'
                        id='createTask-check-4'
                    />
                    <label 
                        className='createTask_form_answers_input-checkFalse' 
                        htmlFor='createTask-check-4'
                    ></label>
                    <input 
                        className='createTask_form_answers_input-text'
                        type='text'
                    />
                </div>

            </div>
        </div>
    );
  }
  
export default Answers_FormCreateTask;
  