import React from 'react'

import { Formik, Field, Form } from "formik";
import { fetchData } from '../hooks/fetchHook';


const Login = () => {





	return (

		<div>

			<Formik
				initialValues={{ email: '', password: '' }}
				onSubmit={(value) => fetchData('user/login', value)}



			>




				<Form>

					<Field name="email" type="email" />
					<Field name="password" type="password" />
					<button type="submit">Submit</button>




				</Form>
			</Formik>
		</div>
	)
}

export default Login