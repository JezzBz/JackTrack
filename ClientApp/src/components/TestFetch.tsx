import React, { FC } from 'react'

import axios from 'axios'
import { useState } from 'react'
import { useEffect } from 'react'

import { Mission } from '../store/types'




const TestFetch = () => {
	const [mission, setMission] = useState(Object)




	useEffect(() => {
		axios.get('https://localhost:7257/api/tasks/', {
			params: {
				projectId: 1
			},
			headers: {
				'Content-Type': 'application/json',
			}
		}).then(response => {
			console.log(response.data)
			const result = response.data
			console.log(result)
			setMission(result)
			console.log(mission)
		})



	}, [])



	return (
		<div>
			<h1>{mission.name}</h1>
			<h1>{mission.description}</h1>
			<h1>{mission.startTime}</h1>
			<h1>{mission.endTime}</h1>

		</div>
	)
}




export default TestFetch;