import React from 'react'
import { login } from '../http/authAPI'
import { useHistory } from 'react-router-dom'

export const loginning = async (
    history,
    urlNew,
    isLogin = document.getElementById("id-login").value,
    isPassword = document.getElementById("id-password").value,
    ) => {
        
    await login(isLogin, isPassword)
    .then((data) => {
        localStorage.setItem('token', data.access_token);
        localStorage.setItem('userId', data.id);

        if(urlNew){
            history.push(urlNew)
        }
    })
    .catch((e) => {
        console.log('Ошибка входа: возможно, такого пользователя не существует')
    })
}

const Login = () => {

    const history = useHistory()
    const urlNew = history.location.search.split('=')[1]

    const redirected = () => {
        history.push({
            pathname: '/registration',
            search: '?url=' + (urlNew || '/'),
        })
    }

    return (
        <section className='login'>
            <div className='title'>Войти</div>
            <div className='login_form'>

                <div className='block_form_input'>
                    <h3>Введите логин:</h3>
                    <input
                        id='id-login'
                        className='form_input'
                        type='text'
                    />
                </div>

                <div className='block_form_input'>
                    <h3>Введите пароль:</h3>
                    <input
                        id='id-password'
                        className='form_input'
                        type='password'
                    />
                </div>

                <div className='login_form_buttons'>
                    <button className='button primary' onClick={() => loginning(history, urlNew)}>Войти</button>
                    <button className='button' onClick={() => redirected()}>Регистрация</button>
                </div>
            </div>
        </section>
    );
  }
  
export default Login;
  