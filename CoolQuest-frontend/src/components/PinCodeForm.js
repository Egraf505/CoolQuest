import React, { useEffect } from 'react'


const PinCodeForm = () => {

    useEffect(() => {

        const allNumbers = document.body.querySelectorAll('.pincodeBlock_items_number')
        const code = document.body.querySelector('.pincodeBlock_answer')

        allNumbers.forEach(el => {
            el.addEventListener('click', (e) => {
                const value = e.target.value

                let codeV = code.value.split('_')[0]

                if (codeV.length < 4)
                    code.value = codeV + value + '_'.repeat(3 - code.value.split('').filter(i => i !== '_').length)
            })
        })

        const pinClear = document.getElementById('pin-item-clear')
        pinClear.addEventListener('click', () => code.value = '')

    }, [])

    return (
        <section className='pincode'>
            <div className='container-mini'>

                <div className='questionNumber'>Вопрос №5</div>

                <div className='question'>
                    В каком году родился автор произведения «Герой нашего времени»?
                </div>

                <div className='pincodeBlock'>

                    <input 
                        type='text' 
                        className='pincodeBlock_answer'
                        value=''
                        maxLength='4'
                        placeholder='____'
                        disabled
                    />

                    <div className='pincodeBlock_items'>
                        <button className='pincodeBlock_items_number' value='1'>1</button>
                        <button className='pincodeBlock_items_number' value='2'>2</button>
                        <button className='pincodeBlock_items_number' value='3'>3</button>
                        <button className='pincodeBlock_items_number' value='4'>4</button>
                        <button className='pincodeBlock_items_number' value='5'>5</button>
                        <button className='pincodeBlock_items_number' value='6'>6</button>
                        <button className='pincodeBlock_items_number' value='7'>7</button>
                        <button className='pincodeBlock_items_number' value='8'>8</button>
                        <button className='pincodeBlock_items_number' value='9'>9</button>
                        <button className='pincodeBlock_items_number' id='pin-item-clear'>X</button>
                        <button className='pincodeBlock_items_number' value='0'>0</button>
                        <button className='pincodeBlock_items_number'>ok</button>
                    </div>

                </div>
            </div>
        </section>
    );
  }
  
export default PinCodeForm;
  