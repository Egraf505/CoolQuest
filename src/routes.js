import Room from "./pages/Room"
import Login from "./pages/Login"
import Test from "./pages/Test"
import Registration from "./pages/Registration"
import Error from "./pages/Error"

export const publicPages = [
    {
        path: '/login',
        component: Login,
    },

    {
        path: '/registration',
        component: Registration,
    },

    {
        path: '/error',
        component: Error,
    },

    {
        path: '/quest' + '/:id',
        component: Room,
    },
]


export const typesQuest = {
    'test': Test,
}
