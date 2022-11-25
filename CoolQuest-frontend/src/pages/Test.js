import React, { useEffect, useState } from 'react'

import testImg from './../img/test-img.jpg'

const Test = ({id, textQuestion, answers, sendAnswer}) => {
    
    // const [isVideo, setIsVideo] = useState(false)

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

                {/* {isVideo
                ?
                <iframe className='test_video' width="1280" height="720" src="https://www.youtube.com/embed/sYiv9UEa4pI" title="Посмотрите видео" frameBorder="0" allow="accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture" allowFullScreen></iframe>
                :
                <img 
                className='test_img'
                src={testImg}
                alt='foto'
                />
                } */}

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
  