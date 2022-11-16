import Room from "./pages/Room"
import Login from "./pages/Login"
import Test from "./pages/Test"
import Registration from "./pages/Registration"

export const publicPages = [
    {
        path: '/',
        component: Room,
    },

    {
        path: '/login',
        component: Login,
    },

    {
        path: '/registration',
        component: Registration,
    },

    {
        path: '/room',
        component: Test,
    },

    // {
    //     path: '/room' + '/:id',
    //     component: Room,
    // },
    
    {
        path: '/quest' + '/:id',
        component: Room,
    },
]