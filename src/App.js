import React from 'react'
import CreateTask from './pages/CreateTask';
import Login from './pages/Login';
import Registration from './pages/Registration';
import PinCode from './pages/PinCode';
import Test from './pages/Test';
import Room from './pages/Room';

import { BrowserRouter } from "react-router-dom";

import AppRouter from "./components/AppRouter";



const App = () => {
    return (
      <>
        <BrowserRouter>
          <AppRouter />
        </BrowserRouter>
      </>
    );
  }
  
export default App;
  