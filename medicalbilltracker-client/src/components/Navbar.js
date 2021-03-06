/* eslint-disable no-undef */
import React from 'react';
import {
  
 NavLink, Button
 
} from 'reactstrap';
import { signOutUser } from '../Data/UserData';
import logo from '../assets/logo.png';


// const ButtonStyle = styled(Button)`
//   border-radius: 5px;
//   background-color: seafoam;
//   width: 150px;
//   height: 40px;
//   margin-bottom: 10px;
//   border: 2px solid black;
//   box-shadow: 2px 2px 1px;
// `;

export default function AppNavbar() {

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


      {/* <Button onClick={signOutUser} className="login-btn" type="button" style={{ width: '150px', height: '40px', border: '2px solid black'}}>
        Sign Out
      </Button> */}

  </div>
);
}
