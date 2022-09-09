import axios from 'axios'
import React, { useEffect, useState } from 'react'
import Login from './components/Login'
import TestFetch from './components/TestFetch'
import { fetchData } from './hooks/fetchHook'

function App() {
	useEffect(() => {
		const user = fetchData('user/authorized', null)
		console.log(user)
	}, [])








	return (
		<div>
			<TestFetch />
			<Login />
		</div>
	)
}

export default App