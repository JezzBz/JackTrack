
import React, { useEffect } from 'react'

import { Formik, Field, Form } from "formik";
import { fetchData } from '../hooks/fetchHook';
import { useActions } from '../hooks/useActions';
import { useTypedSelector } from '../hooks/useTypedSelector';
import { IUser } from '../store/types/user';



const AuthForm = () => {
	const { setUser } = useActions()
	const { user, error } = useTypedSelector(state => state.user)




	return (
		<div>

			<Formik
				initialValues={{ email: '', password: '' }}
				onSubmit={(value) => { setUser(value) }}>


				<Form>
					<Field name="email" type="email" />
					<Field name="password" type="password" />
					<button type="submit">Submit</button>
				</Form>
			</Formik>
			<div>{error}</div>
		</div>
	)
}

export default AuthForm