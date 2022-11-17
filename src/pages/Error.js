import React, { useEffect, useState } from 'react'

import errorLogo from './../img/elements/error.svg'

const Error = () => {

    return (
        <>
            <section className='error'>
                <img className='error-img' src={errorLogo} />
                <div className='error-text'>
                    Страница недоступна либо вы не авторизовались. Перейдите на страницу регистрации или входа
                </div>
            </section>
        </>
    );
}
  
export default Error;
  