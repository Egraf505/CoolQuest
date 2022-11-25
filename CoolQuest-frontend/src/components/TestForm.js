import React from 'react'

import testImg from './../img/test-img.jpg'


const TestForm = () => {

    return (
        <section className='test'>
            <div className='container-mini'>
                <div className='questionNumber'>Вопрос №3</div>

                <img 
                    className='test_img'
                    src={testImg}
                    alt='foto'
                />

                <div className='question'>
                    Героем «Ревизора» НЕ является:
                </div>

                <div className='test_form'>
                        <div className='test_form_answers'>

                            <button className='test_form_answers_one'>
                                Хлестаков
                            </button>

                            <button className='test_form_answers_one'>
                                Чел с очень большим именем, которое может не поместиться...
                            </button>

                            <button className='test_form_answers_one'>
                                Лермонтов
                            </button>

                            <button className='test_form_answers_one'>
                                Бобчинский
                            </button>
                            
                        </div>
                </div>
            </div>

        </section>
    );
}
  
export default TestForm;
  