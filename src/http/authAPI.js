import { $authHost, $host } from './index'

export const login = async (username, password) => {
    const {data} = await $host.post('token', null, { params: {
        username,
        password,
      }})
    return data
}

export const reg = async (name, surname, email, password) => {
  const {data} = await $host.post('userAdd', null, { params: {
      name,
      surname,
      email,
      password,
    }})
  return data
}

// export const auth = async () => {
//   const {data} = await $authHost.get('quest/1')
//   return data
// }