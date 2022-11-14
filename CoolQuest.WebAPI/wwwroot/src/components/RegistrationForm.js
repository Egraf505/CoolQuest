import React from 'react'


const RegistrationForm = () => {
    return (
        <section className='reg'>
            <div className='title'>Регистрация</div>
            <form method='POST' className='reg_form'>

                <div className='block_form_input'>
                    <h3>Ваше имя</h3>
                    <input
                        className='form_input'
                        type='text'
                        placeholder='Иван'
                    />
                </div>

                <div className='block_form_input'>
                    <h3>Ваша фамилия</h3>
                    <input
                        className='form_input'
                        type='text'
                        placeholder='Иванов'
                    />
                </div>

                <div className='block_form_input'>
                    <h3>Ваш E-mail</h3>
                    <input
                        className='form_input'
                        type='email'
                        placeholder='ivan@yandex.ru'
                    />
                </div>

                <div className='block_form_input'>
                    <h3>Пароль</h3>
                    <input
                        className='form_input'
                        type='password'
                    />
                </div>

                <div className='block_form_input'>
                    <h3>Повторите пароль</h3>
                    <input
                        className='form_input'
                        type='password'
                    />
                </div>

                <div className='reg_form_buttons'>
                    <button className='button primary'>Зарегистрироваться</button>
                    <button className='button'>Войти</button>
                </div>

            </form>
        </section>
    );
  }
  
export default RegistrationForm;
  