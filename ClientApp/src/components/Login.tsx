import React, { useEffect, useState } from 'react'

import { Formik, Field, Form } from "formik";
import { fetchData } from '../hooks/fetchHook';
import { useActions } from '../hooks/useActions';
import { useTypedSelector } from '../hooks/useTypedSelector';
import { IUser } from '../store/types/user';
import AuthForm from './AuthForm';
import { Link, Navigate } from 'react-router-dom';
import Suck from './Suck';




const Login = () => {
	const { user, loading } = useTypedSelector(state => state.user)
	const [result, setResult] = useState<any>()
	useEffect(() => {

		if (loading) {
			setResult(<Suck />)
		} else {
			user == null ? setResult(
				< div >
					<AuthForm />
					<Link to='/testfetch'>sad</Link>




				</ div>
			) : setResult(<Navigate to="/" />)
		}
	}








		, [loading, user])

	return result
}



export default Login