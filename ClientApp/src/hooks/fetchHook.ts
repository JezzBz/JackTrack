import axios from "axios"
import { API_URL } from "../http/api"


export const  fetchData = async (controller: string, payload: any) => {
	
	return await  axios.post(`${API_URL}${controller}`, payload, {


		headers: {
			'Content-Type': 'application/json'

		}
	}).then(response => {
		return response

	})
	

	






}