import React from 'react';
import {
  
 
  NavLink,
 
} from 'reactstrap';
import { signInPatient, signOutPatient } from '../Data/PatientData';
import logo from '../assets/logo.png';


export default function AppNavbar({ patient }) {

  return (
    <div className="nav">
   
      <NavLink href="/">
      <img className='nav-logo' src={logo} alt='logo' />
      </NavLink>
     
      <NavLink href="/">
         <span className='nav-span'>Home</span>
         
         </NavLink>


      <NavLink href="/Archive">  
      <span className='nav-span'>Archive</span>
         </NavLink>

    {patient ? (
      <button onClick={signOutPatient} className="login-btn" type="button">
        Sign Out
      </button>
    ) : (
      <button onClick={signInPatient} className="login-btn" type="button">
        Sign In
      </button>
    )}
  </div>
);
}
