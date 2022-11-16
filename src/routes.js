import Room from "./pages/Room"
import Login from "./pages/Login"
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
]