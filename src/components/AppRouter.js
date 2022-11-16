import React from 'react'
import { publicPages } from '../routes';
import {Redirect, Route, Switch} from 'react-router-dom'

const AppRouter = () => {

    return(
        <Switch>

            {publicPages.map(({path, component}) => 
                <Route key={path} path={path} component={component} exact />
            )}   
            
            <Redirect to={'/'}/>

        </Switch>
    )
}

export default AppRouter;