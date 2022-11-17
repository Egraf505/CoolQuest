import React from 'react'


import { BrowserRouter } from "react-router-dom";

import AppRouter from "./components/AppRouter";
import Header from './components/Header';



const App = () => {

    // useEffect(() => {
      
    //   auth()
    //   .then(data => {
    //     console.log('Все ок')
    //   })
    //   .catch(e => {
    //     const urlOld = e.response.config.ur
    //     // history.push("/login");
    //   })

    // }, [])


    return (
      <>
        <BrowserRouter>
          <Header />
          <AppRouter />
        </BrowserRouter>
      </>
    );
  }
  
export default App;
  