import axios from "axios"
import { API_URL } from "../http/api"


export const fetchData = (controller: string, payload: any) => {
	let result: any;
	axios.post(`${API_URL}${controller}`, payload, {


		headers: {
			'Content-Type': 'application/json'

		}
	}).then(response => {
		result = response


	})

	return result






}