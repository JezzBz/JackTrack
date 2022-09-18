import React from 'react'
import { Link } from 'react-router-dom'
import { useActions } from '../hooks/useActions'
import { useTypedSelector } from '../hooks/useTypedSelector'
import '../styles/HomePage.css'


export default function HomePage() {

  return (
    <div className='HomePage'>

        <Link to="/login">Sign in</Link>
        <Link to ="/testfetch">Tasks</Link>
       
    </div>
  )
}
