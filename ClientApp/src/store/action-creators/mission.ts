import axios from "axios"
import { Dispatch } from "react"
import { MissionActionTypes } from "../../enums/actionTypes"
import { fetchData } from "../../hooks/fetchHook"
import { MissionAction } from "../types/mission"



export const fetchMissions = () => {
	return async (dispatch: Dispatch<MissionAction>) => {
		try {
			dispatch({
				type: MissionActionTypes.FETCH_MISSIONS
			})
			const response = fetchData('tasks', { projectId: 1 })
			dispatch({
				type: MissionActionTypes.FETCH_MISSIONS_SUCCESS,
				payload: response
			})

		} catch (e) {
			dispatch({
				type: MissionActionTypes.FETCH_MISSIONS_ERROR,
				payload: 'Ошибка'

			})
		}
	}
}