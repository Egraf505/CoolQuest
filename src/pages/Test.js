import React, { useEffect, useState } from 'react'

import testImg from './../img/test-img.jpg'

const Test = ({id, textQuestion, answers, sendAnswer}) => {
    
    const [allAnswers, setAllAnswers] = useState([])

    useEffect(() => {
        
        for (let i = answers.length - 1; i > 0;  i--){
            let j = Math.floor(Math.random() * (i + 1));
            [answers[i], answers[j]] = [answers[j], answers[i]];
        }

        setAllAnswers(answers)

    }, [])

    return (
        <section className='test'>
            <div className='container-mini'>
                <div className='questionNumber'>Вопрос №{id}</div>

                <img 
                    className='test_img'
                    src={testImg}
                    alt='foto'
                />

                <div className='question'>
                    {textQuestion}
                </div>

                <div className='test_form'>
                    <div className='test_form_answers'>

                        {
                            allAnswers.map((item) => 
                                <button 
                                    id={`answer-${item.id}`}
                                    className='test_form_answers_one' 
                                    key={item.title}
                                    onClick={e => {sendAnswer(answers.filter(ans => ans.id == e.target.id.split('-')[1])[0].ok)}}
                                >
                                {item.title}
                                </button>
                            )
                        }

                    </div>
                </div>
            </div>

        </section>
    );
}
  
export default Test;
  