import React from 'react';

import {
  Collapse,
  Navbar,
  NavbarToggler,
  Nav,
  NavItem,
  NavLink,
  UncontrolledDropdown,
  DropdownToggle,
  DropdownMenu,
  DropdownItem,
} from 'reactstrap';
import logo from '../assets/logo.png';
import { signOutPatient } from '../Data/PatientData';

export default function NavigationBar() {
  
  return (
    <div className='navbar-container'>
      <Navbar light expand='md' className='navbar'>
        {/* <NavbarBrand href='/'>
          <img className='nav-logo' src={logo} alt='logo' />
        </NavbarBrand> */}
        <NavbarToggler  />
        <Collapse navbar>
          <Nav className='container-fluid' navbar>
            <NavItem>
              <NavLink href='/'>
                <span className='nav-span'>Bill</span>
              </NavLink>
            </NavItem>
            <NavItem>
              <NavLink href='/Patient'>
                <span className='nav-span'>Patient</span>
              </NavLink>
            </NavItem>
            <NavItem>
              <NavLink href='/Createbill'>
                <span className='nav-span'>Create Bill</span> 
              </NavLink>
            </NavItem>
              <>
                <UncontrolledDropdown nav inNavbar className='user-drop'>
                  <DropdownToggle nav caret>
                    <img
                      className='user-img'
                      referrerPolicy='no-referrer'
                      alt='user'
                      src={logo}
                    />
                    <span className='nav-span-user'>User</span>
                  </DropdownToggle>
                  <DropdownMenu>
                    <DropdownItem>
                      <NavLink className="sign-out-user" onClick={signOutPatient}>Sign Out</NavLink>
                    </DropdownItem>
                  </DropdownMenu>
                </UncontrolledDropdown>
              </>
          </Nav>
        </Collapse>
      </Navbar>
    </div>
  );
}
