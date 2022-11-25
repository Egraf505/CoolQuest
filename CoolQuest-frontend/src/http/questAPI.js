import { $authHost, $host } from './index'

export const getRoom = async (id) => {
    const {data} = await $authHost.get('quest/' + id)
    return data
}

export const postQuest = async (userId, roomId, questionId) => {
    const {data} = await $host.post('quest', null, { params: {
        userId,
        roomId,
        questionId
      }})
    return data
}