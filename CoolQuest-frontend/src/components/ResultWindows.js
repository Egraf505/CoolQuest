import React from 'react'

import closeIcon from '../img/elements/close.svg'

const ResultWindow = ({close, ok}) => {

    return(
        <div className='resultWindow' onClick={()=> close()}>
            
            <div className='content_resultWindow' onClick={e => e.stopPropagation()}>
                
                <img onClick={()=> close()} src={closeIcon} className='icon_close_resultWindow'/>

                <div className='info_resultWindow'>

                    <div className='title_info_resultWindow'>{ ok ? 'Правильно!' : 'Подумай ещё'}</div>

                    <div className='text_info_resultWindow'>
                    { ok 
                    ?
                     'Ты дал правильный ответ. Так держать! Не останавливайся и ищи ещё подсказки.' 
                    :
                     'Неверный ответ. Поищи ещё подсказки, и возвращайся, когда будешь готов ответить КАК НАДО!'
                    }
                        
                    </div>

                </div>

            </div>

        </div>
    )
}

export default ResultWindow;