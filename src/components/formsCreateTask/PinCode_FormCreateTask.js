import React from 'react'


const PinCode_FormCreateTask = () => {

    return (
        <div className='block_form_input'>
            <h3>Правильная комбинация</h3>

            <div className='createTask_form_pincode'>
                <input 
                    className='createTask_form_pincode_input'
                    type='text'
                    maxLength='4'
                    placeholder='_ _ _ _'
                />
            </div>

        </div>
    );
  }
  
export default PinCode_FormCreateTask;
  