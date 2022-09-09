import React, { FC } from 'react'



import { useEffect } from 'react'



import { useActions } from '../hooks/useActions'
import { useTypedSelector } from '../hooks/useTypedSelector'




const TestFetch: FC = () => {


	const { fetchMissions } = useActions()
	const { missions } = useTypedSelector(state => state.mission)





	useEffect(() => {
		(fetchMissions())

	}, [])


	return (
		<div>

			{missions.map(mission =>
				<div key={mission.id}>{mission.name}</div>
			)}

		</div>)
}







export default TestFetch;