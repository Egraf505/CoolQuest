import React from 'react'

import logo from './../img/logo.png'

const Header = () => {
    return (
        <section className='header'>
            <div className='container-medium'>
                <div className='header_img'></div>
                <div className='header_block'>
                    <img src={logo} alt={logo} />

                    <h1>
                    Белгородский государственный 
                    академический драматический 
                    театр им. М.С. Щепкина.
                    </h1>
                </div>
            </div>
        </section>
    );
  }

  
export default Header;
  