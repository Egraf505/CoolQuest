import { $host } from './index'


export const getRoom = async () => {
    const {data} = await $host.get('questions/1')
    return data
}