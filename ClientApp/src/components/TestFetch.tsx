import React, { FC } from 'react'

import axios from 'axios'
import { useState } from 'react'
import { useEffect } from 'react'

import { Mission, MissionAction } from '../store/types/mission'
import { fetchData } from '../hooks/fetchHook'
import { useDispatch } from 'react-redux'
import { fetchMissions } from '../store/action-creators/mission'
import { useActions } from '../hooks/useActions'
import { useTypedSelector } from '../hooks/useTypedSelector'




const TestFetch: FC = () => {

	const dispatch = useDispatch()
	const { fetchMissions } = useActions()
	//const { missions } = useTypedSelector(state => state.missionReducer)





	useEffect(() => {
		(fetchMissions())

	}, [])


	return (
		<div>
			{/* //////{missions.map(mission =>
			//	<div key={mission.id}>{mission.name}</div>
			//)} */}

		</div>)
}







export default TestFetch;