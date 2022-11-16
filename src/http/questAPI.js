import { $host } from './index'


export const getRoom = async (id) => {
    const {data} = await $host.get('quest/' + id)
    return data
}

export const postQues = async (value) => {
    const {data} = await $host.post('quest', null, { params: {
        userId: 1,
        roomId: 1,
        questionId: 2
      }})
    return data
}