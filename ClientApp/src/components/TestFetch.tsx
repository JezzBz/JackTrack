import React, { FC } from 'react'
import { useEffect } from 'react'
import { Link } from 'react-router-dom'
import { useActions } from '../hooks/useActions'
import { useTypedSelector } from '../hooks/useTypedSelector'
import '../styles/TasksPage.css'




const TestFetch: FC = () => {


	const { fetchMissions } = useActions()
	const { missions } = useTypedSelector(state => state.mission)





	useEffect(() => {
		(fetchMissions())

	}, [])


	return (
		<div className='TasksPage'>
			<Link to="/">Home</Link>
			{missions.map(mission =>
				<div key={mission.id} className="Task">

				<div className='Task_Number'>
				#{mission.id}
				</div>
				<div className='Task_Name'>
				{mission.name}	
				</div>	

				<div className='Task_Description'>
					{mission.description}
				</div>
			 	</div>
			)}

		</div>)
}







export default TestFetch;