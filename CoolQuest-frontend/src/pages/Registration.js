import React, { useState } from 'react'
import { useHistory } from 'react-router-dom'
import { reg } from '../http/authAPI'
import { loginning } from './Login'


const Registration = () => {

    const history = useHistory()
    const urlNew = history.location.search.split('=')[1]

    const [password, setPassword] = useState('')
    const [againPassword, setAgainPassword] = useState('')
    const [validation, setValidation] = useState('')

    const registration = async () => {

        // validation
        if (password == againPassword){

            // registration
            const name = document.getElementById("reg-id-name").value
            const surname = document.getElementById("reg-id-surname").value
            const email = document.getElementById("reg-id-email").value

            await reg(name, surname, email, password)
            .then((data) => {
                loginning(history, urlNew, email, password)
            })
            .catch((e) => {
                console.log('Ошибка регистрации')
            })
        } else{
            setValidation('Пароли не совпадают')
        }

    }

    const redirected = () => {
        history.push({
            pathname: '/login',
            search: '?url=' + (urlNew || '/'),
        })
    }

    return (
        <section className='reg'>
            <div className='title'>Регистрация</div>
            <div className='reg_form'>

                <div className='block_form_input'>
                    <span>{validation}</span>
                </div>

                <div className='block_form_input'>
                    <h3>Ваше имя</h3>
                    <input
                        id='reg-id-name'
                        className='form_input'
                        type='text'
                        placeholder='Иван'
                    />
                </div>

                <div className='block_form_input'>
                    <h3>Ваша фамилия</h3>
                    <input
                        id='reg-id-surname'
                        className='form_input'
                        type='text'
                        placeholder='Иванов'
                    />
                </div>

                <div className='block_form_input'>
                    <h3>Ваш E-mail</h3>
                    <input
                        id='reg-id-email'
                        className='form_input'
                        type='email'
                        placeholder='ivan@yandex.ru'
                    />
                </div>

                <div className='block_form_input'>
                    <h3>Пароль</h3>
                    <input
                        id='reg-id-password'
                        className='form_input'
                        type='password'
                        value={password}
                        onChange={e => setPassword(e.target.value)}
                    />
                </div>

                <div className='block_form_input'>
                    <h3>Повторите пароль</h3>
                    <input
                        id='reg-id-password-again'
                        className='form_input'
                        type='password'
                        value={againPassword}
                        onChange={e => setAgainPassword(e.target.value)}
                    />
                </div>

                <div className='reg_form_buttons'>
                    <button className='button primary' onClick={() => registration()}>Зарегистрироваться</button>
                    <button className='button' onClick={() => redirected()}>Войти</button>
                </div>

            </div>
        </section>
    );
  }
  
export default Registration;
  