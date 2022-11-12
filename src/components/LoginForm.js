import React from 'react'


const LoginForm = () => {
    return (
        <section className='login'>
            <div className='title'>Войти</div>
            <form method='POST' className='login_form'>

                <div className='block_form_input'>
                    <h3>Введите логин:</h3>
                    <input
                        className='form_input'
                        type='text'
                    />
                </div>

                <div className='block_form_input'>
                    <h3>Введите пароль:</h3>
                    <input
                        className='form_input'
                        type='password'
                    />
                </div>

                <div className='login_form_buttons'>
                    <button className='button primary'>Войти</button>
                    <button className='button'>Регистрация</button>
                </div>
            </form>
        </section>
    );
  }
  
export default LoginForm;
  