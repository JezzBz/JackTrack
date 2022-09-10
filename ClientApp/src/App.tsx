import axios from 'axios'
import React, { useEffect, useLayoutEffect, useState } from 'react'
import { BrowserRouter, Route, Router, Routes } from 'react-router-dom'
import Login from './components/Login'
import PrivateRoute from './components/PrivateRoute'
import TestFetch from './components/TestFetch'
import { fetchData } from './hooks/fetchHook'
import { useActions } from './hooks/useActions'
import { useTypedSelector } from './hooks/useTypedSelector'

function App() {
	const { loading, user } = useTypedSelector(state => state.user)
	const { fetchAuth } = useActions()
	useLayoutEffect(() => {

		fetchAuth(); console.log(1)
	}, [])





	return (
		<div>

			<BrowserRouter>
				<Routes>
					<Route path='/login' element={<Login />} />
					<Route path='testfetch' element={<PrivateRoute component={<TestFetch />} />} />




				</Routes>

			</BrowserRouter>

		</div>
	)
}

export default App